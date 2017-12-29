namespace MVC_Hims_V1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvaluesintopatients : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Patients (PName,PAddress,PPhone,PEmail,PGender,PDignosisNum,PDob,StaffId,UserId,Password) VALUES ('Sam','50 Cragwood', '1234567890','abc@xyz.com','Male',2001, '08/28/2000', 1001, 'sam123', 'sam123')");
            Sql("INSERT INTO Patients (PName,PAddress,PPhone,PEmail,PGender,PDignosisNum,PDob,StaffId,UserId,Password) VALUES ('Andy','50 Cragwood', '0987654321','aaa@xyz.com','Male',2002, '03/28/1983', 1002, 'andy123', 'andy123')");
            Sql("INSERT INTO Patients (PName,PAddress,PPhone,PEmail,PGender,PDignosisNum,PDob,StaffId,UserId,Password) VALUES ('Steve','1217 Kerwin St', '9999999999','steve@xyz.com','Male',2003, '12/12/1992', 1003, 'steve123', 'steve123')");
        }
        
        public override void Down()
        {
        }
    }
}
