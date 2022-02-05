namespace WhatToDo.Application.Features.Items.Dtos
{
    public class ToDoItemDto
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
