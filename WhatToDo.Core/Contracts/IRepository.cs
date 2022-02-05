using System.Linq.Expressions;
using WhatToDo.Core.Contracts.Persistence;

namespace WhatToDo.Core.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetWithSpecAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetListAsync();
        Task<IReadOnlyList<T>> GetListBySpecAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
