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
    public class ContactsController : Controller
    {
        private GymDbContext db = new GymDbContext();
        private readonly IContactRepository _contactRepository = new ContactRepository(new GymDbContext());
        // GET: Contacts
        public ActionResult Index()
        {
            //var contacts = db.Contacts.Include(c => c.ContactType).Include(c => c.Person);
            return View(_contactRepository.All);
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = _contactRepository.GetById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            ViewBag.ContactTypeID = new SelectList(db.ContactTypes, "ContactTypeID", "ContactTypeName");
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "FirstName");
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactID,Value,ContactTypeID,PersonID")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.Add(contact);
                _contactRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactTypeID = new SelectList(db.ContactTypes, "ContactTypeID", "ContactTypeName", contact.ContactTypeID);
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "FirstName", contact.PersonID);
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = _contactRepository.GetById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactTypeID = new SelectList(db.ContactTypes, "ContactTypeID", "ContactTypeName", contact.ContactTypeID);
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "FirstName", contact.PersonID);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactID,Value,ContactTypeID,PersonID")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.Update(contact);
                _contactRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactTypeID = new SelectList(db.ContactTypes, "ContactTypeID", "ContactTypeName", contact.ContactTypeID);
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "FirstName", contact.PersonID);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = _contactRepository.GetById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _contactRepository.Delete(id);
            _contactRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contactRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
