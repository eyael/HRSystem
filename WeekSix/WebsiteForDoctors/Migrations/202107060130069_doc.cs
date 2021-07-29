namespace WebsiteForDoctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRegistrations", "BirthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.UserRegistrations", "age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserRegistrations", "age", c => c.String(nullable: false));
            DropColumn("dbo.UserRegistrations", "BirthDate");
        }
    }
}
