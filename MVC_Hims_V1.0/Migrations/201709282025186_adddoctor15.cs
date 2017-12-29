namespace MVC_Hims_V1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddoctor15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(),
                    })
                .PrimaryKey(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Doctors");
        }
    }
}
