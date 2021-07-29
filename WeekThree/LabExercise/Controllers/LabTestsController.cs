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
    public class LabTestsController : Controller
    {
        private LabTestContext db = new LabTestContext();

        // GET: LabTests
        public ActionResult Index()
        {
            return View(db.labTest.ToList());
        }

        // GET: LabTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabTest labTest = db.labTest.Find(id);
            if (labTest == null)
            {
                return HttpNotFound();
            }
            return View(labTest);
        }

        // GET: LabTests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LabTests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] LabTest labTest)
        {
            if (ModelState.IsValid)
            {
                db.labTest.Add(labTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(labTest);
        }

        // GET: LabTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabTest labTest = db.labTest.Find(id);
            if (labTest == null)
            {
                return HttpNotFound();
            }
            return View(labTest);
        }

        // POST: LabTests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] LabTest labTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(labTest);
        }

        // GET: LabTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabTest labTest = db.labTest.Find(id);
            if (labTest == null)
            {
                return HttpNotFound();
            }
            return View(labTest);
        }

        // POST: LabTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LabTest labTest = db.labTest.Find(id);
            db.labTest.Remove(labTest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult LabSchedule()
        {
            return View(db.labTest.ToList());
        }
        [HttpPost]
        public ActionResult LabSchedule(List<LabTest> lt)
        {
            string patient = Request.Form["patient"];
            string dateStamp = Request.Form["dstamp"];
            foreach (LabTest test in lt)

            {
                LabTestDue ltd = new LabTestDue();
                if (test.check)
                {
                    ltd.labTestID = test.id;
                    ltd.patientName = patient;
                    ltd.dateTimeStamp = DateTime.Parse(dateStamp);
                    db.labTestDue.Add(ltd);
                    db.SaveChanges();
                }

            }
            return View(db.labTest.ToList());
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
