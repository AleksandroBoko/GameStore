using GameStore.DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GameStore.DataAccess.Repositories.Implementation
{
    public class ProducerRepository : IRepository<Producer>
    {
        public ProducerRepository(DbContext context)
        {
            gameContext = context as GameStoreContext;
            if (gameContext == null)
            {
                throw new NullReferenceException("The context is null");
            }
        }

        private readonly GameStoreContext gameContext;
        
        public Guid Add(Producer item)
        {
            var addingItemId = Guid.NewGuid();
            item.Id = addingItemId;
            gameContext.Producers.Add(item);

            Save();
            return addingItemId;
        }

        public ICollection<Producer> GetAll()
        {
            var listProducers = new List<Producer>();
            if (gameContext.Producers.Any())
            {
                listProducers = gameContext.Producers.ToList();
            }

            return listProducers;
        }

        public Producer GetItemById(Guid id)
        {
            return gameContext.Producers.FirstOrDefault(x => x.Id == id);
        }

        public Guid Remove(Producer item)
        {
            var removingItemId = item.Id;
            gameContext.Producers.Remove(item);

            Save();
            return removingItemId;
        }

        public Guid Update(Producer item)
        {
            var producer = GetItemById(item.Id);
            if (producer != null)
            {
                producer.Name = item.Name;
                Save();
            };

            return item.Id;
        }

        public void Save()
        {
            gameContext.SaveChanges();
        }
    }
}
