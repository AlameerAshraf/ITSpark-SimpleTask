using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITSpark_AlameerAshraf.Models;

namespace ITSpark_AlameerAshraf.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDb db = new ApplicationDb();

        [HttpGet]
        public ActionResult StudentsJson()
        {
            var s = (from p in db.Students
                     join t in db.Countries on p.CId equals t.CId
                     select new { Name = p.Name, cntry = t.Name, DateOfBirth = p.DateOfBirth, University = p.University, Track = p.Track, Course = p.Course }).ToList();
            return Json(s, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult Create()
        {
            var Countries = db.Countries.ToList();
            ViewBag.cons = new SelectList(Countries, "CId", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student,Guid cons)
        {   
            if (ModelState.IsValid)
            {
                student.Id = Guid.NewGuid();
                student.CId = cons;
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult Edit(Guid? id)
        {
            var Countries = db.Countries.ToList();
            ViewBag.cons = new SelectList(Countries, "CId", "Name");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student , Guid cons)
        {
            if (ModelState.IsValid)
            {
                student.CId = cons;
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
