﻿using GameStore.DataAccess.EntityModels;
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
    public class GameServices:IService<GameModel>
    {
        public GameServices(IRepository<Game> repository)
        {
            gameRepository = repository;
        }

        private readonly IRepository<Game> gameRepository;

        public ICollection<GameModel> GetAll()
        {
            var games = GameStoreMapper.Map<ICollection<Game>, ICollection<GameModel>>
                (gameRepository.GetAll());

            return games;
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
