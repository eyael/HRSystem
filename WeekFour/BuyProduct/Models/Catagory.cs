using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BuyProduct.Models
{
    public class Catagory
    {
        public int id { get; set; }

        public string name { get; set; }
        public string desc { get; set; }
        public string imagePath { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        [ForeignKey("categ")]
        public int categID { get; set; }
        public Catagory categ { get; set; }
        public string imagePath { get; set; }

        public bool check { get; set; }
    }

    public class Cart
    {
        public int id { get; set; }
        [ForeignKey("product")]

        public int? prodid { get; set; }

        public Catagory catagory { get; set; }
        public Product product { get; set; }
       
        [ForeignKey("catagory")]
        public int? categID { get; set; }
        
        public float qty { get; set; }
    }

    public class BuyProductContext : DbContext
    {
        public DbSet<Catagory> catagory { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Cart> cart { get; set; }
    }
}