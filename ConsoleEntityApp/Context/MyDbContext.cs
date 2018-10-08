
using System.Data.Entity;
using ConsoleEntityApp.Models;

namespace ConsoleEntityApp.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemList> ItemLists { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Moving these into their own configuration files.
            /*modelBuilder.Entity<ItemList>()
                .Property(t => t.Name)
                .IsRequired();*/

            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new ItemListConfiguration());
        }
    }

}
