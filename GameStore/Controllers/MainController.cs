using GameStore.Domains.Domain;
using GameStore.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameStore.Controllers
{
    public class MainController : ApiController
    {
        public MainController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        private readonly IGameService gameService;

        public IEnumerable<GameInfoTransferModel> Get() => gameService.GetGameInfoTransferAll(); 
    }
}
