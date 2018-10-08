namespace ConsoleEntityApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FluentAPI : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TagItemLists", newName: "ItemListTags");
            RenameTable(name: "dbo.TagItems", newName: "ItemTags");
            DropIndex("dbo.Items", new[] { "ItemList_Id" });
            RenameColumn(table: "dbo.Items", name: "ItemList_Id", newName: "ItemListId");
            RenameColumn(table: "dbo.ItemListTags", name: "Tag_Id", newName: "TagId");
            RenameColumn(table: "dbo.ItemListTags", name: "ItemList_Id", newName: "ItemListId");
            RenameColumn(table: "dbo.ItemTags", name: "Tag_Id", newName: "TagId");
            RenameColumn(table: "dbo.ItemTags", name: "Item_Id", newName: "ItemId");
            RenameIndex(table: "dbo.ItemTags", name: "IX_Item_Id", newName: "IX_ItemId");
            RenameIndex(table: "dbo.ItemTags", name: "IX_Tag_Id", newName: "IX_TagId");
            RenameIndex(table: "dbo.ItemListTags", name: "IX_ItemList_Id", newName: "IX_ItemListId");
            RenameIndex(table: "dbo.ItemListTags", name: "IX_Tag_Id", newName: "IX_TagId");
            DropPrimaryKey("dbo.ItemListTags");
            DropPrimaryKey("dbo.ItemTags");
            AlterColumn("dbo.Items", "ItemListId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ItemListTags", new[] { "ItemListId", "TagId" });
            AddPrimaryKey("dbo.ItemTags", new[] { "ItemId", "TagId" });
            CreateIndex("dbo.Items", "ItemListId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Items", new[] { "ItemListId" });
            DropPrimaryKey("dbo.ItemTags");
            DropPrimaryKey("dbo.ItemListTags");
            AlterColumn("dbo.Items", "ItemListId", c => c.Int());
            AddPrimaryKey("dbo.ItemTags", new[] { "Tag_Id", "Item_Id" });
            AddPrimaryKey("dbo.ItemListTags", new[] { "Tag_Id", "ItemList_Id" });
            RenameIndex(table: "dbo.ItemListTags", name: "IX_TagId", newName: "IX_Tag_Id");
            RenameIndex(table: "dbo.ItemListTags", name: "IX_ItemListId", newName: "IX_ItemList_Id");
            RenameIndex(table: "dbo.ItemTags", name: "IX_TagId", newName: "IX_Tag_Id");
            RenameIndex(table: "dbo.ItemTags", name: "IX_ItemId", newName: "IX_Item_Id");
            RenameColumn(table: "dbo.ItemTags", name: "ItemId", newName: "Item_Id");
            RenameColumn(table: "dbo.ItemTags", name: "TagId", newName: "Tag_Id");
            RenameColumn(table: "dbo.ItemListTags", name: "ItemListId", newName: "ItemList_Id");
            RenameColumn(table: "dbo.ItemListTags", name: "TagId", newName: "Tag_Id");
            RenameColumn(table: "dbo.Items", name: "ItemListId", newName: "ItemList_Id");
            CreateIndex("dbo.Items", "ItemList_Id");
            RenameTable(name: "dbo.ItemTags", newName: "TagItems");
            RenameTable(name: "dbo.ItemListTags", newName: "TagItemLists");
        }
    }
}
