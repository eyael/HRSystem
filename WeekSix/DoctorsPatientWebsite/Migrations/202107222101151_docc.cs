namespace DoctorsPatientWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class docc : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Doctors", "UserID", "dbo.AspNetUsers");
            //DropIndex("dbo.Doctors", new[] { "UserID" });
            //DropPrimaryKey("dbo.AspNetUsers");
            //AlterColumn("dbo.Doctors", "UserID", c => c.String(maxLength: 128));
            //AlterColumn("dbo.AspNetUsers", "id", c => c.String(nullable: false, maxLength: 128));
            //AddPrimaryKey("dbo.AspNetUsers", "id");
            //CreateIndex("dbo.Doctors", "UserID");
            //AddForeignKey("dbo.Doctors", "UserID", "dbo.AspNetUsers", "id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Doctors", "UserID", "dbo.AspNetUsers");
            //DropIndex("dbo.Doctors", new[] { "UserID" });
            //DropPrimaryKey("dbo.AspNetUsers");
            //AlterColumn("dbo.AspNetUsers", "id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.Doctors", "UserID", c => c.Int(nullable: false));
            //AddPrimaryKey("dbo.AspNetUsers", "id");
            //CreateIndex("dbo.Doctors", "UserID");
            //AddForeignKey("dbo.Doctors", "UserID", "dbo.AspNetUsers", "id", cascadeDelete: true);
        }
    }
}
