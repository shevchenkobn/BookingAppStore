using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllersBasics.Util;

namespace ControllersBasics.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Head = "fruits";
            ViewBag.Fruits = new string[] { "pear", "peach", "apple" }; 
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult GetHtml(string html = "")
        {
            return new HtmlResult(html == "" ? "<h1>Empty html</h1>" : html);
        }

        public ActionResult GetImage()
        {
            return new ImageResult("/Content/Images/image.png");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ContentResult Square(int a = 3, int h = 10)
        {
            return Content($"Square of triangle (a = {a} and h = {h}) is {a * h / 2}");
        }
        public ContentResult SquareNoParams()
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

        public ActionResult GetVoid(int i = 3)
        {
            if (i <= 3)
                return HttpNotFound();
                //return new HttpStatusCodeResult(404);
                //return RedirectToAction("Square", "Home", new { a = 5, h = 6 });
            return View("About");
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