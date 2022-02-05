using WhatToDo.Core.Entities;

namespace WhatToDo.Core.Contracts
{
    public interface IToDoItemRepository
    {
        Task<ToDoItem> GetByIdAsync(int id);
        Task<IReadOnlyCollection<ToDoItem>> GetAllAsync();
        Task<bool> IsDuplicateAsync(string description, bool isCompleted = false);
        Task<ToDoItem> AddAsync(ToDoItem toDoItem);
        Task UpdateAsync(ToDoItem toDoItem);
        Task DeleteAsync(ToDoItem toDoItem);
    }
}
