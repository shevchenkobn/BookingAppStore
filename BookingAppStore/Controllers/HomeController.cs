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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult Delete(int id = 0)
        //{
        //    var book = db.Books.Find(id);
        //    if (book != null)
        //    {
        //        db.Books.Remove(book);
        //        db.SaveChanges();
        //    }

        //    //db.Entry(new Book { Id = id }).State = System.Data.Entity.EntityState.Deleted;
        //    //db.SaveChanges();

        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            var book = db.Books.Find(id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            var book = db.Books.Find(id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            db.Entry(book).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}