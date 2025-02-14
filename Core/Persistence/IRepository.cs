﻿using Core.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence
{
    public interface IRepository<T>
    {
        T? Get(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = true
        );

        IPaginate<T> GetList(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            int index = 0,
            int size = 10,
            bool enableTracking = true
        );

        void Add(T entity);
        void Delete(T entity);
        void SoftDelete(T entity);
        void Update(T entity);

        IPaginate<T> GetListByDynamic(
    DynamicQuery dynamic,
    Expression<Func<T, bool>>? predicate = null,
    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
    int index = 0,
    int size = 10,
    bool enableTracking = true
);
    }
}
