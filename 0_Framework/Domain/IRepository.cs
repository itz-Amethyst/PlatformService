﻿using System.Linq.Expressions;

namespace _0_Framework.Domain
{
    public interface IRepository<in TKey, T> where T : class
    {
        T GetById(TKey id);

        List<T> Get();

        IEnumerable<T> GetAllPlatforms();

        void Create(T entity);

        void SaveChanges();

        void BulkSaveChanges();

        // For Command ExternalId do the same

        bool Exists(Expression<Func<T, bool>> expression);
    }
}