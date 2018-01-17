using GameStore.Domains.Domain;
using System.Collections.Generic;

namespace GameStore.Services.Services
{
    public interface IGameService : IService<GameModel>
    {
        ICollection<GameInfoTransferModel> GetGameInfoTransferAll();
        ICollection<GameRateTransferModel> GetTopRatedGames(int rate);
        GameModel GetModelFromTransfer(GameCreationTransferModel transferModel);
        void Add(GameModel item, string path);
    }
}
