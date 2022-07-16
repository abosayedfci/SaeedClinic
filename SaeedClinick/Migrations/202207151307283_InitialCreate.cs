namespace SaeedClinick.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LK_Labs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LabTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VisitLabs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LabId = c.Int(nullable: false),
                        VisitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LK_Labs", t => t.LabId, cascadeDelete: true)
                .ForeignKey("dbo.Visits", t => t.VisitId, cascadeDelete: true)
                .Index(t => t.LabId)
                .Index(t => t.VisitId);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VisitNum = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        NextVisitDate = c.DateTime(),
                        BP = c.String(),
                        LL = c.String(),
                        Weight = c.Double(),
                        Complain = c.String(),
                        Others = c.String(),
                        PatientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientDatas", t => t.PatientID, cascadeDelete: true)
                .Index(t => t.PatientID);
            
            CreateTable(
                "dbo.PatientDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        FileNum = c.String(),
                        TelephoneNum = c.String(),
                        Address = c.String(),
                        Marrid = c.String(),
                        RH = c.String(),
                        LMB = c.String(),
                        EDD = c.String(),
                        GPA = c.String(),
                        Others = c.String(),
                        MedicalHistory = c.String(),
                        SurgicalHistory = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VisitTreatments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TreatmentId = c.Int(nullable: false),
                        VisitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LK_Treatment", t => t.TreatmentId, cascadeDelete: true)
                .ForeignKey("dbo.Visits", t => t.VisitId, cascadeDelete: true)
                .Index(t => t.TreatmentId)
                .Index(t => t.VisitId);
            
            CreateTable(
                "dbo.LK_Treatment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TreatmentTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VisitUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        USId = c.Int(nullable: false),
                        VisitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LK_US", t => t.USId, cascadeDelete: true)
                .ForeignKey("dbo.Visits", t => t.VisitId, cascadeDelete: true)
                .Index(t => t.USId)
                .Index(t => t.VisitId);
            
            CreateTable(
                "dbo.LK_US",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VisitLabs", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.VisitUs", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.VisitUs", "USId", "dbo.LK_US");
            DropForeignKey("dbo.VisitTreatments", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.VisitTreatments", "TreatmentId", "dbo.LK_Treatment");
            DropForeignKey("dbo.Visits", "PatientID", "dbo.PatientDatas");
            DropForeignKey("dbo.VisitLabs", "LabId", "dbo.LK_Labs");
            DropIndex("dbo.VisitUs", new[] { "VisitId" });
            DropIndex("dbo.VisitUs", new[] { "USId" });
            DropIndex("dbo.VisitTreatments", new[] { "VisitId" });
            DropIndex("dbo.VisitTreatments", new[] { "TreatmentId" });
            DropIndex("dbo.Visits", new[] { "PatientID" });
            DropIndex("dbo.VisitLabs", new[] { "VisitId" });
            DropIndex("dbo.VisitLabs", new[] { "LabId" });
            DropTable("dbo.LK_US");
            DropTable("dbo.VisitUs");
            DropTable("dbo.LK_Treatment");
            DropTable("dbo.VisitTreatments");
            DropTable("dbo.PatientDatas");
            DropTable("dbo.Visits");
            DropTable("dbo.VisitLabs");
            DropTable("dbo.LK_Labs");
        }
    }
}
