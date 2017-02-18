using Autofac;
using Dal;
using WebApplication.Helpers;

namespace WebApplication
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterInstance<IUserStore>(new UserStoreLocal()).SingleInstance();
            builder.Register<UserStoreLocal>(c => new UserStoreLocal()).As<IUserStore>().SingleInstance();
			builder.RegisterType<Authenticator>().As<IAuthenticator>();
        }
    }
}
