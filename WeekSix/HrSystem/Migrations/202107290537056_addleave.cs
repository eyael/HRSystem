namespace HrSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addleave : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeaveRequests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Catagory = c.String(),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LeaveRequests");
        }
    }
}
