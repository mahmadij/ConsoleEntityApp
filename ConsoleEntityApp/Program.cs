using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ConsoleEntityApp.Models;

namespace ConsoleEntityApp
{    

    public class MyDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemList> ItemLists { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Overriding using Fluent API. You can chain the methods and make a story, that's why they call it fluent.
            modelBuilder.Entity<ItemList>()
                .Property(t => t.Name)
                .IsRequired();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
