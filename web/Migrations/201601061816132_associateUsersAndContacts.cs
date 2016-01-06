namespace contact_management.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class associateUsersAndContacts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts_ApplicationUsers",
                c => new
                    {
                        ContactId = c.Guid(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ContactId, t.ApplicationUserId })
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ContactId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts_ApplicationUsers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacts_ApplicationUsers", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Contacts_ApplicationUsers", new[] { "ApplicationUserId" });
            DropIndex("dbo.Contacts_ApplicationUsers", new[] { "ContactId" });
            DropTable("dbo.Contacts_ApplicationUsers");
        }
    }
}
