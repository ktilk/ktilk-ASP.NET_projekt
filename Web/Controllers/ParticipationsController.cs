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
    public class ParticipationsController : Controller
    {
        private GymDbContext db = new GymDbContext();
        private readonly IParticipationRepository _participationRepository = new ParticipationRepository(new GymDbContext());
        // GET: Participations
        public ActionResult Index()
        {
            var participations = db.Participations.Include(p => p.Competition).Include(p => p.Person);
            return View(_participationRepository.All);
        }

        // GET: Participations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participation participation = _participationRepository.GetById(id);
            if (participation == null)
            {
                return HttpNotFound();
            }
            return View(participation);
        }

        // GET: Participations/Create
        public ActionResult Create()
        {
            ViewBag.CompetitionID = new SelectList(db.Competitions, "CompetitionID", "CompetitionName");
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "FirstName");
            return View();
        }

        // POST: Participations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParticipationID,PersonID,CompetitionID,Score")] Participation participation)
        {
            if (ModelState.IsValid)
            {
                _participationRepository.Add(participation);
                _participationRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompetitionID = new SelectList(db.Competitions, "CompetitionID", "CompetitionName", participation.CompetitionID);
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "FirstName", participation.PersonID);
            return View(participation);
        }

        // GET: Participations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participation participation = _participationRepository.GetById(id);
            if (participation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompetitionID = new SelectList(db.Competitions, "CompetitionID", "CompetitionName", participation.CompetitionID);
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "FirstName", participation.PersonID);
            return View(participation);
        }

        // POST: Participations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParticipationID,PersonID,CompetitionID,Score")] Participation participation)
        {
            if (ModelState.IsValid)
            {
                _participationRepository.Update(participation);
                _participationRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompetitionID = new SelectList(db.Competitions, "CompetitionID", "CompetitionName", participation.CompetitionID);
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "FirstName", participation.PersonID);
            return View(participation);
        }

        // GET: Participations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participation participation = _participationRepository.GetById(id);
            if (participation == null)
            {
                return HttpNotFound();
            }
            return View(participation);
        }

        // POST: Participations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _participationRepository.Delete(id);
            _participationRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _participationRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
