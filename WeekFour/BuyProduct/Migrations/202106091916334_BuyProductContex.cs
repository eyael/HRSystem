namespace BuyProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyProductContex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Carts", "prodid");
            CreateIndex("dbo.Carts", "categID");
            AddForeignKey("dbo.Carts", "categID", "dbo.Catagories", "id", cascadeDelete: false);
            AddForeignKey("dbo.Carts", "prodid", "dbo.Products", "id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "prodid", "dbo.Products");
            DropForeignKey("dbo.Carts", "categID", "dbo.Catagories");
            DropIndex("dbo.Carts", new[] { "categID" });
            DropIndex("dbo.Carts", new[] { "prodid" });
        }
    }
}
