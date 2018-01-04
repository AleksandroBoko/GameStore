using GameStore.DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DataAccess.Repositories.Implementation
{
    public class ProducerRepository : IRepository<Producer>
    {
        private ProducerRepository()
        {
            gameContext = GameStoreContext.GetInstance();
        }

        private readonly GameStoreContext gameContext;
        private readonly static ProducerRepository Instance = new ProducerRepository();

        public static ProducerRepository GetInstance()
        {
            return Instance;
        }

        public void Add(Producer item)
        {
            gameContext.Producers.Add(item);
            Save();
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

        public void Remove(Producer item)
        {
            gameContext.Producers.Remove(item);
            Save();
        }

        public void Update(Producer item)
        {
            var producer = GetItemById(item.Id);
            if (producer != null)
            {
                producer.Name = item.Name;
                Save();
            };
        }

        public void Save()
        {
            gameContext.SaveChanges();
        }
    }
}
