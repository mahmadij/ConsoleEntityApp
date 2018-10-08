namespace ConsoleEntityApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Items", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "DateEnded", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "DateEnded");
            DropColumn("dbo.Items", "Status");
            DropColumn("dbo.Items", "DateCreated");
        }
    }
}
