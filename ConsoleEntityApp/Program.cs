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
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
