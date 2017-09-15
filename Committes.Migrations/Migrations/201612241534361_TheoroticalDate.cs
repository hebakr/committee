namespace Committes.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TheoroticalDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "TheoroticalDate", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "TheoroticalDate");
        }
    }
}
