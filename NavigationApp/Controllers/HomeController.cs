using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NavigationApp.Models;
using System.Data.Entity;
using System.Net;

namespace NavigationApp.Controllers
{
    public class HomeController : Controller
    {
        SoccerContext db = new SoccerContext();
        public ActionResult Index()
        {
            var players = db.Players.Include(p => p.Team);
            return View(players.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult TeamDetails(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var team = db.Teams.Include(t => t.Players).FirstOrDefault(t => t.Id == id);
            if (team == null)
                return HttpNotFound();
            return View(team);
        }

        //[HttpGet]
        //public ActionResult Create()
        //{

        //}

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}