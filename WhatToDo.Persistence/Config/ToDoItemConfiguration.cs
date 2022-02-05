using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhatToDo.Core.Entities;

namespace WhatToDo.Persistence.Config
{
    public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(p => p.LastModifiedDate).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(p => p.IsCompleted).IsRequired().HasDefaultValue(false);
        }
    }
}
