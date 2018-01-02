using GameStore.DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DataAccess.Repositories.Implementation
{
    class GameRepository : IRepository<Game>
    {
        private GameRepository()
        {
            gameContext = GameStoreContext.GetInstance();
        }

        private readonly GameStoreContext gameContext;
        private readonly static GameRepository Instance = new GameRepository();

        public static GameRepository GetInstance()
        {
            return Instance;
        }

        public void Add(Game item)
        {
            gameContext.Games.Add(item);
            Save();
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

        public void Remove(Game item)
        {
            gameContext.Games.Remove(item);
            Save();
        }

        public void Update(Game item)
        {
            var game = GetItemById(item.Id);
            if (game != null)
            {
                game.Name = item.Name;
                Save();
            };
        }

        public void Save()
        {
            gameContext.SaveChanges();
        }
    }
}
