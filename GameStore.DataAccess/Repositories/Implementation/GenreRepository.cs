using GameStore.DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GameStore.DataAccess.Repositories.Implementation
{
    public class GenreRepository : IRepository<Genre>
    {
        private GenreRepository(DbContext gameContext)
        {
            this.gameContext = gameContext as GameStoreContext;
            if (this.gameContext == null)
            {
                throw new NullReferenceException("The context is null");
            }
        }

        private readonly GameStoreContext gameContext;
        private readonly static GenreRepository Instance = new GenreRepository(new GameStoreContext());

        public static GenreRepository GetInstance()
        {
            return Instance;
        }

        public Guid Add(Genre item)
        {
            var addingItemId = Guid.NewGuid();
            item.Id = addingItemId;
            gameContext.Genres.Add(item);

            Save();
            return addingItemId;
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

        public Guid Remove(Genre item)
        {
            var removingItemId = item.Id;
            gameContext.Genres.Remove(item);

            Save();
            return removingItemId;
        }

        public Guid Update(Genre item)
        {
            var genre = GetItemById(item.Id);
            if (genre != null)
            {
                genre.Name = item.Name;
                Save();
            }

            return item.Id;
        }

        public void Save()
        {
            gameContext.SaveChanges();
        }

    }
}
