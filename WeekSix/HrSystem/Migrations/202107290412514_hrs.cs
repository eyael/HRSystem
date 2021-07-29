namespace HrSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hrs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "SerialNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendances", "SerialNum");
        }
    }
}
