using ConsoleEntityApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEntityApp.Context
{
    class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            //Overriding using Fluent API. You can chain the methods and make a story, that's why they call it fluent.
            Property(t => t.Name)
            .IsRequired();

            HasMany(i => i.Tags)
                .WithMany(t => t.Items)
                .Map(m =>
                {
                    m.ToTable("ItemTags");
                    m.MapLeftKey("ItemId");
                    m.MapRightKey("TagId");
                });

            /*HasRequired(i => i.ItemList)
                .WithMany(il => il.Items)
                .HasForeignKey(i => i.ItemListId)
                .WillCascadeOnDelete(false);*/
        }
    }
}
