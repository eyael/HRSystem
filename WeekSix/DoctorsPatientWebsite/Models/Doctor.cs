using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoctorsPatientWebsite.Models
{
    public class Doctor
    {
        public int id { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Clinic")]
        public string clinic { get; set; }
        [Display(Name = "Phone Number")]
        public string phoneNumber { get; set; }
        //add asp.user as foreign key

        [ForeignKey("speciality"), Display(Name = "Specialization")]
        public int? specID { get; set; }
        public Speciality speciality { get; set; }

        [ForeignKey("user")]
        public string UserID { get; set; }

        public virtual AspNetUsers user { get; set; }

    }

     [Table("AspNetUsers")]

    //[NotMapped]
    public class AspNetUsers
    {
        public string id { get; set; }
        public string userName { get; set; }


    }
       
    // create asp.user model
    public class Speciality
{
        public int id { get; set; }
        public string name { get; set; }
    }



public class ConsultationSlot
{
    public int id { get; set; }

    [ForeignKey("doctor")]
    public int DocId { get; set; }
    public Doctor doctor { get; set; }

    [Display(Name = "Date")]
    public DOW dow { get; set; }

    public int startTime { get; set; }
    public int endTime { get; set; }
    public int interval { get; set; }
     public string slots { get; set; }



    }

public enum DOW
{
    SUN = 1,
    MON = 2,
    TUE = 3,
    WED = 4,
    THUR = 5,
    FRI = 6,
    SAT = 7

}
public class Appointment
{
    public int id { get; set; }
    

    [Display(Name = "Make an Appointment")]
    [DataType(DataType.Date)]
    public DateTime date { get; set; }
   
    public string patientID { get; set; }

     [ForeignKey("doctor")]
     public int? docID { get; set; }

     public Doctor doctor { get; set; }

     public string appointmentHour { get; set; }

     public ICollection<ConsultationSlot> ConsultationSlots { get; set; }

}



public class DoctorsContext : DbContext
{

        public DbSet<AspNetUsers> userlist { get; set; }

        public DbSet<Doctor> doctors { get; set; }


    public DbSet<ConsultationSlot> consultationSlot { get; set; }
 
    public DbSet<Appointment> appointment { get; set; }
        public DbSet<Speciality> speciality { get; set; }

    }
}