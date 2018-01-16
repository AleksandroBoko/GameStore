using GameStore.DataAccess.EntityModels;
using GameStore.DataAccess.Repositories;
using GameStore.Domains.Domain;
using static GameStore.Services.Util.AppMapper;
using System;
using System.Collections.Generic;

namespace GameStore.Services.Services.Implementation
{
    public class GameServices : IGameService
    {
        public GameServices(IRepository<Game> repository)
        {
            gameRepository = repository;
        }

        private readonly IRepository<Game> gameRepository;

        public ICollection<GameModel> GetAll()
        {
            var games = gameRepository.GetAll();
            return GameStoreMapper.Map<ICollection<Game>, ICollection<GameModel>>(games);
        }

        public ICollection<GameInfoTransferModel> GetGameInfoTransferAll()
        {
            var games = gameRepository.GetAll();
            return GameStoreMapper.Map<ICollection<Game>, ICollection<GameInfoTransferModel>>(games);
        }

        public GameModel GetModelFromTransfer(GameCreationTransferModel transferModel)
        {
            return GameStoreMapper.Map<GameCreationTransferModel, GameModel>(transferModel);
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

        public void Add(GameModel item)
        {
            if(item == null)
            {
                throw new ArgumentNullException();
            }

            item.Id = Guid.NewGuid();
            var gameEntity = GameStoreMapper.Map<GameModel, Game>(item);
            gameRepository.Add(gameEntity);
        }

        public void Add(GameModel item, string path)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            item.Id = Guid.NewGuid();
            item.Image = path;
            var gameEntity = GameStoreMapper.Map<GameModel, Game>(item);
            gameRepository.Add(gameEntity);
        }

        public void Update(GameModel item)
        {
            var game = GameStoreMapper.Map<GameModel, Game>(item);
            gameRepository.Update(game);
        }

        public void Remove(GameModel item)
        {
            var game = GameStoreMapper.Map<GameModel, Game>(item);
            gameRepository.Remove(game);
        }
    }
}
