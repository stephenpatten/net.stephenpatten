using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.UI.Extensions;

namespace Web.UI.Infrastructure.Attributes
{
    public class JsonpFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            //
            // see if this request included a "callback" querystring parameter
            //
            var callback = filterContext.HttpContext.Request.QueryString["callback"];
            if (string.IsNullOrEmpty(callback)) return;
            //
            // ensure that the result is a "JsonResult"
            //
            var result = filterContext.Result as JsonResult;
            if (result == null)
            {
                throw new InvalidOperationException("JsonpFilterAttribute must be applied only " +
                                                    "on controllers and actions that return a JsonResult object.");
            }

            filterContext.Result = new JsonpResult
                                       {
                                           ContentEncoding = result.ContentEncoding,
                                           ContentType = result.ContentType,
                                           Data = result.Data,
                                           Callback = callback
                                       };
        }
    }
}