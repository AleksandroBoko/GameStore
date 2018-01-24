using GameStore.Domains.Domain;
using System;
using System.Collections.Generic;

namespace GameStore.Services.Services
{
    public interface IGameService : IService<GameModel>
    {
        ICollection<GameInfoTransferModel> GetGameInfoTransferAll();
        ICollection<GameRateTransferModel> GetTopRatedGames(int rate);
        Guid Add(GameCreationTransferModel item, string path);
    }
}
