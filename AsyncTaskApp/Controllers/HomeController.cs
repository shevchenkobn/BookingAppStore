using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AsyncTaskApp.Models;

namespace AsyncTaskApp.Controllers
{
    public class HomeController : Controller
    {
        BookContext context = new BookContext();
        public ActionResult Index()
        {
            var books = context.Books.ToList();
            ViewBag.books = books;
            return View();
        }

        public async Task<ActionResult> BookList()
        {
            var books = await context.Books.ToListAsync();
            ViewBag.books = books;
            return View("Index");
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