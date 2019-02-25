using System;
using System.Collections.Generic;
using System.Text;
using FlandersOpen.Domain.SeedWork;

namespace FlandersOpen.Application
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(Guid id);
        IEnumerable<T> ListAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
