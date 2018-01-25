using GameStore.DataAccess.EntityModels;
using GameStore.DataAccess.Repositories;
using GameStore.Domains.Domain;
using static GameStore.Services.Util.AppMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameStore.Services.Services.Implementation
{
    public class StudioServices : IStudioService
    {
        public StudioServices(IRepository<Studio> repository, IGameService gameServ)
        {
            studioRepository = repository;
            gameService = gameServ;
        }

        private readonly IRepository<Studio> studioRepository;
        private readonly IGameService gameService;

        public Guid Add(StudioModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            var studioEntity = GameStoreMapper.Map<StudioModel, Studio>(item);
            return studioRepository.Add(studioEntity);
        }

        public ICollection<StudioModel> GetAll()
        {
            var studios = studioRepository.GetAll();
            return GameStoreMapper.Map<ICollection<Studio>, ICollection<StudioModel>>(studios);
        }

        public ICollection<StudioInfoTransferModel> GetStudioInfoTransferAll()
        {
            var studios = studioRepository.GetAll();
            return GameStoreMapper.Map<ICollection<Studio>, ICollection<StudioInfoTransferModel>>(studios);
        }

        public StudioModel GetItemById(Guid id)
        {
            var studio = studioRepository.GetItemById(id);
            if (studio == null)
            {
                return new StudioModel();
            }
            else
            {
                return GameStoreMapper.Map<Studio, StudioModel>(studio);
            }
        }

        public Guid Remove(StudioModel item)
        {
            var studio = GameStoreMapper.Map<StudioModel, Studio>(item);
            return studioRepository.Remove(studio);
        }

        public Guid Update(StudioModel item)
        {
            var studio = GameStoreMapper.Map<StudioModel, Studio>(item);
            return studioRepository.Update(studio);
        }

        public ICollection<StudioRateInfo> GetAllStudiosRatings()
        {
            var studios = studioRepository.GetAll();
            var ratedStudios = GameStoreMapper.Map<ICollection<Studio>, ICollection<StudioRateInfo>>(studios);
            if (ratedStudios.Any())
            {
                foreach (var studio in ratedStudios)
                {
                    var games = gameService.GetAll();
                    if (games.Any())
                    {
                        var gamesByStudio = games.Where(x => x.StudioId == studio.Id);
                        var rate = gamesByStudio.Any() ? gamesByStudio.Average(x => x.Rate) : 0;
                        studio.Rate = Math.Round(rate, 2);
                    }
                }

                return ratedStudios.OrderByDescending(x => x.Rate).ToList();
            }
            else
            {
                return ratedStudios;
            }
        }
    }
}
