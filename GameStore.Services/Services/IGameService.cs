using GameStore.Domains.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services.Services
{
    public interface IGameService : IService<GameModel>
    {
        ICollection<GameInfoTransferModel> GetGameInfoTransferAll();
    }
}
