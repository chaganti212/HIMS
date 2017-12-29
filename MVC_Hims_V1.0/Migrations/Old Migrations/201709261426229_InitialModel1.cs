namespace MVC_Hims_V1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "UserId", c => c.String());
            AddColumn("dbo.Patients", "Password", c => c.String());
            AddColumn("dbo.Staffs", "SUserId", c => c.String());
            AddColumn("dbo.Staffs", "SPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staffs", "SPassword");
            DropColumn("dbo.Staffs", "SUserId");
            DropColumn("dbo.Patients", "Password");
            DropColumn("dbo.Patients", "UserId");
        }
    }
}
