namespace HrSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Attendances", "attendance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "attendance", c => c.String());
        }
    }
}
