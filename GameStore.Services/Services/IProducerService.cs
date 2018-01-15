using GameStore.Domains.Domain;
using System.Collections.Generic;

namespace GameStore.Services.Services
{
    public interface IProducerService:IService<ProducerModel>
    {
        ICollection<ProducerInfoTransferModel> GetProducerInfoTransferAll();
    }
}
