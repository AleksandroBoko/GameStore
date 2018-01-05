using AutoMapper;
using GameStore.DataAccess.EntityModels;
using GameStore.DataAccess.Repositories;
using GameStore.Domains.Domain;
using static GameStore.Services.Util.AppMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services.Services.Implementation
{
    public class GenreServices : IService<GenreModel>
    {
        public GenreServices(IRepository<Genre> repository)
        {
            genreRepository = repository;
        }

        private readonly IRepository<Genre> genreRepository;

        public void Add(GenreModel item)
        {
            var genreEntity = GameStoreMapper.Map<GenreModel, Genre>(item);
            genreRepository.Add(genreEntity);
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
            if (genre == null)
            {
                return new GenreModel();
            }
            else
            {
                return GameStoreMapper.Map<Genre, GenreModel>(genre);
            }
        }

        public void Remove(GenreModel item)
        {
            var genre = GameStoreMapper.Map<GenreModel, Genre>(item);
            genreRepository.Remove(genre);
        }

        public void Update(GenreModel item)
        {
            var genre = GameStoreMapper.Map<GenreModel, Genre>(item);
            genreRepository.Update(genre);
        }
    }
}
