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
using GameStore.DataAccess.Repositories.Implementation;

namespace GameStore.Services.Services.Implementation
{
    public class StudioServices : IStudioService
    {
        public StudioServices(IRepository<Studio> repository)
        {
            studioRepository = repository;
            gameService = new GameServices(GameRepository.GetInstance());
        }

        private readonly IRepository<Studio> studioRepository;
        private readonly IGameService gameService;

        public void Add(StudioModel item)
        {
            if(item == null)
            {
                throw new ArgumentNullException();
            }

            item.Id = Guid.NewGuid();
            var studioEntity = GameStoreMapper.Map<StudioModel, Studio>(item);
            studioRepository.Add(studioEntity);
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

        public void Remove(StudioModel item)
        {
            var studio = GameStoreMapper.Map<StudioModel, Studio>(item);
            studioRepository.Remove(studio);
        }

        public void Update(StudioModel item)
        {
            var studio = GameStoreMapper.Map<StudioModel, Studio>(item);
            studioRepository.Update(studio);
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
