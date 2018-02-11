﻿using System;
using System.Collections.Generic;

namespace BitstampTradeBot.Data.Repositories
{
    public interface IRepository<T>
    {
        void Add(T newEntity);
        void Remove(T newEntity);
        void Save();
        void Update(T entity);
        IEnumerable<T> Where(Func<T, bool> predicate);
        List<T> ToList();
    }
}