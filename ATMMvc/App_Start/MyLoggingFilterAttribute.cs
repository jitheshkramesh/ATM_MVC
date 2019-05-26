
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATMMvc.App_Start
{
    public class MyLoggingFilterAttribute: System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            Logger.logRequest(request.UserHostAddress);
            base.OnActionExecuted(filterContext);
        }

        private class Logger
        {
            internal static void logRequest(string userHostAddress)
            {
//                throw new NotImplementedException();
            }

        }
    }
}