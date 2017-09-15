namespace Committes.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startover2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schools", "LearningManagementId", "dbo.LearningManagements");
            DropForeignKey("dbo.Committees", "LearningManagement_Id", "dbo.LearningManagements");
            DropIndex("dbo.Committees", new[] { "LearningManagement_Id" });
            DropIndex("dbo.Schools", new[] { "LearningManagementId" });
            RenameColumn(table: "dbo.Committees", name: "LearningManagement_Id", newName: "LearningManagementId");
            AlterColumn("dbo.Committees", "LearningManagementId", c => c.Int(nullable: false));
            CreateIndex("dbo.Committees", "LearningManagementId");
            AddForeignKey("dbo.Committees", "LearningManagementId", "dbo.LearningManagements", "Id", cascadeDelete: true);
            DropColumn("dbo.Committees", "SchoolId");
            DropTable("dbo.Schools");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Number = c.String(nullable: false),
                        StudentCount = c.Int(nullable: false),
                        Address = c.String(),
                        Phone = c.String(),
                        LearningManagementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Committees", "SchoolId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Committees", "LearningManagementId", "dbo.LearningManagements");
            DropIndex("dbo.Committees", new[] { "LearningManagementId" });
            AlterColumn("dbo.Committees", "LearningManagementId", c => c.Int());
            RenameColumn(table: "dbo.Committees", name: "LearningManagementId", newName: "LearningManagement_Id");
            CreateIndex("dbo.Schools", "LearningManagementId");
            CreateIndex("dbo.Committees", "LearningManagement_Id");
            AddForeignKey("dbo.Committees", "LearningManagement_Id", "dbo.LearningManagements", "Id");
            AddForeignKey("dbo.Schools", "LearningManagementId", "dbo.LearningManagements", "Id", cascadeDelete: true);
        }
    }
}
