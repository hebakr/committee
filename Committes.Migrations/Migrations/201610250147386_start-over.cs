namespace Committes.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startover : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Committees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        StudentCount = c.String(),
                        SchoolId = c.Int(nullable: false),
                        DoctorName = c.String(),
                        DoctorStartDate = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Chief_Id = c.Int(),
                        LearningManagement_Id = c.Int(),
                        SuperInspector_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Chief_Id)
                .ForeignKey("dbo.LearningManagements", t => t.LearningManagement_Id)
                .ForeignKey("dbo.Members", t => t.SuperInspector_Id)
                .Index(t => t.Chief_Id)
                .Index(t => t.LearningManagement_Id)
                .Index(t => t.SuperInspector_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        JobId = c.Int(nullable: false),
                        WorkPlaceId = c.Int(nullable: false),
                        SpecialityId = c.Int(),
                        StartDate = c.String(),
                        EndDate = c.String(),
                        EvaluationDate = c.String(),
                        CommitteRoleId = c.Int(),
                        Theorotical = c.Boolean(nullable: false),
                        CommitteeLabId = c.Int(),
                        CommitteeDivisionId = c.Int(),
                        CommitteeId = c.Int(),
                        Committee_Id = c.Int(),
                        Committee_Id1 = c.Int(),
                        Committee_Id2 = c.Int(),
                        Committee_Id3 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Committees", t => t.CommitteeId)
                .ForeignKey("dbo.CommitteeDivisions", t => t.CommitteeDivisionId)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.CommitteeLabs", t => t.CommitteeLabId)
                .ForeignKey("dbo.CommitteRoles", t => t.CommitteRoleId)
                .ForeignKey("dbo.Specialities", t => t.SpecialityId)
                .ForeignKey("dbo.WorkPlaces", t => t.WorkPlaceId, cascadeDelete: true)
                .ForeignKey("dbo.Committees", t => t.Committee_Id)
                .ForeignKey("dbo.Committees", t => t.Committee_Id1)
                .ForeignKey("dbo.Committees", t => t.Committee_Id2)
                .ForeignKey("dbo.Committees", t => t.Committee_Id3)
                .Index(t => t.JobId)
                .Index(t => t.WorkPlaceId)
                .Index(t => t.SpecialityId)
                .Index(t => t.CommitteRoleId)
                .Index(t => t.CommitteeLabId)
                .Index(t => t.CommitteeDivisionId)
                .Index(t => t.CommitteeId)
                .Index(t => t.Committee_Id)
                .Index(t => t.Committee_Id1)
                .Index(t => t.Committee_Id2)
                .Index(t => t.Committee_Id3);
            
            CreateTable(
                "dbo.CommitteeDivisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        StudentCount = c.String(),
                        StudentType = c.String(),
                        ExamDate = c.String(),
                        EvalDate = c.String(),
                        WorkShopCount = c.String(),
                        WorkShopCapacity = c.String(),
                        GroupsCount = c.String(),
                        Committee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Committees", t => t.Committee_Id)
                .Index(t => t.Committee_Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CommitteeLabs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        StudentCount = c.String(),
                        StudentType = c.String(),
                        ExamDate = c.String(),
                        EvalDate = c.String(),
                        Committee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Committees", t => t.Committee_Id)
                .Index(t => t.Committee_Id);
            
            CreateTable(
                "dbo.CommitteRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkPlaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LearningManagements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        GovernrateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Governrates", t => t.GovernrateId, cascadeDelete: true)
                .Index(t => t.GovernrateId);
            
            CreateTable(
                "dbo.Governrates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SectorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sectors", t => t.SectorId)
                .Index(t => t.SectorId);
            
            CreateTable(
                "dbo.Sectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Number = c.String(nullable: false),
                        StudentCount = c.Int(nullable: false),
                        Address = c.String(),
                        Phone = c.String(),
                        LearningManagementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LearningManagements", t => t.LearningManagementId, cascadeDelete: true)
                .Index(t => t.LearningManagementId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Committees", "SuperInspector_Id", "dbo.Members");
            DropForeignKey("dbo.Members", "Committee_Id3", "dbo.Committees");
            DropForeignKey("dbo.Committees", "LearningManagement_Id", "dbo.LearningManagements");
            DropForeignKey("dbo.Schools", "LearningManagementId", "dbo.LearningManagements");
            DropForeignKey("dbo.Governrates", "SectorId", "dbo.Sectors");
            DropForeignKey("dbo.LearningManagements", "GovernrateId", "dbo.Governrates");
            DropForeignKey("dbo.CommitteeLabs", "Committee_Id", "dbo.Committees");
            DropForeignKey("dbo.Members", "Committee_Id2", "dbo.Committees");
            DropForeignKey("dbo.Members", "Committee_Id1", "dbo.Committees");
            DropForeignKey("dbo.CommitteeDivisions", "Committee_Id", "dbo.Committees");
            DropForeignKey("dbo.Committees", "Chief_Id", "dbo.Members");
            DropForeignKey("dbo.Members", "Committee_Id", "dbo.Committees");
            DropForeignKey("dbo.Members", "WorkPlaceId", "dbo.WorkPlaces");
            DropForeignKey("dbo.Members", "SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.Members", "CommitteRoleId", "dbo.CommitteRoles");
            DropForeignKey("dbo.Members", "CommitteeLabId", "dbo.CommitteeLabs");
            DropForeignKey("dbo.Members", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Members", "CommitteeDivisionId", "dbo.CommitteeDivisions");
            DropForeignKey("dbo.Members", "CommitteeId", "dbo.Committees");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Schools", new[] { "LearningManagementId" });
            DropIndex("dbo.Governrates", new[] { "SectorId" });
            DropIndex("dbo.LearningManagements", new[] { "GovernrateId" });
            DropIndex("dbo.CommitteeLabs", new[] { "Committee_Id" });
            DropIndex("dbo.CommitteeDivisions", new[] { "Committee_Id" });
            DropIndex("dbo.Members", new[] { "Committee_Id3" });
            DropIndex("dbo.Members", new[] { "Committee_Id2" });
            DropIndex("dbo.Members", new[] { "Committee_Id1" });
            DropIndex("dbo.Members", new[] { "Committee_Id" });
            DropIndex("dbo.Members", new[] { "CommitteeId" });
            DropIndex("dbo.Members", new[] { "CommitteeDivisionId" });
            DropIndex("dbo.Members", new[] { "CommitteeLabId" });
            DropIndex("dbo.Members", new[] { "CommitteRoleId" });
            DropIndex("dbo.Members", new[] { "SpecialityId" });
            DropIndex("dbo.Members", new[] { "WorkPlaceId" });
            DropIndex("dbo.Members", new[] { "JobId" });
            DropIndex("dbo.Committees", new[] { "SuperInspector_Id" });
            DropIndex("dbo.Committees", new[] { "LearningManagement_Id" });
            DropIndex("dbo.Committees", new[] { "Chief_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Schools");
            DropTable("dbo.Sectors");
            DropTable("dbo.Governrates");
            DropTable("dbo.LearningManagements");
            DropTable("dbo.WorkPlaces");
            DropTable("dbo.Specialities");
            DropTable("dbo.CommitteRoles");
            DropTable("dbo.CommitteeLabs");
            DropTable("dbo.Jobs");
            DropTable("dbo.CommitteeDivisions");
            DropTable("dbo.Members");
            DropTable("dbo.Committees");
        }
    }
}
