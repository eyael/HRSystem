namespace BuyProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        prodid = c.Int(nullable: false),
                        categID = c.Int(nullable: false),
                        qty = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        desc = c.String(),
                        imagePath = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        categID = c.Int(nullable: false),
                        imagePath = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Catagories", t => t.categID, cascadeDelete: true)
                .Index(t => t.categID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "categID", "dbo.Catagories");
            DropIndex("dbo.Products", new[] { "categID" });
            DropTable("dbo.Products");
            DropTable("dbo.Catagories");
            DropTable("dbo.Carts");
        }
    }
}
