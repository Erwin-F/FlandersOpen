using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FlandersOpen.Domain.SeedWork;

namespace FlandersOpen.Application
{
    public interface IAsyncRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
