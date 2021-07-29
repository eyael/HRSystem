using DoctorsPatientWebsite.Models;
using DoctorsPatientWebsite.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorsPatientWebsite.Controllers
{
    public class HomeController : Controller
    {
        private DoctorsContext db = new DoctorsContext();

        public ActionResult Index()
        {
            List<ConsultationSlot> csList = db.consultationSlot.Include("doctor").ToList();
            List<ConsultationViewModel> csvm = new List<ConsultationViewModel>();
            foreach (ConsultationSlot cs in csList)
            {
                ConsultationViewModel csv = new ConsultationViewModel();
                csv.ConsultID = cs.id;
                csv.docDetails = cs.doctor.name + "-" + cs.dow + "-" + cs.startTime;
                csvm.Add(csv);
            }
            ViewBag.consultSlotID = new SelectList(csvm, "ConsultID", "docDetails");

            //ViewBag.consultSlotID = new SelectList(db.consultationSlot, "id", "id");
           // ViewBag.patientID = new SelectList(db.patients, "id", "name");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}