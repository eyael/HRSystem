using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using DoctorsPatientWebsite.Models;
using DoctorsPatientWebsite.Models.ViewModel;

namespace DoctorsPatientWebsite.Controllers
{
    public class AppointmentsController : Controller
    {
        private DoctorsContext db = new DoctorsContext();

        // GET: Appointments
        [HttpGet]
        public ActionResult Index()
        {
            List<ConsultationSlot> listsOfSlot = db.consultationSlot.ToList();
            List<Appointment> listsOfApp = db.appointment.ToList();
            List<Appointment> appointment = db.appointment.Where(a => a.date >= DateTime.Now).Include(a => a.doctor).ToList();


            //dynamic myList = new ExpandoObject();
            //myList.ConsultationSlot = listsOfSlot;
            //myList.Appointment = appointment;

            //var tupleTry = new Tuple<List<ConsultationSlot>, List<Appointment >> (listsOfSlot, appointment);


            //return View(myList);


            return View(appointment.ToList());
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

            List<ConsultationSlot> csList = db.consultationSlot.Include(x=>x.doctor).ToList();
            List<ConsultationViewModel> csvm = new List<ConsultationViewModel>();
            //foreach (ConsultationSlot cs in csList)
            //{
            //    ConsultationViewModel csv = new ConsultationViewModel();
            //    csv.ConsultID = cs.id;
            //    csv.docDetails = cs.doctor.name + "-" + cs.dow + "-" + cs.startTime;
            //    csvm.Add(csv);
            //}
            ViewBag.appointmentHour = new SelectList(csvm, "ConsultID", "docDetails");
            ViewBag.specID = new SelectList(db.speciality.ToList(), "id", "name");

            //ViewBag.consultSlotID = new SelectList(db.consultationSlot, "id", "id");
           // ViewBag.patientID = new SelectList(db.patients, "id", "name");
            ViewBag.docID = new SelectList(db.doctors, "id", "name");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,appointmentHour,date,docID")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointment.patientID = HttpContext.User.Identity.Name;
                db.appointment.Add(appointment);
                db.SaveChanges();
                sendMail(appointment.date);
                return RedirectToAction("Index");
            }

            //ViewBag.consultSlotID = new SelectList(db.consultationSlot, "id", "id", appointment.consultSlotID);

            ViewBag.docID = new SelectList(db.doctors, "id", "name", appointment.docID);
            return View(appointment);

            //return RedirectToAction("Index");
        }

        

        public void sendMail(DateTime dt)
          
        {
            RegisterViewModel rv = new RegisterViewModel();


            var message = new MailMessage();
            message.From = new MailAddress("eyaeldeveloper@gmail.com");
            var recipient = HttpContext.User.Identity.Name;
           // string Email = db.
            //var recipient = "eyaelja1@gmail.com"; 
            message.To.Add(recipient);//See carrier destinations below
           // message.To.Add(new MailAddress("5551234568@txt.att.net")); //message.CC.Add(new MailAddress("carboncopy@foo.bar.com"));
            message.Subject = "Your Appointment Status";
            message.Body = $"Your appointment is reserved for {dt} please be here on time." ;
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;

           
            client.Credentials = new NetworkCredential("eyaeldeveloper@gmail.com", "Eyaeldeveloper!");
            client.EnableSsl = true;
            //client.UseDefaultCredentials = false;
            client.Send(message);

           
        }


        public JsonResult GetDoctor(int id)
        {
            var doc = db.doctors.Where(x => x.specID == id).Select(x => new
            {
                ID = x.id,
               // Text = x.name + "-" + x.specID
                  Text = x.name 
            });
            return Json(doc, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSlots(int id, DateTime dt)
        {
            int dowval = 0;
            string dow = dt.ToString("ddd");
            switch (dow)
            {
                case "Sun":
                  dowval= (int)DOW.SUN;
                    break;
                case "Mon":
                    dowval = (int)DOW.MON;
                    break;
                case "Tue":
                    dowval = (int)DOW.TUE;
                    break;
                case "Wed":
                    dowval = (int)DOW.WED;
                    break;
                case "Thu":
                    dowval = (int)DOW.THUR;
                    break;
                case "Fri":
                    dowval = (int)DOW.FRI;
                    break;
                case "Sat":
                    dowval = (int)DOW.SAT;
                    break;
            }

            //var con = db.appointment.Where(x => x.docID == id && x.date == dt).Select(x => new
            //{
            //    ID = x.id,
            //    Text = x.doctor.name + x.consultationSlot.dow + x.consultationSlot.slots
            //});
            ConsultationSlot cslots = db.consultationSlot.FirstOrDefault(x => x.DocId == id && (int)x.dow == dowval);
           string[] timings = cslots.slots.Split(',');
            List<string> slots = new List<string>();
            foreach(string s in timings)
            {
                slots.Add(s);
            }
           
            var check =  db.appointment.Where(x => x.docID == id && x.date == dt);
            List<string> ahlist = new List<string>();
            foreach(Appointment a in check)
            {
                string[] h = a.appointmentHour.Split(' ');
                ahlist.Add(h[0]);
            }
          
            List<string> cslist = new List<string>();
            foreach(string i in ahlist)
            {
                slots.Remove(i.ToString());
            }

            //List<string> sl = new List<string>();
            List<string> s1 = new List<string>();
            foreach(string s in slots)
            {

                if (int.Parse(s) <= 11)
                    s1.Add(s + " AM");
                else
                    s1.Add((int.Parse(s)>12)? (int.Parse(s) - 12) + " PM":12 + "PM");
            }
            var consult = s1.Select(x => new
            {
                ID = x,
                Text = x 
            });



            return Json(consult, JsonRequestBehavior.AllowGet);
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
           // ViewBag.consultSlotID = new SelectList(db.consultationSlot, "id", "id", appointment.consultSlotID);
            //ViewBag.patientID = new SelectList(db.patients, "id", "name", appointment.patientID);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,appointmentHour,date,docID")] Appointment appointment)
        {
            if (ModelState.IsValid) 
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.consultSlotID = new SelectList(db.consultationSlot, "id", "id");
            //ViewBag.patientID = new SelectList(db.patients, "id", "name", appointment.patientID);
            ViewBag.docID = new SelectList(db.doctors, "id", "name", appointment.docID);
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

        public ActionResult Service()
        {
            return View();
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