using GameStore.DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GameStore.DataAccess.Repositories.Implementation
{
    public class StudioRepository : IRepository<Studio>
    {
        public StudioRepository(DbContext context)
        {
            gameContext = context as GameStoreContext;
            if (gameContext == null)
            {
                throw new NullReferenceException("The context is null");
            }
        }

        private readonly GameStoreContext gameContext;

        public Guid Add(Studio item)
        {
            var addingItemId = Guid.NewGuid();
            item.Id = addingItemId;
            gameContext.Studios.Add(item);

            Save();
            return addingItemId;
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

        public Guid Remove(Studio item)
        {
            var removingItemId = item.Id;
            gameContext.Studios.Remove(item);

            Save();
            return removingItemId;
        }

        public Guid Update(Studio item)
        {
            var studio = GetItemById(item.Id);
            if (studio != null)
            {
                studio.Name = item.Name;
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
