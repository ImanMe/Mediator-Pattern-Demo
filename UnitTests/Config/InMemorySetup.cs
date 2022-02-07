using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhatToDo.Domain.Contracts;
using WhatToDo.Domain.Entities;
using WhatToDo.Persistence;

namespace UnitTests.Config
{
    public class InMemorySetup
    {
        public static IRepository<ToDoItem> GetInMemoryToDoItemRepository()
        {
            var builder = new DbContextOptionsBuilder<WhatToDoContext>();

            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            var options = builder.Options;

            var whatToDoContext = new WhatToDoContext(options);

            whatToDoContext.Database.EnsureDeleted();

            whatToDoContext.Database.EnsureCreated();

            var toDoItems = ToDoItemSeed.SeedData();

            whatToDoContext.ToDoItems.AddRange(toDoItems);

            whatToDoContext.SaveChanges();

            return new Repository<ToDoItem>(whatToDoContext);
        }
    }
}
