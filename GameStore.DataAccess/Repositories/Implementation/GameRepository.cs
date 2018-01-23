using GameStore.DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GameStore.DataAccess.Repositories.Implementation
{
    public class GameRepository : IRepository<Game>
    {
        private GameRepository(DbContext gameContext)
        {
            this.gameContext = gameContext as GameStoreContext;
            if (this.gameContext == null)
            {
                throw new NullReferenceException("The context is null");
            }
        }

        private readonly GameStoreContext gameContext;
        private readonly static GameRepository Instance = new GameRepository(new GameStoreContext());

        public static GameRepository GetInstance()
        {
            return Instance;
        }

        public Guid Add(Game item)
        {
            var addingItemId = Guid.NewGuid();
            item.Id = addingItemId;
            gameContext.Games.Add(item);

            Save();
            return addingItemId;
        }

        public ICollection<Game> GetAll()
        {
            var listGames = new List<Game>();
            if (gameContext.Games.Any())
            {
                listGames = gameContext.Games.ToList();
            }

            return listGames;
        }

        public Game GetItemById(Guid id)
        {
            return gameContext.Games.FirstOrDefault(x => x.Id == id);
        }

        public Guid Remove(Game item)
        {
            var removingItemId = item.Id;
            gameContext.Games.Remove(item);

            Save();
            return removingItemId;
        }

        public Guid Update(Game item)
        {
            var game = GetItemById(item.Id);
            if (game != null)
            {
                game.Name = item.Name;
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
