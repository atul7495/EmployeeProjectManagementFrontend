namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectAssigns",
                c => new
                    {
                        ProjAssignId = c.Int(nullable: false, identity: true),
                        RefEmpId = c.Int(nullable: false),
                        RefProjId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjAssignId)
                .ForeignKey("dbo.EmployeeModals", t => t.RefEmpId, cascadeDelete: true)
                .ForeignKey("dbo.ProjectModals", t => t.RefProjId, cascadeDelete: true)
                .Index(t => t.RefEmpId)
                .Index(t => t.RefProjId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectAssigns", "RefProjId", "dbo.ProjectModals");
            DropForeignKey("dbo.ProjectAssigns", "RefEmpId", "dbo.EmployeeModals");
            DropIndex("dbo.ProjectAssigns", new[] { "RefProjId" });
            DropIndex("dbo.ProjectAssigns", new[] { "RefEmpId" });
            DropTable("dbo.ProjectAssigns");
        }
    }
}
