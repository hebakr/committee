namespace Committes.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schoolcommittee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Committees", "LearningManagementId", "dbo.LearningManagements");
            DropIndex("dbo.Committees", new[] { "LearningManagementId" });
            RenameColumn(table: "dbo.Committees", name: "LearningManagementId", newName: "LearningManagement_Id");
            AddColumn("dbo.Committees", "SchoolId", c => c.Int());
            AlterColumn("dbo.Committees", "LearningManagement_Id", c => c.Int());
            CreateIndex("dbo.Committees", "SchoolId");
            CreateIndex("dbo.Committees", "LearningManagement_Id");
            AddForeignKey("dbo.Committees", "SchoolId", "dbo.Schools", "Id");
            AddForeignKey("dbo.Committees", "LearningManagement_Id", "dbo.LearningManagements", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Committees", "LearningManagement_Id", "dbo.LearningManagements");
            DropForeignKey("dbo.Committees", "SchoolId", "dbo.Schools");
            DropIndex("dbo.Committees", new[] { "LearningManagement_Id" });
            DropIndex("dbo.Committees", new[] { "SchoolId" });
            AlterColumn("dbo.Committees", "LearningManagement_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Committees", "SchoolId");
            RenameColumn(table: "dbo.Committees", name: "LearningManagement_Id", newName: "LearningManagementId");
            CreateIndex("dbo.Committees", "LearningManagementId");
            AddForeignKey("dbo.Committees", "LearningManagementId", "dbo.LearningManagements", "Id", cascadeDelete: true);
        }
    }
}
