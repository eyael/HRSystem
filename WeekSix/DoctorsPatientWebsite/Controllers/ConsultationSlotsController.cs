using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoctorsPatientWebsite.Models;

namespace DoctorsPatientWebsite.Controllers
{
    public class ConsultationSlotsController : Controller
    {
        private DoctorsContext db = new DoctorsContext();

        // GET: ConsultationSlots
        public ActionResult Index()
        {
            var consultationSlot = db.consultationSlot.Include(c => c.doctor);
            return View(consultationSlot.ToList());
        }

        // GET: ConsultationSlots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultationSlot consultationSlot = db.consultationSlot.Find(id);
            if (consultationSlot == null)
            {
                return HttpNotFound();
            }
            return View(consultationSlot);
        }

        // GET: ConsultationSlots/Create
        public ActionResult Create()
        {
            ViewBag.DocId = new SelectList(db.doctors, "id", "name");
            return View();
        }

        // POST: ConsultationSlots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,DocId,dow,startTime,endTime,interval")] ConsultationSlot consultationSlot)
        {
            if (ModelState.IsValid)
            {
                int startTime = consultationSlot.startTime;
                int endTime = consultationSlot.endTime;
                int interval = consultationSlot.interval;
                int val = startTime;
                int dow = Convert.ToInt32(consultationSlot.dow);
                int docid = consultationSlot.DocId;
                string slots = "";
                while (val <= endTime - interval)
                {
                    slots += val +",";
                    val += interval;
                }
                slots = slots.TrimEnd(',');
                consultationSlot.slots = slots;
                bool check = SlotExists(Convert.ToInt32(consultationSlot.dow), consultationSlot.DocId);
                if (check)
                {
                    ConsultationSlot cs = db.consultationSlot.FirstOrDefault(x => (int)x.dow == dow && x.DocId ==docid);
                    cs.slots = slots;
                    db.Entry(cs).State = EntityState.Modified;
                }
                else
                {
                    db.consultationSlot.Add(consultationSlot);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocId = new SelectList(db.doctors, "id", "name", consultationSlot.DocId);
            return View(consultationSlot);
        }

        // GET: ConsultationSlots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultationSlot consultationSlot = db.consultationSlot.Find(id);
            if (consultationSlot == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocId = new SelectList(db.doctors, "id", "name", consultationSlot.DocId);
            return View(consultationSlot);
        }

        // POST: ConsultationSlots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,DocId,dow,startTime,endTime,interval")] ConsultationSlot consultationSlot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultationSlot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocId = new SelectList(db.doctors, "id", "name", consultationSlot.DocId);
            return View(consultationSlot);
        }

        // GET: ConsultationSlots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultationSlot consultationSlot = db.consultationSlot.Find(id);
            if (consultationSlot == null)
            {
                return HttpNotFound();
            }
            return View(consultationSlot);
        }

        // POST: ConsultationSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConsultationSlot consultationSlot = db.consultationSlot.Find(id);
            db.consultationSlot.Remove(consultationSlot);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public bool SlotExists(int dow, int docid)
        {
            bool check = db.consultationSlot.Where(x =>(int) x.dow==dow && x.DocId==docid).Count()>0;
            return check;
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
