﻿using System;
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
    public class ExerciseInWorkoutsController : Controller
    {
        private GymDbContext db = new GymDbContext();

        // GET: ExerciseInWorkouts
        public ActionResult Index()
        {
            var exercisesInWorkouts = db.ExercisesInWorkouts.Include(e => e.Exercise).Include(e => e.Workout);
            return View(exercisesInWorkouts.ToList());
        }

        // GET: ExerciseInWorkouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseInWorkout exerciseInWorkout = db.ExercisesInWorkouts.Find(id);
            if (exerciseInWorkout == null)
            {
                return HttpNotFound();
            }
            return View(exerciseInWorkout);
        }

        // GET: ExerciseInWorkouts/Create
        public ActionResult Create()
        {
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ExerciseID", "ExerciseName");
            ViewBag.WorkoutID = new SelectList(db.Workouts, "WorkoutID", "Duration");
            return View();
        }

        // POST: ExerciseInWorkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExerciseInWorkoutID,ExerciseID,WorkoutID,Sets,Repetitions,Time,Weight")] ExerciseInWorkout exerciseInWorkout)
        {
            if (ModelState.IsValid)
            {
                db.ExercisesInWorkouts.Add(exerciseInWorkout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExerciseID = new SelectList(db.Exercises, "ExerciseID", "ExerciseName", exerciseInWorkout.ExerciseID);
            ViewBag.WorkoutID = new SelectList(db.Workouts, "WorkoutID", "Duration", exerciseInWorkout.WorkoutID);
            return View(exerciseInWorkout);
        }

        // GET: ExerciseInWorkouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseInWorkout exerciseInWorkout = db.ExercisesInWorkouts.Find(id);
            if (exerciseInWorkout == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ExerciseID", "ExerciseName", exerciseInWorkout.ExerciseID);
            ViewBag.WorkoutID = new SelectList(db.Workouts, "WorkoutID", "Duration", exerciseInWorkout.WorkoutID);
            return View(exerciseInWorkout);
        }

        // POST: ExerciseInWorkouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExerciseInWorkoutID,ExerciseID,WorkoutID,Sets,Repetitions,Time,Weight")] ExerciseInWorkout exerciseInWorkout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exerciseInWorkout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ExerciseID", "ExerciseName", exerciseInWorkout.ExerciseID);
            ViewBag.WorkoutID = new SelectList(db.Workouts, "WorkoutID", "Duration", exerciseInWorkout.WorkoutID);
            return View(exerciseInWorkout);
        }

        // GET: ExerciseInWorkouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseInWorkout exerciseInWorkout = db.ExercisesInWorkouts.Find(id);
            if (exerciseInWorkout == null)
            {
                return HttpNotFound();
            }
            return View(exerciseInWorkout);
        }

        // POST: ExerciseInWorkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExerciseInWorkout exerciseInWorkout = db.ExercisesInWorkouts.Find(id);
            db.ExercisesInWorkouts.Remove(exerciseInWorkout);
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