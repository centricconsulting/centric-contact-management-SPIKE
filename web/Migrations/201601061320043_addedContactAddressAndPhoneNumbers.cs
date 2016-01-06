namespace contact_management.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedContactAddressAndPhoneNumbers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        ContactId = c.Guid(nullable: false),
                        WhenCreated = c.DateTime(nullable: false),
                        WhenModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Company = c.String(),
                        WhenCreated = c.DateTime(nullable: false),
                        WhenModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(),
                        Description = c.String(),
                        ContactId = c.Guid(nullable: false),
                        WhenCreated = c.DateTime(nullable: false),
                        WhenModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Addresses", "ContactId", "dbo.Contacts");
            DropIndex("dbo.PhoneNumbers", new[] { "ContactId" });
            DropIndex("dbo.Addresses", new[] { "ContactId" });
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.Contacts");
            DropTable("dbo.Addresses");
        }
    }
}
