using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteForDoctors.Models;
using WebsiteForDoctors.Models.ViewModels;

namespace WebsiteForDoctors.Controllers
{
    public class AppointmentsController : Controller
    {
        private DoctorsPatientsContext db = new DoctorsPatientsContext();

        // GET: Appointments
        public ActionResult Index()
        {
            //Appointment app = new Appointment();
            //app.date = DateTime.Now;
            ViewBag.Doctor = new SelectList(db.doctors.ToList(), "id", "name");
            var appointment = db.appointment.Include(a => a.consultationSlot).Include(a => a.patient);
            return View(appointment.ToList());

            //return View(app);

        }

        [HttpPost]
        public ActionResult Index(List<Appointment> app)
        {
            //DateTime date = app.date;
            ViewBag.Doctor = new SelectList(db.doctors.ToList(),"id","name");
            return View(app);

        }



       

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            List<ConsultationSlot> csList = db.consultationSlot.Include("doctor").ToList();
            List<ConsultSlotViewModel> csvm = new List<ConsultSlotViewModel>();
            foreach (ConsultationSlot cs in csList)
            {
                ConsultSlotViewModel csv = new ConsultSlotViewModel();
                csv.ConsultID = cs.id;
                csv.docDetails = cs.doctor.name + "-" + cs.dow + "-" + cs.startTime;
                csvm.Add(csv);
            }
            ViewBag.consultSlotID = new SelectList(csvm, "ConsultID", "docDetails");

            //ViewBag.consultSlotID = new SelectList(db.consultationSlot, "id", "id");
            ViewBag.patientID = new SelectList(db.patients, "id", "name");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,consultSlotID,date,patientID")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.appointment.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.consultSlotID = new SelectList(db.consultationSlot, "id", "id", appointment.consultSlotID);
            ViewBag.patientID = new SelectList(db.patients, "id", "name", appointment.patientID);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.consultSlotID = new SelectList(db.consultationSlot, "id", "id", appointment.consultSlotID);
            ViewBag.patientID = new SelectList(db.patients, "id", "name", appointment.patientID);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,consultSlotID,date,patientID")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.consultSlotID = new SelectList(db.consultationSlot, "id", "id", appointment.consultSlotID);
            ViewBag.patientID = new SelectList(db.patients, "id", "name", appointment.patientID);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.appointment.Find(id);
            db.appointment.Remove(appointment);
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

    internal class consultationSlotViewModel
    {
    }
}
