namespace contact_management.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makeNotesSensitive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "IsSensitive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "IsSensitive");
        }
    }
}
