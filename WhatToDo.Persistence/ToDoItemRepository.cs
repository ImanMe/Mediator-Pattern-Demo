using Microsoft.EntityFrameworkCore;
using WhatToDo.Core.Contracts;
using WhatToDo.Core.Entities;

namespace WhatToDo.Persistence;

public class ToDoItemRepository : IToDoItemRepository
{
    private readonly WhatToDoContext _context;

    public ToDoItemRepository(WhatToDoContext context)
    {
        _context = context;
    }

    public async Task<ToDoItem> GetByIdAsync(int id)
    {
        return await _context.ToDoItems.FindAsync(id);
    }

    public async Task<IReadOnlyCollection<ToDoItem>> GetAllAsync()
    {
        return await _context.Set<ToDoItem>()
            .OrderBy(x => x.LastModifiedDate)
            .ToListAsync();
    }

    public async Task<bool> IsDuplicateAsync(string description, bool isCompleted = false)
    {
        return await _context.ToDoItems.AnyAsync(x => x.Description == description && x.IsCompleted == isCompleted);

    }

    public async Task<ToDoItem> AddAsync(ToDoItem toDoItem)
    {
        await _context.ToDoItems.AddAsync(toDoItem);

        await _context.SaveChangesAsync();

        return toDoItem;
    }

    public async Task UpdateAsync(ToDoItem toDoItem)
    {
        _context.Attach(toDoItem);

        _context.Entry(toDoItem).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ToDoItem toDoItem)
    {
        _context.Remove(toDoItem);

        await _context.SaveChangesAsync();
    }
}