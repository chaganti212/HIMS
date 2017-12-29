namespace MVC_Hims_V1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddoctorid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "DoctorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "DoctorId");
        }
    }
}
