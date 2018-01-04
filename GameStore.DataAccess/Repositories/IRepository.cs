using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T GetItemById(Guid id);
        void Add(T item);
        void Remove(T item);
        void Update(T item);
        void Save();
    }
}
