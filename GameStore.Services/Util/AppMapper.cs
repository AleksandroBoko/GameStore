using AutoMapper;
using GameStore.DataAccess.EntityModels;
using GameStore.Domains.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services.Util
{
    public static class AppMapper
    {
        static AppMapper()
        {
            InitializeMapper();
        }

        public static IMapper GameStoreMapper;

        private static void InitializeMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Producer, ProducerModel>();
                cfg.CreateMap<ProducerModel, Producer>();
                cfg.CreateMap<Game, GameModel>();
                cfg.CreateMap<GameModel, Game>();
                cfg.CreateMap<Studio, StudioModel>();
                cfg.CreateMap<StudioModel, Studio>();
                cfg.CreateMap<Genre, GenreModel>();
                cfg.CreateMap<GenreModel, Genre>();
            });

            GameStoreMapper = configuration.CreateMapper();
        }
    }
}
