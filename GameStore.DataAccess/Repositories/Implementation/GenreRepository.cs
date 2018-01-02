using GameStore.DataAccess.EntityModels;
using GameStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DataAccess.Repositories.Implementation
{
    class GenreRepository : IRepository<Genre>
    {
        private GenreRepository()
        {
            gameContext = GameStoreContext.GetInstance();
        }

        private readonly GameStoreContext gameContext;
        private readonly static GenreRepository Instance = new GenreRepository();

        public static GenreRepository GetInstance()
        {
            return Instance;
        }

        public void Add(Genre item)
        {
            gameContext.Genres.Add(item);
            Save();
        }

        public ICollection<Genre> GetAll()
        {
            var listGenre = new List<Genre>();
            if (gameContext.Genres.Any())
            {
                listGenre = gameContext.Genres.ToList();
            }

            return listGenre;
        }

        public Genre GetItemById(Guid id)
        {
            return gameContext.Genres.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(Genre item)
        {
            gameContext.Genres.Remove(item);
            Save();
        }

        public void Update(Genre item)
        {
            var genre = GetItemById(item.Id);
            if (genre != null)
            {
                genre.Name = item.Name;
                Save();
            }
        }

        public void Save()
        {
            gameContext.SaveChanges();
        }

    }
}
