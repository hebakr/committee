namespace Committes.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class membersphone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Phone", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Phone");
        }
    }
}
