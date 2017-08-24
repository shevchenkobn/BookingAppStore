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

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Teams = new SelectList(db.Teams, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Player player)
        {
            db.Players.Add(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var player = db.Players.Find(id);
            if (player == null)
                return HttpNotFound();
            ViewBag.Teams = new SelectList(db.Teams, "Id", "Name", player.TeamId);
            return View(player);
        }

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            db.Entry(player).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var player = db.Players.Find(id);
            if (player == null)
                return HttpNotFound();
            db.Entry(player).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}