using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HrSystem.Models
{
    public class Attendance
    {
        public int id { get; set; }
     
        public bool isPresent  { get; set; }
        public DateTime checkedIn { get; set; }
        public DateTime Date { get; set; }
        public int SerialNum { get; set; }
    }

    public class LeaveRequest

    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public string Catagory { get; set; }
        public string Reason { get; set; }

    }

    public class LoanRequest
    {
        public int id { get; set; }
        public double loanAmount { get; set; }
        public string Reason { get; set; }
    }

    public class HrSystemContext : DbContext
    {
        public DbSet<Attendance> attendances { get; set; }

        public DbSet <LeaveRequest> leaveReq{ get; set; }

        public DbSet<LoanRequest>  loanReq{ get; set; }
    }

    }