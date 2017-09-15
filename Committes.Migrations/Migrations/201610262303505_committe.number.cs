namespace Committes.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class committenumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Committees", "Name", c => c.String(maxLength: 150));
            AlterColumn("dbo.Committees", "Number", c => c.Int(nullable: false));
            AlterColumn("dbo.Committees", "Phone", c => c.String(maxLength: 20));
            AlterColumn("dbo.Committees", "Address", c => c.String(maxLength: 500));
            AlterColumn("dbo.Committees", "SchoolYear", c => c.String(maxLength: 50));
            AlterColumn("dbo.Committees", "Term", c => c.String(maxLength: 50));
            AlterColumn("dbo.Committees", "DoctorName", c => c.String(maxLength: 150));
            AlterColumn("dbo.Committees", "DoctorStartDate", c => c.String(maxLength: 50));
            AlterColumn("dbo.Committees", "MeetingDate", c => c.String(maxLength: 50));
            AlterColumn("dbo.Members", "Name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Members", "StartDate", c => c.String(maxLength: 50));
            AlterColumn("dbo.Members", "EndDate", c => c.String(maxLength: 50));
            AlterColumn("dbo.Members", "EvaluationDate", c => c.String(maxLength: 50));
            AlterColumn("dbo.CommitteeDivisions", "Title", c => c.String(maxLength: 150));
            AlterColumn("dbo.CommitteeDivisions", "StudentCount", c => c.String(maxLength: 10));
            AlterColumn("dbo.CommitteeDivisions", "StudentType", c => c.String(maxLength: 50));
            AlterColumn("dbo.CommitteeDivisions", "ExamDate", c => c.String(maxLength: 50));
            AlterColumn("dbo.CommitteeDivisions", "EvalDate", c => c.String(maxLength: 50));
            AlterColumn("dbo.CommitteeDivisions", "WorkShopCount", c => c.String(maxLength: 10));
            AlterColumn("dbo.CommitteeDivisions", "WorkShopCapacity", c => c.String(maxLength: 10));
            AlterColumn("dbo.CommitteeDivisions", "GroupsCount", c => c.String(maxLength: 10));
            AlterColumn("dbo.Jobs", "Title", c => c.String(maxLength: 150));
            AlterColumn("dbo.CommitteeLabs", "Title", c => c.String(maxLength: 150));
            AlterColumn("dbo.CommitteeLabs", "StudentCount", c => c.String(maxLength: 10));
            AlterColumn("dbo.CommitteeLabs", "StudentType", c => c.String(maxLength: 50));
            AlterColumn("dbo.CommitteeLabs", "ExamDate", c => c.String(maxLength: 50));
            AlterColumn("dbo.CommitteeLabs", "EvalDate", c => c.String(maxLength: 50));
            AlterColumn("dbo.CommitteRoles", "Title", c => c.String(maxLength: 150));
            AlterColumn("dbo.Specialities", "Name", c => c.String(maxLength: 150));
            AlterColumn("dbo.WorkPlaces", "Title", c => c.String(maxLength: 150));
            AlterColumn("dbo.LearningManagements", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Governrates", "Title", c => c.String(maxLength: 150));
            AlterColumn("dbo.Sectors", "Title", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sectors", "Title", c => c.String());
            AlterColumn("dbo.Governrates", "Title", c => c.String());
            AlterColumn("dbo.LearningManagements", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.WorkPlaces", "Title", c => c.String());
            AlterColumn("dbo.Specialities", "Name", c => c.String());
            AlterColumn("dbo.CommitteRoles", "Title", c => c.String());
            AlterColumn("dbo.CommitteeLabs", "EvalDate", c => c.String());
            AlterColumn("dbo.CommitteeLabs", "ExamDate", c => c.String());
            AlterColumn("dbo.CommitteeLabs", "StudentType", c => c.String());
            AlterColumn("dbo.CommitteeLabs", "StudentCount", c => c.String());
            AlterColumn("dbo.CommitteeLabs", "Title", c => c.String());
            AlterColumn("dbo.Jobs", "Title", c => c.String());
            AlterColumn("dbo.CommitteeDivisions", "GroupsCount", c => c.String());
            AlterColumn("dbo.CommitteeDivisions", "WorkShopCapacity", c => c.String());
            AlterColumn("dbo.CommitteeDivisions", "WorkShopCount", c => c.String());
            AlterColumn("dbo.CommitteeDivisions", "EvalDate", c => c.String());
            AlterColumn("dbo.CommitteeDivisions", "ExamDate", c => c.String());
            AlterColumn("dbo.CommitteeDivisions", "StudentType", c => c.String());
            AlterColumn("dbo.CommitteeDivisions", "StudentCount", c => c.String());
            AlterColumn("dbo.CommitteeDivisions", "Title", c => c.String());
            AlterColumn("dbo.Members", "EvaluationDate", c => c.String());
            AlterColumn("dbo.Members", "EndDate", c => c.String());
            AlterColumn("dbo.Members", "StartDate", c => c.String());
            AlterColumn("dbo.Members", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Committees", "MeetingDate", c => c.String());
            AlterColumn("dbo.Committees", "DoctorStartDate", c => c.String());
            AlterColumn("dbo.Committees", "DoctorName", c => c.String());
            AlterColumn("dbo.Committees", "Term", c => c.String());
            AlterColumn("dbo.Committees", "SchoolYear", c => c.String());
            AlterColumn("dbo.Committees", "Address", c => c.String());
            AlterColumn("dbo.Committees", "Phone", c => c.String());
            AlterColumn("dbo.Committees", "Number", c => c.String());
            AlterColumn("dbo.Committees", "Name", c => c.String());
        }
    }
}
