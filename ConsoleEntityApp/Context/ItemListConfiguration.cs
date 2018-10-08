using ConsoleEntityApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEntityApp.Context
{
    class ItemListConfiguration : EntityTypeConfiguration<ItemList>
    {
        public ItemListConfiguration()
        {
            Property(il => il.Name)
                .IsRequired();

            HasMany(il => il.Tags)
                .WithMany(t => t.ItemLists)
                .Map(il => {
                    il.ToTable("ItemListTags");
                    il.MapLeftKey("ItemListId");
                    il.MapRightKey("TagId");
                });

        }

    }
}
