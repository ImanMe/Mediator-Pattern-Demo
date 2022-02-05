using WhatToDo.Domain.Constants;

namespace WhatToDo.Domain.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = ItemStatus.Incomplete;
    }
}
