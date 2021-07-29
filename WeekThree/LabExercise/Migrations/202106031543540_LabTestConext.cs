namespace LabExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LabTestConext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LabTestDues",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        patientName = c.String(),
                        dateTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LabTestDues");
        }
    }
}
