using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WhatToDo.Core.Entities;

namespace WhatToDo.Persistence
{
    public class WhatToDoContext : DbContext
    {
        public WhatToDoContext(DbContextOptions<WhatToDoContext> options) : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
