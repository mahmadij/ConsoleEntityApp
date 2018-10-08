using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleEntityApp
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MyDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
