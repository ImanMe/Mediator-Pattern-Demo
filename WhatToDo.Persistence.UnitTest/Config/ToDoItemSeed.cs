using System.Collections.Generic;
using WhatToDo.Domain.Entities;

namespace WhatToDo.Persistence.UnitTest.Config;

public class ToDoItemSeed
{
    public static IList<ToDoItem> SeedData()
    {
        return new List<ToDoItem>
        {
            new()
            {
                Id = 1,
                Description = "First item",
                IsCompleted = false
            },
            new()
            {
                Id = 2,
                Description = "Second item",
                IsCompleted = false
            },
            new()
            {
                Id = 3,
                Description = "Third item",
                IsCompleted = false
            },
            new()
            {
                Id = 4,
                Description = "Fourth item",
                IsCompleted = true
            },
            new()
            {
                Id = 5,
                Description = "Fifth item",
                IsCompleted = true
            }
        };
    }
}