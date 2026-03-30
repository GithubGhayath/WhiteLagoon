using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? Filter = null, string? IncludeProperties = null);
        T? Get(Expression<Func<T, bool>> Filter, string? IncludeProperties = null);
        void Add(T entity);
        bool Any(Expression<Func<T, bool>> Filter);
        void Remove(T entity);
    }
}
