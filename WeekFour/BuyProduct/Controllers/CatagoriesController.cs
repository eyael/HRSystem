using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BuyProduct.Models;

namespace BuyProduct.Controllers
{
    public class CatagoriesController : Controller
    {
        private BuyProductContext db = new BuyProductContext();

        // GET: Catagories
        public ActionResult Index()
        {
            return View(db.catagory.ToList());
        }

        // GET: Catagories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catagory catagory = db.catagory.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        // GET: Catagories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catagories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //public ActionResult Create([Bind(Include = "id,name,desc")] Catagory catagory)
        public ActionResult Create(Catagory catagory, HttpPostedFileBase[] imagePath)
        {

            // Crud cr = new Crud();
            if (ModelState.IsValid)
            {
                foreach (HttpPostedFileBase file in imagePath)
                {
                    try
                    {
                        int count = file.ContentLength;
                    }
                    catch
                    {
                        catagory.imagePath = "Images/no image.png";
                    }
                    int MaxContentLength = 512 * 512 * 1; //0.5 MB
                    string[] AllowedFileExtensions = new string[] { ".jpg", ".txt", ".gif", ".png", ".pdf" };

                    if (imagePath == null)
                    {
                        //ModelState.AddModelError("File", "Please Upload Your file");
                        //ViewBag.message = "Please pick a file for upload!";
                        catagory.imagePath = "Image/no image.png";
                    }
                    else if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Please use file of type: " + string.Join(", ", AllowedFileExtensions));
                        TempData["Message"] = "Wrong file Type";
                        return RedirectToAction("index");
                    }

                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + 512 + " KB");
                        TempData["Message"] = "Your file is too large, maximum allowed size is: " + 512 + " KB";
                        return RedirectToAction("index");
                    }
                    else
                    {
                        var filename = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/"), filename);
                        file.SaveAs(path);
                        catagory.imagePath = "/Image/" + filename;
                    }
                     db.catagory.Add(catagory);
                    db.SaveChanges();
                  //  TempData["msg"] = cr.CatagoryInsert(catagory);
                }
                return RedirectToAction("Index");
            }

            return View(catagory);
        }


        // GET: Catagories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catagory catagory = db.catagory.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        // POST: Catagories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,desc,imagePath")] Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catagory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catagory);
        }

        // GET: Catagories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catagory catagory = db.catagory.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        // POST: Catagories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catagory catagory = db.catagory.Find(id);
            db.catagory.Remove(catagory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult fetchName(string name)
        {
            List<Catagory> clist=db.catagory.Where(x => x.name.Contains(name)).ToList();
            var msg = "";
            foreach (Catagory cr in clist)
            {
                msg += cr.name + "\n";
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
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
