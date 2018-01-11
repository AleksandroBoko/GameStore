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
        public MainController(IGameService gameService, IStudioService studioService)
        {
            this.gameService = gameService;
            this.studioService = studioService;
        }

        private readonly IGameService gameService;
        private readonly IStudioService studioService;

        [Route("api/main/games")]
        public IEnumerable<GameInfoTransferModel> GetGames() => gameService.GetGameInfoTransferAll();

        [Route("api/main/studios")]
        public IEnumerable<StudioInfoTransferModel> GetStudios() => studioService.GetStudioInfoTransferAll();

        //public IEnumerable<>
    }
}
