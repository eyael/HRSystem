using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteForDoctors.Models
{
    public class UserRegistration
    {

        [Required, MinLength(5), Display(Name = "Enter your name")]
        public string userName { get; set; }
        [MinLength(5), Required, DataType(DataType.Password), Display(Name = "Enter your Password")]
        public string password { get; set; }
        [Compare("password"), DataType(DataType.Password)]

        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        [EmailAddress, Required, Display(Name = "Enter your Email"), Key]
        public string email { get; set; }

        public DateTime BirthDate { get; set; }

        //  [Required, MinLength(2), Display(Name = "Enter your Age")]
        //  public string age { get; set; }
        [Required, Display(Name = "Gender")]
        public string gender { get; set; }
        [Required, Display(Name = "Enter your Date of Birth")]
        public DateTime dob { get; set; }

        [Required, Display(Name = "Enter your Adress")]
        public string address { get; set; }

        [Required, Display(Name = "Enter your Account Type")]
        public string accountType { get; set; }

        [Required,  Display(Name = "Enter your Age")]
        public int Age
        {
            get
            {
                var now = DateTime.Today;
                var age = now.Year - BirthDate.Year;
                if (BirthDate > now.AddYears(-age)) age--;
                return age;
            }

        }
    }
}