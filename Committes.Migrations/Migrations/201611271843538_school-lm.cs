namespace Committes.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schoollm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Committees", "LearningManagement_Id", "dbo.LearningManagements");
            DropIndex("dbo.Committees", new[] { "LearningManagement_Id" });
            DropColumn("dbo.Committees", "LearningManagement_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Committees", "LearningManagement_Id", c => c.Int());
            CreateIndex("dbo.Committees", "LearningManagement_Id");
            AddForeignKey("dbo.Committees", "LearningManagement_Id", "dbo.LearningManagements", "Id");
        }
    }
}
