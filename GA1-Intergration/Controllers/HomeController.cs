using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*
220000213 M Tshabalala
219014331 SL Hadebe
219007267 MP Tsoaela    
*/
namespace GA1_Intergration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}