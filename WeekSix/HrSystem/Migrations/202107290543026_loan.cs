namespace HrSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoanRequests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        loanAmount = c.Double(nullable: false),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoanRequests");
        }
    }
}
