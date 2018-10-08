using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleEntityApp
{
    public enum Type
    {
        Mandatory = 1,
        Optional = 2
    }
    public class ItemList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemList ItemList { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public Type Type { get; set; }
    }
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<ItemList> ItemLists { get; set; }
    }

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
