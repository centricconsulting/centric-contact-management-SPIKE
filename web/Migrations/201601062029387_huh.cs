namespace contact_management.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class huh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Discriminator");
        }
    }
}
