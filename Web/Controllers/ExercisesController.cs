using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace Web.Controllers
{
    public class ExercisesController : Controller
    {
        private GymDbContext db = new GymDbContext();
        private readonly IExerciseRepository _exerciseRepository = new ExerciseRepository(new GymDbContext());

        // GET: Exercises
        public ActionResult Index()
        {
            //var exercises = db.Exercises.Include(e => e.ExerciseType);
            return View(_exerciseRepository.All);
        }

        // GET: Exercises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = _exerciseRepository.GetById(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // GET: Exercises/Create
        public ActionResult Create()
        {
            ViewBag.ExerciseTypeID = new SelectList(db.ExerciseTypes, "ExerciseTypeID", "ExerciseTypeName");
            return View();
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExerciseID,ExerciseTypeID,ExerciseName,Description,Instructions,VideoUrl,Rating,DateCreated")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                _exerciseRepository.Add(exercise);
                _exerciseRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExerciseTypeID = new SelectList(db.ExerciseTypes, "ExerciseTypeID", "ExerciseTypeName", exercise.ExerciseTypeID);
            return View(exercise);
        }

        // GET: Exercises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = _exerciseRepository.GetById(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseTypeID = new SelectList(db.ExerciseTypes, "ExerciseTypeID", "ExerciseTypeName", exercise.ExerciseTypeID);
            return View(exercise);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExerciseID,ExerciseTypeID,ExerciseName,Description,Instructions,VideoUrl,Rating,DateCreated")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                _exerciseRepository.Update(exercise);
                _exerciseRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseTypeID = new SelectList(db.ExerciseTypes, "ExerciseTypeID", "ExerciseTypeName", exercise.ExerciseTypeID);
            return View(exercise);
        }

        // GET: Exercises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = _exerciseRepository.GetById(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _exerciseRepository.Delete(id);
            _exerciseRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _exerciseRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
