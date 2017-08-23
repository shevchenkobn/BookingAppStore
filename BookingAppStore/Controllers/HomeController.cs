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
            var authors = new SelectList(books, "Author", "Name");
            ViewBag.Authors = authors;
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

        public ActionResult GetBook(int id)
        {
            var book = db.Books.Find(id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        public string GetForm(string[] states)
        {
            return String.Join(", ", states);
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            var purchase = new Purchase { BookId = id, Person = "Unknown" };
            return View(purchase);
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}