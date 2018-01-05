using AutoMapper;
using GameStore.DataAccess.EntityModels;
using GameStore.DataAccess.Repositories;
using GameStore.Domains.Domain;
using GameStore.Services.Util;
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
            var producerEntity = AppMapper.GameStoreMapper.Map<ProducerModel, Producer>(item);
            producerRepository.Add(producerEntity);
        }

        public ICollection<ProducerModel> GetAll()
        {
            var producers = AppMapper.GameStoreMapper
                                .Map<ICollection<Producer>, ICollection<ProducerModel>>(producerRepository.GetAll());

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
                return AppMapper.GameStoreMapper.Map<Producer, ProducerModel>(producer);
            }
        }

        public void Remove(ProducerModel item)
        {
            var producer = AppMapper.GameStoreMapper.Map<ProducerModel, Producer>(item);
            producerRepository.Remove(producer);
        }

        public void Update(ProducerModel item)
        {
            var producer = AppMapper.GameStoreMapper.Map<ProducerModel, Producer>(item);
            producerRepository.Update(producer);
        }
    }
}
