namespace InfinityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class x : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StatusModels",
                c => new
                    {
                        status = c.Int(nullable: false, identity: true),
                        statusName = c.String(),
                    })
                .PrimaryKey(t => t.status);
            
            AddColumn("dbo.BookingViewModels", "JobCard", c => c.String());
            AddColumn("dbo.Clerks", "First_Name", c => c.String());
            AddColumn("dbo.Clerks", "Last_Name", c => c.String());
            AddColumn("dbo.Clerks", "Gender", c => c.String());
            AddColumn("dbo.Clerks", "Date_OF_Bith", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clerks", "Address", c => c.String());
            AddColumn("dbo.Clerks", "Contact_nfo", c => c.String());
            AddColumn("dbo.Clerks", "email", c => c.String());
            AddColumn("dbo.Clerks", "User_Name", c => c.String());
            AddColumn("dbo.Quotations", "Job_Card", c => c.String());
            AddColumn("dbo.Quotations", "Name", c => c.String());
            AddColumn("dbo.Quotations", "Description", c => c.String());
            AddColumn("dbo.Quotations", "Deposit", c => c.Double(nullable: false));
            AddColumn("dbo.Quotations", "Total", c => c.Double(nullable: false));
            AddColumn("dbo.Technicians", "First_Name", c => c.String());
            AddColumn("dbo.Technicians", "Last_Name", c => c.String());
            AddColumn("dbo.Technicians", "Date_OF_Bith", c => c.DateTime(nullable: false));
            AddColumn("dbo.Technicians", "Job_Card", c => c.String());
            AddColumn("dbo.Technicians", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Technicians", "Description");
            DropColumn("dbo.Technicians", "Job_Card");
            DropColumn("dbo.Technicians", "Date_OF_Bith");
            DropColumn("dbo.Technicians", "Last_Name");
            DropColumn("dbo.Technicians", "First_Name");
            DropColumn("dbo.Quotations", "Total");
            DropColumn("dbo.Quotations", "Deposit");
            DropColumn("dbo.Quotations", "Description");
            DropColumn("dbo.Quotations", "Name");
            DropColumn("dbo.Quotations", "Job_Card");
            DropColumn("dbo.Clerks", "User_Name");
            DropColumn("dbo.Clerks", "email");
            DropColumn("dbo.Clerks", "Contact_nfo");
            DropColumn("dbo.Clerks", "Address");
            DropColumn("dbo.Clerks", "Date_OF_Bith");
            DropColumn("dbo.Clerks", "Gender");
            DropColumn("dbo.Clerks", "Last_Name");
            DropColumn("dbo.Clerks", "First_Name");
            DropColumn("dbo.BookingViewModels", "JobCard");
            DropTable("dbo.StatusModels");
        }
    }
}
