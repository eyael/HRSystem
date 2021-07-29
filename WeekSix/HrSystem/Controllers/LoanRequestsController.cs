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
    public class LoanRequestsController : Controller
    {
        private HrSystemContext db = new HrSystemContext();

        // GET: LoanRequests
        public ActionResult Index()
        {
            return View(db.loanReq.ToList());
        }

        // GET: LoanRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanRequest loanRequest = db.loanReq.Find(id);
            if (loanRequest == null)
            {
                return HttpNotFound();
            }
            return View(loanRequest);
        }

        // GET: LoanRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,loanAmount,Reason")] LoanRequest loanRequest)
        {
            if (ModelState.IsValid)
            {
                db.loanReq.Add(loanRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loanRequest);
        }

        // GET: LoanRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanRequest loanRequest = db.loanReq.Find(id);
            if (loanRequest == null)
            {
                return HttpNotFound();
            }
            return View(loanRequest);
        }

        // POST: LoanRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,loanAmount,Reason")] LoanRequest loanRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loanRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loanRequest);
        }

        // GET: LoanRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanRequest loanRequest = db.loanReq.Find(id);
            if (loanRequest == null)
            {
                return HttpNotFound();
            }
            return View(loanRequest);
        }

        // POST: LoanRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoanRequest loanRequest = db.loanReq.Find(id);
            db.loanReq.Remove(loanRequest);
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
