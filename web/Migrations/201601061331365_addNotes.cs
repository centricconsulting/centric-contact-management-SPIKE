namespace contact_management.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(),
                        UserId = c.String(),
                        ContactId = c.Guid(nullable: false),
                        WhenCreated = c.DateTime(nullable: false),
                        WhenModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            AddColumn("dbo.Contacts", "Title", c => c.String());
            AddColumn("dbo.Contacts", "EmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Notes", new[] { "ContactId" });
            DropColumn("dbo.Contacts", "EmailAddress");
            DropColumn("dbo.Contacts", "Title");
            DropTable("dbo.Notes");
        }
    }
}
