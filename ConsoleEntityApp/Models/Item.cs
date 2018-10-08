using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEntityApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemList ItemList { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public Type Type { get; set; }
        public DateTime DateCreated { get; set; }
        public int Status { get; set; }
        public DateTime? DateEnded { get; set; }
    }
}
