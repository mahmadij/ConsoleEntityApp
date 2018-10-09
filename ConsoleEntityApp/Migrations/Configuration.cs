namespace ConsoleEntityApp.Migrations
{
    using ConsoleEntityApp.Context;
    using ConsoleEntityApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var tags = new Dictionary<string, Tag>
            {
                {"Tag4", new Tag{ Id = 4, Name ="Tag4" } },
                {"Tag5", new Tag{ Id = 5, Name ="Tag5" } },
                {"Tag6", new Tag{ Id = 6, Name ="Tag6" } }
            };

            foreach (var tag in tags.Values)
            {
                context.Tags.AddOrUpdate(t => t.Id, tag);
            }

            var items = new List<Item>
            {
                new Item
                {
                    Id = 5,
                    Name = "Item3",
                    Status = 1,
                    Tags = new Collection<Tag>()
                    {
                        tags["Tag5"],
                        tags["Tag6"]
                    },
                    DateCreated = DateTime.Now,
                    Type = Models.Type.Mandatory
                },
                new Item
                {
                    Id = 5,
                    Name = "Item4",
                    Status = 1,
                    Tags = new Collection<Tag>()
                    {
                        tags["Tag5"],
                        tags["Tag4"]
                    },
                    DateCreated = DateTime.Now,
                    Type = Models.Type.Optional
                }
            };

            foreach (var item in items)
            {
                context.Items.AddOrUpdate(i => i.Id, item);
            }

            var itemlists = new List<ItemList>
            {
                new ItemList
                {
                    Id = 7,
                    Name = "ItemList2",
                    Tags = new Collection<Tag>()
                    {
                        tags["Tag6"]
                    },
                    Items = new Collection<Item>
                    {
                        items[0],
                        items[1]
                    }
                }
            };

            foreach(var itemList in itemlists)
            {
                context.ItemLists.AddOrUpdate(il => il.Id, itemList);
            }
        }
    }
}
