using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Domain;

namespace Web.Controllers
{
    public class ExerciseTypesController : Controller
    {
        private GymDbContext db = new GymDbContext();

        // GET: ExerciseTypes
        public ActionResult Index()
        {
            return View(db.ExerciseTypes.ToList());
        }

        // GET: ExerciseTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseType exerciseType = db.ExerciseTypes.Find(id);
            if (exerciseType == null)
            {
                return HttpNotFound();
            }
            return View(exerciseType);
        }

        // GET: ExerciseTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExerciseTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExerciseTypeID,ExerciseTypeName,Description")] ExerciseType exerciseType)
        {
            if (ModelState.IsValid)
            {
                db.ExerciseTypes.Add(exerciseType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exerciseType);
        }

        // GET: ExerciseTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseType exerciseType = db.ExerciseTypes.Find(id);
            if (exerciseType == null)
            {
                return HttpNotFound();
            }
            return View(exerciseType);
        }

        // POST: ExerciseTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExerciseTypeID,ExerciseTypeName,Description")] ExerciseType exerciseType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exerciseType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exerciseType);
        }

        // GET: ExerciseTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseType exerciseType = db.ExerciseTypes.Find(id);
            if (exerciseType == null)
            {
                return HttpNotFound();
            }
            return View(exerciseType);
        }

        // POST: ExerciseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExerciseType exerciseType = db.ExerciseTypes.Find(id);
            db.ExerciseTypes.Remove(exerciseType);
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
