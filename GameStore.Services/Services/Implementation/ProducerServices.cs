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
    public class ProducerServices : IService<ProducerModel>
    {
        public ProducerServices(IRepository<Producer> repository)
        {
            producerRepository = repository;
        }

        private readonly IRepository<Producer> producerRepository;

        public void Add(ProducerModel item)
        {
            var producerEntity = GetEntityModel(item);
            producerRepository.Add(producerEntity);
        }

        public ICollection<ProducerModel> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Producer, ProducerModel>()
                .ForMember(x => x.Games, 
                           x => x.MapFrom(p => Mapper.Map<ICollection<Game>, ICollection<GameModel>>(p.Games)))
            );
            
            var producers = Mapper.Map<ICollection<Producer>, ICollection<ProducerModel>>
                            (producerRepository.GetAll());

            return producers;
        }

        public ProducerModel GetItemById(Guid id)
        {
            var producer = producerRepository.GetItemById(id);
            if (producer == null)
            {
                return new ProducerModel();
            }
            else
            {
                return GetModel(producer);
            }
        }

        public void Remove(ProducerModel item)
        {
            var producer = GetEntityModel(item);
            producerRepository.Remove(producer);
        }

        public void Update(ProducerModel item)
        {
            var producer = GetEntityModel(item);
            producerRepository.Update(producer);
        }

        public Producer GetEntityModel(ProducerModel producer)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProducerModel, Producer>()
                .ForMember(x => x.Games,
                           x => x.MapFrom(p => Mapper.Map<ICollection<GameModel>, ICollection<Game>>(p.Games)))
            );

            var producerEntity = Mapper.Map<ProducerModel, Producer>(producer);
            return producerEntity;
        }

        public ProducerModel GetModel(Producer producerEntity)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Producer, ProducerModel>()
                .ForMember(x => x.Games,
                           x => x.MapFrom(p => Mapper.Map<ICollection<Game>, ICollection<GameModel>>(p.Games)))
            );

            var producer = Mapper.Map<Producer, ProducerModel>(producerEntity);

            return producer;
        }
    }
}
