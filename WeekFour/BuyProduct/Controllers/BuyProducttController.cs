using BuyProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuyProduct.Controllers
{
    public class BuyProducttController : Controller
    {
        private BuyProductContext db = new BuyProductContext();
        // GET: BuyProductt
        public ActionResult Index()
        {
           //return View ( db.cart.Include("categID").Include("prodid").ToList());
            return View(db.catagory.ToList());
        }

        public ActionResult productList(int? id)
        {
            List<Product> plist = db.product.Where(x => x.categID == id).ToList();
            return View(plist);
        }

        public ActionResult buy(List<Product> productList )
        {
            foreach (Product prod in productList)
            {
                if (prod.check)
                {
                    Cart ct = new Cart();
                    ct.prodid = prod.id;
                    ct.categID = prod.categID;

                    db.cart.Add(ct);
                    db.SaveChanges();

                }
            }
                return RedirectToAction("productList");


            }

        public ActionResult count()
        {
            IList<Cart> cart = new List<Cart>();

            ViewBag.carts = cart.Count();

            return View();
        }




    }


    }
