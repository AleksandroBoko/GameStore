using AutoMapper;
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
    public class StudioServices : IService<StudioModel>
    {
        public StudioServices(IRepository<Studio> repository)
        {
            studioRepository = repository;
        }

        private readonly IRepository<Studio> studioRepository;

        public void Add(StudioModel item)
        {
            var studioEntity = GetEntityModel(item);
            studioRepository.Add(studioEntity);
        }

        public ICollection<StudioModel> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Studio, StudioModel>());
            var studios = Mapper.Map<ICollection<Studio>, ICollection<StudioModel>>(studioRepository.GetAll());

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
                return GetModel(studio);
            }
        }

        public void Remove(StudioModel item)
        {
            var studio = GetEntityModel(item);
            studioRepository.Remove(studio);
        }

        public void Update(StudioModel item)
        {
            var studio = GetEntityModel(item);
            studioRepository.Update(studio);
        }

        public Studio GetEntityModel(StudioModel studio)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<StudioModel, Studio>());
            var studioEntity = Mapper.Map<StudioModel, Studio>(studio);
            return studioEntity;
        }

        public StudioModel GetModel(Studio studioEntity)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Studio, StudioModel>());
            var studio = Mapper.Map<Studio, StudioModel>(studioEntity);
            return studio;
        }
    }
}
