using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabExercise.Models;

namespace LabExercise.Controllers
{
    public class LabTestDuesController : Controller
    {
        private LabTestContext db = new LabTestContext();

        // GET: LabTestDues
        public ActionResult Index()
        {
            return View(db.labTestDue.ToList());
        }

        // GET: LabTestDues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabTestDue labTestDue = db.labTestDue.Find(id);
            if (labTestDue == null)
            {
                return HttpNotFound();
            }
            return View(labTestDue);
        }

        // GET: LabTestDues/Create
        public ActionResult Create()
        {
            ViewBag.cities = new SelectList(db.labTestDue.ToList(), "id", "patientName", "dateTimeStamp");
            return View();
        }

        // POST: LabTestDues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,patientName,dateTimeStamp")] LabTestDue labTestDue)
        {
            if (ModelState.IsValid)
            {
                db.labTestDue.Add(labTestDue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(labTestDue);
        }

        // GET: LabTestDues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabTestDue labTestDue = db.labTestDue.Find(id);
            if (labTestDue == null)
            {
                return HttpNotFound();
            }
            return View(labTestDue);
        }

        // POST: LabTestDues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,patientName,dateTimeStamp")] LabTestDue labTestDue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labTestDue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(labTestDue);
        }

        // GET: LabTestDues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabTestDue labTestDue = db.labTestDue.Find(id);
            if (labTestDue == null)
            {
                return HttpNotFound();
            }
            return View(labTestDue);
        }

        // POST: LabTestDues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LabTestDue labTestDue = db.labTestDue.Find(id);
            db.labTestDue.Remove(labTestDue);
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
