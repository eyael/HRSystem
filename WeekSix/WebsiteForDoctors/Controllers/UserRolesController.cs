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
    public class UserRolesController : Controller
    {
        private DoctorsPatientsContext db = new DoctorsPatientsContext();

        // GET: UserRoles
        public ActionResult Index()
        {
            var userRole = db.userRole.Include(u => u.role).Include(u => u.userRegistration);
            return View(userRole.ToList());
        }

        // GET: UserRoles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.userRole.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // GET: UserRoles/Create
        public ActionResult Create()
        {
            ViewBag.roleID = new SelectList(db.role, "id", "name");
            ViewBag.userID = new SelectList(db.userRegistration, "email", "userName");
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,roleID")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                db.userRole.Add(userRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.roleID = new SelectList(db.role, "id", "name", userRole.roleID);
            ViewBag.userID = new SelectList(db.userRegistration, "email", "userName", userRole.userID);
            return View(userRole);
        }

        // GET: UserRoles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.userRole.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.roleID = new SelectList(db.role, "id", "name", userRole.roleID);
            ViewBag.userID = new SelectList(db.userRegistration, "email", "userName", userRole.userID);
            return View(userRole);
        }

        // POST: UserRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,roleID")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.roleID = new SelectList(db.role, "id", "name", userRole.roleID);
            ViewBag.userID = new SelectList(db.userRegistration, "email", "userName", userRole.userID);
            return View(userRole);
        }

        // GET: UserRoles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.userRole.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // POST: UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserRole userRole = db.userRole.Find(id);
            db.userRole.Remove(userRole);
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
