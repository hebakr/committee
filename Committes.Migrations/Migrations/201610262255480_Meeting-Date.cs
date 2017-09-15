namespace Committes.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeetingDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Committees", "MeetingDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Committees", "MeetingDate");
        }
    }
}
