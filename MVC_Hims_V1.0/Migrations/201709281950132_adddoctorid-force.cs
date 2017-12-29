namespace MVC_Hims_V1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddoctoridforce : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "DoctorName", c => c.String());
            DropColumn("dbo.Appointments", "DoctorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "DoctorId", c => c.Int(nullable: false));
            DropColumn("dbo.Appointments", "DoctorName");
        }
    }
}
