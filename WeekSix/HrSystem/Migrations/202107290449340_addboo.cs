namespace HrSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addboo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "isPresent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendances", "isPresent");
        }
    }
}
