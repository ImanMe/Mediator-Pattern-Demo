using WhatToDo.Core.Entities;

namespace WhatToDo.Application.Features.Items;

public class ToDoItemSpecification : BaseSpecification<ToDoItem>
{
    public ToDoItemSpecification():base(_=>true)
    {
        AddOrderBy(x => x.CreatedDate);
    }

    public ToDoItemSpecification(string description, bool isCompleted = false) : base(x =>
        x.IsCompleted == isCompleted && x.Description == description)
    {
    }
}