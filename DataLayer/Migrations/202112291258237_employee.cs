namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeModals",
                c => new
                    {
                        empId = c.Int(nullable: false, identity: true),
                        ename = c.String(),
                        eage = c.Int(nullable: false),
                        esal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.empId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeModals");
        }
    }
}
