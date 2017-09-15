namespace Committes.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maxlengthstudenttype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CommitteeDivisions", "StudentType", c => c.String(maxLength: 250));
            AlterColumn("dbo.CommitteeLabs", "StudentType", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CommitteeLabs", "StudentType", c => c.String(maxLength: 50));
            AlterColumn("dbo.CommitteeDivisions", "StudentType", c => c.String(maxLength: 50));
        }
    }
}
