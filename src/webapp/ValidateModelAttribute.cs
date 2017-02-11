using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace WebApp.Filters
{
	/// <summary>
	/// Use this filter when you want to validate the model request
	/// - return 400 - Bad request with details of validation error.
	///	- otherwise, next(): handle the request
	/// </summary>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
		/// <summary>
		/// The details of validation error is trimmed down by removing unecessary properties
		/// </summary>
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
			var ms = ctx.ModelState;
            if (ms.IsValid == false)
            {
				//slim the ModelState before returning it
                ctx.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
				var resu = new JObject();
				foreach (var k in ms.Keys) {
					var v = ms[k];
					if (v.Errors.Any())
						resu.Add(k, v.Errors[0].ErrorMessage);
				}
				ctx.Result = new JsonResult(resu);
            }
        }
    }
}
