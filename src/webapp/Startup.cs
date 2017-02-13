using System;
using Dal;
using Dal.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using WebApp.Filters;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// Add directory browser capacity in Dev env
        /// </summary>
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            configureServices(services, true);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            configureServices(services, false);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        private void configureServices(IServiceCollection services, bool isDev)
        {
            services.AddMvc();

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Global.LOGGED_USER,
                    policy => policy.RequireClaim(nameof(User.Email))
                        .RequireClaim(nameof(User.NickName)));
            });

			services.AddScoped<ValidateModelAttribute>();

            services.AddSingleton<IUserStore>(new UserStoreLocal());

            if (isDev)
                services.AddDirectoryBrowser();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
			loggerFactory.AddNLog();
    		app.AddNLogWeb();

			loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }



            app.UseStaticFiles();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationScheme = Global.AUTH_USER_COOKIE,
                LoginPath = new PathString("/Account/Login/"),
                AccessDeniedPath = new PathString("/Account/Forbidden/"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                ExpireTimeSpan = TimeSpan.FromMinutes(2)
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapAreaRoute(
                    name: "api",
                    areaName: "Api",
                    template: "api/v{version:apiVersion}/{controller}/{action}/{id?}"
                );
            });
        }
    }
}
