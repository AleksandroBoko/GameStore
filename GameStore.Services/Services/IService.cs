using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services.Services
{
    interface IService<T>
    {
        ICollection<T> GetAll();
        T GetItemById(Guid id);
        void Add(T item);
        void Update(T item);
        void Remove(T item);
    }
}
