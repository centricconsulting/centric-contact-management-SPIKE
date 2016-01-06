namespace contact_management.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class huh2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
