namespace Committes.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startover3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Committees", "SchoolYear", c => c.String());
            AddColumn("dbo.Committees", "Term", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Committees", "Term");
            DropColumn("dbo.Committees", "SchoolYear");
        }
    }
}
