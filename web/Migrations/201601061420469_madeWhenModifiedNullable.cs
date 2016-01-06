namespace contact_management.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeWhenModifiedNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "WhenModified", c => c.DateTime());
            AlterColumn("dbo.Contacts", "WhenModified", c => c.DateTime());
            AlterColumn("dbo.Notes", "WhenModified", c => c.DateTime());
            AlterColumn("dbo.PhoneNumbers", "WhenModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhoneNumbers", "WhenModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Notes", "WhenModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contacts", "WhenModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Addresses", "WhenModified", c => c.DateTime(nullable: false));
        }
    }
}
