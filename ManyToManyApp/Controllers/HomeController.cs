using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManyToManyApp.Models;
using System.Net;

namespace ManyToManyApp.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db = new StudentContext();
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var student = db.Students.Find(id);
            if (student == null)
                return HttpNotFound();
            return View(student);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var student = db.Students.Find(id);
            if (student == null)
                return HttpNotFound();
            ViewBag.Courses = db.Courses.ToList();
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student studentData, int[] selectedCourses)
        {
            var student = db.Students.Find(studentData.Id);
            student.Name = studentData.Name;
            student.Surname = studentData.Surname;

            student.Courses.Clear();
            if (selectedCourses != null)
            {
                foreach (var course in db.Courses.Where(c => selectedCourses.Contains(c.Id)))
                {
                    student.Courses.Add(course);
                }
            }

            db.Entry(student).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Courses = db.Courses.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student, int[] selectedCourses)
        {
            student.Courses.Clear();
            if (selectedCourses != null)
            {
                foreach (var course in db.Courses.Where(c => selectedCourses.Contains(c.Id)))
                    student.Courses.Add(course);
            }
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
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