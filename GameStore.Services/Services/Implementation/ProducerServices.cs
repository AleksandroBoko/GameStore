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
    public class ProducerServices : IService<ProducerModel>
    {
        public ProducerServices(IRepository<Producer> repository)
        {
            producerRepository = repository;
        }

        private readonly IRepository<Producer> producerRepository;

        public void Add(ProducerModel item)
        {
            var producerEntity = GameStoreMapper.Map<ProducerModel, Producer>(item);
            producerRepository.Add(producerEntity);
        }

        public ICollection<ProducerModel> GetAll()
        {
            var producers = GameStoreMapper.Map<ICollection<Producer>, ICollection<ProducerModel>>
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
                return GameStoreMapper.Map<Producer, ProducerModel>(producer);
            }
        }

        public void Remove(ProducerModel item)
        {
            var producer = GameStoreMapper.Map<ProducerModel, Producer>(item);
            producerRepository.Remove(producer);
        }

        public void Update(ProducerModel item)
        {
            var producer = GameStoreMapper.Map<ProducerModel, Producer>(item);
            producerRepository.Update(producer);
        }
    }
}
