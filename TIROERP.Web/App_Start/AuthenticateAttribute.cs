using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace TIROERP.Web.App_Start
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthenticateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["Userdetails"] == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    // For AJAX requests, return result as a simple string, 
                    // and inform calling JavaScript code that a user should be redirected.
                    JsonResult result = new JsonResult();
                    result.Data = "SessionTimeout";
                    result.ContentType = "text/html";
                    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    filterContext.Result = result;
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Login/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}