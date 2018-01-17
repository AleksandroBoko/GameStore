using GameStore.Domains.Domain;
using GameStore.Services.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace GameStore.Controllers
{
    public class MainController : ApiController
    {
        public MainController(IGameService gameService, IStudioService studioService,
            IGenreService genreService)
        {
            this.gameService = gameService;
            this.studioService = studioService;
            this.genreService = genreService;
        }

        private readonly IGameService gameService;
        private readonly IStudioService studioService;
        private readonly IGenreService genreService;

        [Route("api/main/games")]
        public IEnumerable<GameInfoTransferModel> GetGames() => gameService.GetGameInfoTransferAll();
    }
}
