using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HrSystem.Models;

namespace HrSystem.Controllers
{
    public class LeaveRequestsController : Controller
    {
        private HrSystemContext db = new HrSystemContext();

        // GET: LeaveRequests
        public ActionResult Index()
        {
            return View(db.leaveReq.ToList());
        }

        // GET: LeaveRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveRequest leaveRequest = db.leaveReq.Find(id);
            if (leaveRequest == null)
            {
                return HttpNotFound();
            }
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Date,Catagory,Reason")] LeaveRequest leaveRequest)
        {
            if (ModelState.IsValid)
            {
                db.leaveReq.Add(leaveRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leaveRequest);
        }

        // GET: LeaveRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveRequest leaveRequest = db.leaveReq.Find(id);
            if (leaveRequest == null)
            {
                return HttpNotFound();
            }
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Date,Catagory,Reason")] LeaveRequest leaveRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveRequest leaveRequest = db.leaveReq.Find(id);
            if (leaveRequest == null)
            {
                return HttpNotFound();
            }
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveRequest leaveRequest = db.leaveReq.Find(id);
            db.leaveReq.Remove(leaveRequest);
            db.SaveChanges();
            return RedirectToAction("Index");
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
