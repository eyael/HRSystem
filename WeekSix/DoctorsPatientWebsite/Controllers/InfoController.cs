using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorsPatientWebsite.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Service()
        {
            return View();
        }

        public ActionResult Price()
        {
            return View();
        }

        public ActionResult Testimonial()
        {
            return View();
        }
    }
}