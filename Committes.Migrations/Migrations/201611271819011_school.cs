namespace Committes.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class school : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 150),
                        LearningManagementId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LearningManagements", t => t.LearningManagementId)
                .Index(t => t.LearningManagementId);
            
            AddColumn("dbo.Members", "SchoolId", c => c.Int());
            CreateIndex("dbo.Members", "SchoolId");
            AddForeignKey("dbo.Members", "SchoolId", "dbo.Schools", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Schools", "LearningManagementId", "dbo.LearningManagements");
            DropIndex("dbo.Schools", new[] { "LearningManagementId" });
            DropIndex("dbo.Members", new[] { "SchoolId" });
            DropColumn("dbo.Members", "SchoolId");
            DropTable("dbo.Schools");
        }
    }
}
