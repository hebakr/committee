namespace Committes.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentCountint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Committees", "StudentCount", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Committees", "StudentCount", c => c.String());
        }
    }
}
