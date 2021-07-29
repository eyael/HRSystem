using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebsiteForDoctors.Models;


namespace WebsiteForDoctors.Controllers
{
    public class DocController : ApiController
    {

        public IHttpActionResult userRegForm(UserRegistration dc)
        {
            DoctorsPatientsContext db = new DoctorsPatientsContext();
            db.userRegistration.Add(dc);
            
            db.SaveChanges();
            return Ok();
                
                
                
                
        }

    }
}
