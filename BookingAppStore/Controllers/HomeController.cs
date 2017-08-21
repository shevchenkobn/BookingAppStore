using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingAppStore.Models;
using System.Diagnostics;

namespace BookingAppStore.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Index(string id = "")
        {
            var books = db.Books;
            //ViewBag.Books = books;
            if (id.Length < 0 && id[0] == 'l')
                return View("ListView", books);
            else
                return View(books);
        }
        public ActionResult GetList()
        {
            ViewBag.Message = "This is partial view";
            return PartialView(new string[] { "The UK", "The USA", "Russia", "China" });
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Thanks, " + purchase.Person + ", for buying!";
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
    }
}