namespace DoctorsPatientWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Doc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        patientID = c.String(),
                        docID = c.Int(),
                        appointmentHour = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Doctors", t => t.docID)
                .Index(t => t.docID);
            
            CreateTable(
                "dbo.ConsultationSlots",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DocId = c.Int(nullable: false),
                        dow = c.Int(nullable: false),
                        startTime = c.Int(nullable: false),
                        endTime = c.Int(nullable: false),
                        interval = c.Int(nullable: false),
                        slots = c.String(),
                        Appointment_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Doctors", t => t.DocId, cascadeDelete: true)
                .ForeignKey("dbo.Appointments", t => t.Appointment_id)
                .Index(t => t.DocId)
                .Index(t => t.Appointment_id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        clinic = c.String(),
                        phoneNumber = c.String(),
                        specID = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Specialities", t => t.specID)
                .Index(t => t.specID);
            
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "docID", "dbo.Doctors");
            DropForeignKey("dbo.ConsultationSlots", "Appointment_id", "dbo.Appointments");
            DropForeignKey("dbo.ConsultationSlots", "DocId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "specID", "dbo.Specialities");
            DropIndex("dbo.Doctors", new[] { "specID" });
            DropIndex("dbo.ConsultationSlots", new[] { "Appointment_id" });
            DropIndex("dbo.ConsultationSlots", new[] { "DocId" });
            DropIndex("dbo.Appointments", new[] { "docID" });
            DropTable("dbo.Specialities");
            DropTable("dbo.Doctors");
            DropTable("dbo.ConsultationSlots");
            DropTable("dbo.Appointments");
        }
    }
}
