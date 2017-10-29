using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace S2CelsoGea.Infra
{
    public class CustomAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            Order = 1;
            if (filterContext.HttpContext.Session["USER"] == null || filterContext.HttpContext.Session["USER_ID"] == null)
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Users", action = "Login" }));
        }
    }
}