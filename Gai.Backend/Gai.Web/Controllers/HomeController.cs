using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gai.Web.Mvc
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}