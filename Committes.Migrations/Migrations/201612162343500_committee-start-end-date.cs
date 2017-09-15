namespace Committes.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class committeestartenddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Committees", "ChiefStartDate", c => c.DateTime());
            AddColumn("dbo.Committees", "ChiefEndDate", c => c.DateTime());
            AddColumn("dbo.Committees", "SuperInspectorStartDate", c => c.DateTime());
            AddColumn("dbo.Committees", "SuperInspectorEndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Committees", "SuperInspectorEndDate");
            DropColumn("dbo.Committees", "SuperInspectorStartDate");
            DropColumn("dbo.Committees", "ChiefEndDate");
            DropColumn("dbo.Committees", "ChiefStartDate");
        }
    }
}
