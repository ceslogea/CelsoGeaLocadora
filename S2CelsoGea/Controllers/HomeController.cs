using S2CelsoGea.Context;
using S2CelsoGea.Context.ContextModels;
using S2CelsoGea.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2CelsoGea.Controllers
{
    public class HomeController : Controller
    {
        [CustomAuthorizeAttribute]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page"; 
            return View();
        }
    }
}
