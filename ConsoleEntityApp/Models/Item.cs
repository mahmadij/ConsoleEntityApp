using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEntityApp.Models
{
    public class Item
    {
        public int Id { get; set; }

        //Using Data Annotation for override. This is ugly, but I leave it as an example. Stick to one convention. I decided to go with Fluent API.
        [Required]
        public string Name { get; set; }
        public ItemList ItemList { get; set; }
        public int ItemListId { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public Type Type { get; set; }
        public DateTime DateCreated { get; set; }
        public int Status { get; set; }
        public DateTime? DateEnded { get; set; }
    }
}
