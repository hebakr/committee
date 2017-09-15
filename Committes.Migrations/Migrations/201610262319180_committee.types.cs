namespace Committes.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class committeetypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Committees", "CommitteType", c => c.String(maxLength: 50));
            AddColumn("dbo.Committees", "LearningType", c => c.String(maxLength: 50));
            AddColumn("dbo.Members", "MeetingDate", c => c.String(maxLength: 50));
            DropColumn("dbo.Committees", "MeetingDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Committees", "MeetingDate", c => c.String(maxLength: 50));
            DropColumn("dbo.Members", "MeetingDate");
            DropColumn("dbo.Committees", "LearningType");
            DropColumn("dbo.Committees", "CommitteType");
        }
    }
}
