using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteForDoctors.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Please enter your user name")]
        public string userName { get; set; }
        [Required, DataType(DataType.Password, ErrorMessage = "Please enter your user name"),]

        public string password { get; set; }

        public bool RememberMe { get; set; }
    }
}