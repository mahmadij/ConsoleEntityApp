namespace ConsoleEntityApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Override : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ItemLists", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Items", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Name", c => c.String());
            AlterColumn("dbo.ItemLists", "Name", c => c.String());
        }
    }
}
