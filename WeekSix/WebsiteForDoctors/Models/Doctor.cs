 using System;
 using System.Collections.Generic;
 using System.ComponentModel.DataAnnotations;
 using System.ComponentModel.DataAnnotations.Schema;
 using System.Data.Entity;
 using System.Globalization;
 using System.Linq;
 using System.Web;


namespace WebsiteForDoctors.Models
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
        [Display(Name = "Specialization")]
        public Spec spec { get; set; }
    }


    public enum Spec
    {
        Dentist = 1,
        Opthamologist = 2,
        Medical = 3,
        Dermathologist = 4
       

    }

    public class Patient
    {
        public int id { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Phone Number")]
        public string mobile { get; set; }
        [Display(Name = "Past Allergies")]
        public string pastAllergies { get; set; }
        public string Disease { get; set; }
       
    }



    public class ConsultationSlot
    {
        public int id { get; set; }

        [ForeignKey("doctor")]
        public int DocId { get; set; }
        public Doctor doctor { get; set; }

        [Display(Name = "Date") ]
        public DOW dow { get; set; }

        public  int startTime { get; set; }
        public int endTime { get; set; }
        public int interval { get; set; }
        // public time dateTime { get; set; }

   

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
        [ForeignKey("consultationSlot")]
        public int consultSlotID { get; set; }

        public ConsultationSlot consultationSlot { get; set; }

        [Display(Name = "Make an Appointment")]
        [DataType(DataType.Date)]
        public DateTime  date { get; set; }


        [ForeignKey("patient")]
        public int patientID { get; set; }

        public Patient patient { get; set; }

        public ICollection<ConsultationSlot> ConsultationSlots { get; set; }

    }

  


    public class Role
    {
     
        public int id { get; set; }
        public string name { get; set; }
    }

    public class UserRole
    {
        [ForeignKey("userRegistration"),   Key,Column(Order =1)]
        public string userID { get; set; }

        public UserRegistration userRegistration { get; set; }

        [ForeignKey("role"), Key, Column(Order = 2)]
        public int roleID { get; set; }

        public Role role { get; set; }
    }



    public class DoctorsPatientsContext : DbContext
    {



        public DbSet<Doctor> doctors { get; set; }
      
        public DbSet<Patient> patients { get; set; }
        public DbSet<UserRegistration> userRegistration { get; set; }
        public DbSet<ConsultationSlot> consultationSlot { get; set; }
        public DbSet<UserRole> userRole { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<Appointment> appointment { get; set; }

    }
}
