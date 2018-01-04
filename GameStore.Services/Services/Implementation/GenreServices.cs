﻿using AutoMapper;
using GameStore.DataAccess.EntityModels;
using GameStore.DataAccess.Repositories;
using GameStore.Domains.Domain;
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
            var genreEntity = GetEntityModel(item);
            genreRepository.Add(genreEntity);
        }

        public ICollection<GenreModel> GetAll()
        {
            var genres = genreRepository.GetAll();
            var genreModels = new List<GenreModel>();
            if (genres.Any())
            {
                genreModels = genres.Select(x => GetModel(x)).ToList();
            }

            return genreModels;
        }

        public GenreModel GetItemById(Guid id)
        {
            var genre = genreRepository.GetItemById(id);
            return genre == null ? new GenreModel() : GetModel(genre);
        }

        public void Remove(GenreModel item)
        {
            var genre = GetEntityModel(item);
            genreRepository.Remove(genre);
        }

        public void Update(GenreModel item)
        {
            var genre = GetEntityModel(item);
            genreRepository.Update(genre);
        }

        public Genre GetEntityModel(GenreModel genre)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<GenreModel, Genre>());
            Genre genreEntity = Mapper.Map<GenreModel, Genre>(genre);
            return genreEntity;
        }

        public GenreModel GetModel(Genre genreEntity)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Genre, GenreModel>());
            GenreModel genre = Mapper.Map<Genre, GenreModel>(genreEntity);
            return genre;
        }
    }
}