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
    public class PlanTypesController : Controller
    {
        //private GymDbContext db = new GymDbContext();
        private readonly IPlanTypeRepository _planTypeRepository = new PlanTypeRepository(new GymDbContext());
        // GET: PlanTypes
        public ActionResult Index()
        {
            return View(_planTypeRepository.All);
        }

        // GET: PlanTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanType planType = _planTypeRepository.GetById(id);
            if (planType == null)
            {
                return HttpNotFound();
            }
            return View(planType);
        }

        // GET: PlanTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlanTypeID,PlanTypeName,Description")] PlanType planType)
        {
            if (ModelState.IsValid)
            {
                _planTypeRepository.Add(planType);
                _planTypeRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planType);
        }

        // GET: PlanTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanType planType = _planTypeRepository.GetById(id);
            if (planType == null)
            {
                return HttpNotFound();
            }
            return View(planType);
        }

        // POST: PlanTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlanTypeID,PlanTypeName,Description")] PlanType planType)
        {
            if (ModelState.IsValid)
            {
                _planTypeRepository.Update(planType);
                _planTypeRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planType);
        }

        // GET: PlanTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanType planType = _planTypeRepository.GetById(id);
            if (planType == null)
            {
                return HttpNotFound();
            }
            return View(planType);
        }

        // POST: PlanTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _planTypeRepository.Delete(id);
            _planTypeRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _planTypeRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
