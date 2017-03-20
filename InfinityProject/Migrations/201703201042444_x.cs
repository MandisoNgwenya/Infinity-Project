namespace InfinityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class x : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingViewModels",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        cName = c.String(),
                        cSurname = c.String(),
                        IDNumber = c.String(),
                        Address = c.String(),
                        TelNo = c.String(),
                        Device = c.String(),
                        Date = c.String(),
                        Clerk = c.String(),
                        Technician = c.String(),
                        JobCard = c.String(),
                        Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
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
                        UserProfile_UserProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_UserProfileId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.UserProfile_UserProfileId);
            
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserProfileId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Gender = c.String(),
                        IdentityNumber = c.String(),
                        ContactNumber = c.String(),
                        Status = c.Int(),
                        bookingID = c.String(),
                        JobCard = c.String(),
                        CustomerNumber = c.String(),
                        cName = c.String(),
                        cSurname = c.String(),
                        IDNumber = c.String(),
                        Address = c.String(),
                        TelNo = c.String(),
                        date = c.DateTime(),
                        device = c.String(),
                        Model = c.String(),
                        serialNo = c.String(),
                        Signature = c.String(),
                        Id = c.String(maxLength: 128),
                        IdentityNumber1 = c.String(),
                        ContactNumber1 = c.String(),
                        Role = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserProfileId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Clerks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Gender = c.String(),
                        Date_OF_Bith = c.DateTime(nullable: false),
                        Address = c.String(),
                        Contact_nfo = c.String(),
                        email = c.String(),
                        User_Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        IDNumber = c.String(),
                        Address = c.String(),
                        TelNo = c.String(),
                        Device = c.String(),
                        status = c.String(),
                        Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.customerID)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Quotations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Job_Card = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Deposit = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        IDNumber = c.String(),
                        technician = c.String(),
                        Accessories = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.StatusModels",
                c => new
                    {
                        status = c.Int(nullable: false, identity: true),
                        statusName = c.String(),
                    })
                .PrimaryKey(t => t.status);
            
            CreateTable(
                "dbo.Technicians",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Date_OF_Bith = c.DateTime(nullable: false),
                        Job_Card = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Customers", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.BookingViewModels", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "UserProfile_UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Customers", new[] { "Id" });
            DropIndex("dbo.UserProfiles", new[] { "Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "UserProfile_UserProfileId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.BookingViewModels", new[] { "Id" });
            DropTable("dbo.Technicians");
            DropTable("dbo.StatusModels");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Quotations");
            DropTable("dbo.Customers");
            DropTable("dbo.Clerks");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.BookingViewModels");
        }
    }
}
