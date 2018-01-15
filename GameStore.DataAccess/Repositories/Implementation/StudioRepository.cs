using GameStore.DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DataAccess.Repositories.Implementation
{
    public class StudioRepository : IRepository<Studio>
    {
        private StudioRepository()
        {
            gameContext = new GameStoreContext();
        }

        private readonly GameStoreContext gameContext;
        private readonly static StudioRepository Instance = new StudioRepository();

        public static StudioRepository GetInstance()
        {
            return Instance;
        }

        public void Add(Studio item)
        {
            gameContext.Studios.Add(item);
            Save();
        }

        public ICollection<Studio> GetAll()
        {
            var listStudios = new List<Studio>();
            if (gameContext.Studios.Any())
            {
                listStudios = gameContext.Studios.ToList();
            }

            return listStudios;
        }

        public Studio GetItemById(Guid id)
        {
            return gameContext.Studios.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(Studio item)
        {
            gameContext.Studios.Remove(item);
            Save();
        }

        public void Update(Studio item)
        {
            var studio = GetItemById(item.Id);
            if (studio != null)
            {
                studio.Name = item.Name;
                Save();
            };
        }

        public void Save()
        {
            gameContext.SaveChanges();
        }
    }
}
