using GameStore.Domains.Domain;
using System.Collections.Generic;

namespace GameStore.Services.Services
{
    public interface IGameService : IService<GameModel>
    {
        ICollection<GameInfoTransferModel> GetGameInfoTransferAll();
        GameModel GetModelFromTransfer(GameCreationTransferModel transferModel);
        void Add(GameModel item, string path);
    }
}
