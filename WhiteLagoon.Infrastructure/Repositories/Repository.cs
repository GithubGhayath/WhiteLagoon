using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _Context;
        private readonly DbSet<T> Entity;
        public Repository(AppDbContext context)
        {
            _Context = context;
            Entity = _Context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            Entity.Add(entity);
        }

        public bool Any(Expression<Func<T, bool>> Filter)
        {
            return Entity.Any(Filter);
        }

        public T? Get(Expression<Func<T, bool>> Filter, string? IncludeProperties = null)
        {
            IQueryable<T> Query = Entity;

            Query = Query.Where(Filter);

            if (IncludeProperties is not null)
            {
                foreach (var Property in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(Property);
                }
            }

            return Query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? Filter = null, string? IncludeProperties = null)
        {
            IQueryable<T> Query = Entity;

            if (Filter is not null)
            {
                Query = Query.Where(Filter);
            }

            if (IncludeProperties is not null)
            {
                foreach (var Property in IncludeProperties.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries)) 
                {
                    Query = Query.Include(Property);
                }
            }

            return Query.ToList();
        }

        public virtual void Remove(T entity)
        {
            Entity.Remove(entity);
        }
    }
}
