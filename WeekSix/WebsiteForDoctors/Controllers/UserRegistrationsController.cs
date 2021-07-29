using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteForDoctors.Models;

namespace WebsiteForDoctors.Controllers
{
    public class UserRegistrationsController : Controller
    {
        private DoctorsPatientsContext db = new DoctorsPatientsContext();

        // GET: UserRegistrations
        public ActionResult Index()
        {
            return View(db.userRegistration.ToList());
        }

        // GET: UserRegistrations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegistration userRegistration = db.userRegistration.Find(id);
            if (userRegistration == null)
            {
                return HttpNotFound();
            }
            return View(userRegistration);
        }

        // GET: UserRegistrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "email,userName,password,ConfirmPassword,age,gender,dob,address,accountType")] UserRegistration userRegistration)
        {
            if (ModelState.IsValid)
            {
                db.userRegistration.Add(userRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userRegistration);
        }

        // GET: UserRegistrations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegistration userRegistration = db.userRegistration.Find(id);
            if (userRegistration == null)
            {
                return HttpNotFound();
            }
            return View(userRegistration);
        }

        // POST: UserRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "email,userName,password,ConfirmPassword,age,gender,dob,address,accountType")] UserRegistration userRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userRegistration);
        }

        // GET: UserRegistrations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegistration userRegistration = db.userRegistration.Find(id);
            if (userRegistration == null)
            {
                return HttpNotFound();
            }
            return View(userRegistration);
        }

        // POST: UserRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserRegistration userRegistration = db.userRegistration.Find(id);
            db.userRegistration.Remove(userRegistration);
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
