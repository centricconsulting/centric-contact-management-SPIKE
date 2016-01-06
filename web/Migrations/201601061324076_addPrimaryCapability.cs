namespace contact_management.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPrimaryCapability : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Primary", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhoneNumbers", "Primary", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhoneNumbers", "Primary");
            DropColumn("dbo.Addresses", "Primary");
        }
    }
}
