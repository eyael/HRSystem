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
    public class ProductsController : Controller
    {
        private BuyProductContext db = new BuyProductContext();

        // GET: Products
        public ActionResult Index()
        {
            var product = db.product.Include(p => p.categ);
            return View(product.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.categID = new SelectList(db.catagory, "id", "name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //public ActionResult Create([Bind(Include = "id,name,desc")] Product product)
        public ActionResult Create(Product product, HttpPostedFileBase[] imagePath)
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
                        product.imagePath = "Image/no image.png";
                    }
                    int MaxContentLength = 512 * 512 * 1; //0.5 MB
                    string[] AllowedFileExtensions = new string[] { ".jpg", ".txt", ".gif", ".png", ".pdf" };

                    if (imagePath == null)
                    {
                        //ModelState.AddModelError("File", "Please Upload Your file");
                        //ViewBag.message = "Please pick a file for upload!";
                        product.imagePath = "Image/no image.png";
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
                        product.imagePath = "/Image/" + filename;
                    }
                     db.product.Add(product);
                    db.SaveChanges();
                    
                }
                return RedirectToAction("Index");
            }

            return View(product);
        }


        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.categID = new SelectList(db.catagory, "id", "name", product.categID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,categID,imagePath")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categID = new SelectList(db.catagory, "id", "name", product.categID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.product.Find(id);
            db.product.Remove(product);
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
