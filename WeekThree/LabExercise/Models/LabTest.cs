using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LabExercise.Models
{
    public class LabTest
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool check { get; set; }
    }

    public class LabTestDue
    {
        public int id { get; set; }
        public int labTestID { get; set; }
        public string patientName { get; set; }

        public DateTime? dateTimeStamp { get; set; }
       

    }

    public class LabTestContext : DbContext
    {
        public DbSet<LabTest> labTest { get; set; }
        public DbSet<LabTestDue> labTestDue { get; set; }
    }
}