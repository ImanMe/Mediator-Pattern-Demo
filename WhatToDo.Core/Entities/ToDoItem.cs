using WhatToDo.Core.Constants;

namespace WhatToDo.Core.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = ItemStatus.Incomplete;
    }
}
