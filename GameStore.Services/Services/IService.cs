using System;
using System.Collections.Generic;

namespace GameStore.Services.Services
{
    public interface IService<T>
    {
        ICollection<T> GetAll();
        T GetItemById(Guid id);
        Guid Add(T item);
        Guid Update(T item);
        Guid Remove(T item);
    }
}
