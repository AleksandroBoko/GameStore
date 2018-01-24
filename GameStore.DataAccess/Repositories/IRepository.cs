using System;
using System.Collections.Generic;

namespace GameStore.DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T GetItemById(Guid id);
        Guid Add(T item);
        Guid Remove(T item);
        Guid Update(T item);
        void Save();
    }
}
