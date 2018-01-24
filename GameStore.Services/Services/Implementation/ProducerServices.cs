using GameStore.DataAccess.EntityModels;
using GameStore.DataAccess.Repositories;
using GameStore.Domains.Domain;
using static GameStore.Services.Util.AppMapper;
using System;
using System.Collections.Generic;

namespace GameStore.Services.Services.Implementation
{
    public class ProducerServices : IProducerService
    {
        public ProducerServices(IRepository<Producer> repository)
        {
            producerRepository = repository;
        }

        private readonly IRepository<Producer> producerRepository;

        public Guid Add(ProducerModel item)
        {
            var producerEntity = GameStoreMapper.Map<ProducerModel, Producer>(item);
            return producerRepository.Add(producerEntity);
        }

        public ICollection<ProducerModel> GetAll()
        {
            var producers = producerRepository.GetAll();
            return GameStoreMapper.Map<ICollection<Producer>, ICollection<ProducerModel>>(producers);
        }

        public ICollection<ProducerInfoTransferModel> GetProducerInfoTransferAll()
        {
            var producers = producerRepository.GetAll();
            return GameStoreMapper.Map<ICollection<Producer>, ICollection<ProducerInfoTransferModel>>(producers);
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
                return GameStoreMapper.Map<Producer, ProducerModel>(producer);
            }
        }

        public Guid Remove(ProducerModel item)
        {
            var producer = GameStoreMapper.Map<ProducerModel, Producer>(item);
            return producerRepository.Remove(producer);
        }

        public Guid Update(ProducerModel item)
        {
            var producer = GameStoreMapper.Map<ProducerModel, Producer>(item);
            return producerRepository.Update(producer);
        }
    }
}
