namespace MVC_Hims_V1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddoctor10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "DoctorName1", c => c.String());
            DropColumn("dbo.Appointments", "DoctorName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "DoctorName", c => c.String());
            DropColumn("dbo.Appointments", "DoctorName1");
        }
    }
}
