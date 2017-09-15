namespace Committes.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delworkspaces : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "WorkPlaceId", "dbo.WorkPlaces");
            DropIndex("dbo.Members", new[] { "WorkPlaceId" });
            DropColumn("dbo.Members", "WorkPlaceId");
            DropTable("dbo.WorkPlaces");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WorkPlaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Members", "WorkPlaceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "WorkPlaceId");
            AddForeignKey("dbo.Members", "WorkPlaceId", "dbo.WorkPlaces", "Id", cascadeDelete: true);
        }
    }
}
