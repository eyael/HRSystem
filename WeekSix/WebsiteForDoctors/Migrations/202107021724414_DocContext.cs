namespace WebsiteForDoctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocContext : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "date", c => c.String());
        }
    }
}
