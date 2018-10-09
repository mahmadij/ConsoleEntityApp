using ConsoleEntityApp.Context;
using System.Linq;
using System;
namespace ConsoleEntityApp
{    

    
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MyDbContext();
            //LINQ 
            var query =
                from c in context.Items
                where c.Name.Contains("3")
                orderby c.Name
                select c;

            foreach(var item in query)
            {
                Console.WriteLine(item.Name);
            }

            //extension method
            var tags = context.Tags
                .Where(t => t.Name.Contains("Tag"))
                .OrderBy(c => c.Name);

            foreach (var tag in tags)
            {
                Console.WriteLine(tag.Name);
            }
        }
    }
}
