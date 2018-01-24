using GameStore.DataAccess.EntityModels;
using GameStore.DataAccess.Repositories;
using GameStore.Domains.Domain;
using static GameStore.Services.Util.AppMapper;
using System;
using System.Collections.Generic;

namespace GameStore.Services.Services.Implementation
{
    public class GenreServices : IGenreService
    {
        public GenreServices(IRepository<Genre> repository)
        {
            genreRepository = repository;
        }

        private readonly IRepository<Genre> genreRepository;

        public Guid Add(GenreModel item)
        {
            var genreEntity = GameStoreMapper.Map<GenreModel, Genre>(item);
            return genreRepository.Add(genreEntity);
        }

        public ICollection<GenreModel> GetAll()
        {
            var genres = GameStoreMapper.Map<ICollection<Genre>, ICollection<GenreModel>>
                (genreRepository.GetAll());

            return genres;
        }

        public GenreModel GetItemById(Guid id)
        {
            var genre = genreRepository.GetItemById(id);
            return genre != null ? GameStoreMapper.Map<Genre, GenreModel>(genre) : new GenreModel();
        }

        public GenreInfoTransferModel GetGenreInfoTransferById(Guid id)
        {
            var genre = genreRepository.GetItemById(id);
            return genre != null ? GameStoreMapper.Map<Genre, GenreInfoTransferModel>(genre) : new GenreInfoTransferModel();
        }

        public Guid Remove(GenreModel item)
        {
            var genre = GameStoreMapper.Map<GenreModel, Genre>(item);
            return genreRepository.Remove(genre);
        }

        public Guid Update(GenreModel item)
        {
            var genre = GameStoreMapper.Map<GenreModel, Genre>(item);
            return genreRepository.Update(genre);
        }
    }
}
