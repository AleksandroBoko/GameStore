using GameStore.DataAccess.EntityModels;
using GameStore.DataAccess.Repositories;
using GameStore.Domains.Domain;
using static GameStore.Services.Util.AppMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameStore.Services.Services.Implementation
{
    public class GameServices : IGameService
    {
        public GameServices(IRepository<Game> repository, IRepository<Producer> producerRep)
        {
            gameRepository = repository;
            producerRepository = producerRep;
        }

        private readonly IRepository<Game> gameRepository;
        private readonly IRepository<Producer> producerRepository;

        public ICollection<GameModel> GetAll()
        {
            var games = gameRepository.GetAll();
            return GameStoreMapper.Map<ICollection<Game>, ICollection<GameModel>>(games);
        }

        public ICollection<GameInfoTransferModel> GetGameInfoTransferAll()
        {
            var games = gameRepository.GetAll()
                .OrderByDescending(x => x.Date)
                .ToList();

            return GameStoreMapper.Map<ICollection<Game>, ICollection<GameInfoTransferModel>>(games);
        }

        public GameModel GetItemById(Guid id)
        {
            var game = gameRepository.GetItemById(id);
            if (game == null)
            {
                return new GameModel();
            }
            else
            {
                return GameStoreMapper.Map<Game, GameModel>(game);
            }
        }

        public Guid Add(GameModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            var gameEntity = GameStoreMapper.Map<GameModel, Game>(item);
            gameEntity.Producers = item.Producers.Select(x => producerRepository.GetItemById(x.Id)).ToList();
            return gameRepository.Add(gameEntity);
        }

        public Guid Add(GameCreationTransferModel item, string path)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            item.Image = path;
            var gameEntity = GameStoreMapper.Map<GameCreationTransferModel, Game>(item);

            gameEntity.Producers = item.Producers.Select(x => producerRepository.GetItemById(x)).ToList();
            return gameRepository.Add(gameEntity);
        }

        public Guid Update(GameModel item)
        {
            var game = GameStoreMapper.Map<GameModel, Game>(item);
            return gameRepository.Update(game);
        }

        public Guid Remove(GameModel item)
        {
            var game = GameStoreMapper.Map<GameModel, Game>(item);
            return gameRepository.Remove(game);
        }

        public ICollection<GameRateTransferModel> GetTopRatedGames(int rate)
        {
            var games = gameRepository.GetAll();
            var ratedGames = games.OrderByDescending(x => x.Rate).Take(rate).ToList();
            return GameStoreMapper.Map<ICollection<Game>, ICollection<GameRateTransferModel>>(ratedGames);
        }
    }
}
