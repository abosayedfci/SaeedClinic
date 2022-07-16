namespace SaeedClinick.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PatientDatas", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.PatientDatas", "LMB", c => c.String(nullable: false));
            AlterColumn("dbo.PatientDatas", "EDD", c => c.String(nullable: false));
            DropColumn("dbo.PatientDatas", "FileNum");
            DropColumn("dbo.PatientDatas", "RH");
            DropColumn("dbo.PatientDatas", "GPA");
            DropColumn("dbo.PatientDatas", "MedicalHistory");
            DropColumn("dbo.PatientDatas", "SurgicalHistory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PatientDatas", "SurgicalHistory", c => c.String());
            AddColumn("dbo.PatientDatas", "MedicalHistory", c => c.String());
            AddColumn("dbo.PatientDatas", "GPA", c => c.String());
            AddColumn("dbo.PatientDatas", "RH", c => c.String());
            AddColumn("dbo.PatientDatas", "FileNum", c => c.String());
            AlterColumn("dbo.PatientDatas", "EDD", c => c.String());
            AlterColumn("dbo.PatientDatas", "LMB", c => c.String());
            AlterColumn("dbo.PatientDatas", "Name", c => c.String());
        }
    }
}
