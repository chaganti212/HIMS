namespace MVC_Hims_V1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateappointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "PatName", c => c.String());
            AddColumn("dbo.Appointments", "DoctorId", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "OptStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Appointments", "PatId", c => c.Int(nullable: false));
            DropColumn("dbo.Appointments", "StaffId");
            DropColumn("dbo.Appointments", "PDignosisnum");
            DropColumn("dbo.Appointments", "Dignosis");
            DropColumn("dbo.Appointments", "DateofOpt");
            DropColumn("dbo.Appointments", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "DateofOpt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "Dignosis", c => c.String());
            AddColumn("dbo.Appointments", "PDignosisnum", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "StaffId", c => c.Int(nullable: false));
            AlterColumn("dbo.Appointments", "PatId", c => c.String());
            DropColumn("dbo.Appointments", "OptStart");
            DropColumn("dbo.Appointments", "DoctorId");
            DropColumn("dbo.Appointments", "PatName");
        }
    }
}
