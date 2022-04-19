namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class project : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectModals",
                c => new
                    {
                        projId = c.Int(nullable: false, identity: true),
                        pname = c.String(),
                        pdetail = c.String(),
                        pdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.projId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProjectModals");
        }
    }
}
