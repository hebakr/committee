namespace Committes.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schoolName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommitteeDivisions", "SchoolName", c => c.String(maxLength: 500));
            AddColumn("dbo.CommitteeLabs", "SchoolName", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommitteeLabs", "SchoolName");
            DropColumn("dbo.CommitteeDivisions", "SchoolName");
        }
    }
}
