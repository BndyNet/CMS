using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            //TODO: remove testing code
            try
            {
                var i = 0;
                i = 100 / i;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex;
            }
            var model = TempData["Error"] as Exception;
            return View(model);
        }
    }
}