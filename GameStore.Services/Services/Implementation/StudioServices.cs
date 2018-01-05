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
    public class StudioServices : IService<StudioModel>
    {
        public StudioServices(IRepository<Studio> repository)
        {
            studioRepository = repository;
        }

        private readonly IRepository<Studio> studioRepository;

        public void Add(StudioModel item)
        {
            var studioEntity = GameStoreMapper.Map<StudioModel, Studio>(item);
            studioRepository.Add(studioEntity);
        }

        public ICollection<StudioModel> GetAll()
        {
            var studios = GameStoreMapper.Map<ICollection<Studio>, ICollection<StudioModel>>
                (studioRepository.GetAll());

            return studios;
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
    }
}
