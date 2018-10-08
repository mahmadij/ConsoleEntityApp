namespace ConsoleEntityApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagItemLists",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        ItemList_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.ItemList_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.ItemLists", t => t.ItemList_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.ItemList_Id);
            
            CreateTable(
                "dbo.TagItems",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Item_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Item_Id);
            
            AddColumn("dbo.Items", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "ItemList_Id", c => c.Int());
            CreateIndex("dbo.Items", "ItemList_Id");
            AddForeignKey("dbo.Items", "ItemList_Id", "dbo.ItemLists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.TagItems", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.TagItemLists", "ItemList_Id", "dbo.ItemLists");
            DropForeignKey("dbo.TagItemLists", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Items", "ItemList_Id", "dbo.ItemLists");
            DropIndex("dbo.TagItems", new[] { "Item_Id" });
            DropIndex("dbo.TagItems", new[] { "Tag_Id" });
            DropIndex("dbo.TagItemLists", new[] { "ItemList_Id" });
            DropIndex("dbo.TagItemLists", new[] { "Tag_Id" });
            DropIndex("dbo.Items", new[] { "ItemList_Id" });
            DropColumn("dbo.Items", "ItemList_Id");
            DropColumn("dbo.Items", "Type");
            DropTable("dbo.TagItems");
            DropTable("dbo.TagItemLists");
            DropTable("dbo.Tags");
            DropTable("dbo.ItemLists");
        }
    }
}
