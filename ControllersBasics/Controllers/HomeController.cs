using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersBasics.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Square(int a = 3, int h = 10)
        {
            return $"Square of triangle (a = {a} and h = {h} is {a * h / 2}";
        }
        public string Square()
        {
            int.TryParse(Request.Params["a"], out int a);
            int.TryParse(Request.Params["h"], out int h);
            return Square(a, h);
        }

        [HttpGet]
        public ActionResult GetBook()
        {
            return View();
        }

        [HttpPost]
        public string PostBook()
        {
            string result = "1st Way:<br>" + Request.Form["name"] + ", " + Request.Form["address"] + "<br>" +
                "2nd Way:<br>" + Request.Form[0] + ", " + Request.Form[1];
            return result;
        }
    }
}