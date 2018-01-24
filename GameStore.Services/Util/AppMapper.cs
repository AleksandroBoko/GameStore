using AutoMapper;
using GameStore.DataAccess.EntityModels;
using GameStore.Domains.Domain;
using System.Linq;

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
                cfg.CreateMap<GameModel, Game>()
                    .ForMember(x => x.Producers, p => p.Ignore());

                cfg.CreateMap<Studio, StudioModel>();
                cfg.CreateMap<StudioModel, Studio>();
                cfg.CreateMap<Genre, GenreModel>();
                cfg.CreateMap<GenreModel, Genre>();
                cfg.CreateMap<Game, GameInfoTransferModel>()
                    .ForMember(x => x.GenreName, s => s.MapFrom(g => g.GameGenre.Name))
                    .ForMember(x => x.StudioName, s => s.MapFrom(g => g.GameStudio.Name))
                    .ForMember(x => x.ProducersNames,
                               s => s.MapFrom(g => g.Producers.Select(p => p.Name)));

                cfg.CreateMap<Game, GameRateTransferModel>();

                cfg.CreateMap<GameCreationTransferModel, Game>()
                    .ForMember(x => x.Producers, p => p.Ignore());

                cfg.CreateMap<Studio, StudioInfoTransferModel>()
                    .ForMember(x => x.Games,
                               s => s.MapFrom(g => g.Games.Select(p => p.Name)));

                cfg.CreateMap<Genre, GenreInfoTransferModel>();
                cfg.CreateMap<Producer, ProducerInfoTransferModel>();

                cfg.CreateMap<Studio, StudioRateInfo>();
            });

            GameStoreMapper = configuration.CreateMapper();
        }
    }
}
