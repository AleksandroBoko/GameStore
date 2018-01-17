using GameStore.Domains.Domain;
using GameStore.Services.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace GameStore.Controllers
{
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        public GameController(IGameService gameService, IStudioService studioService,
            IGenreService genreService)
        {
            this.gameService = gameService;
            this.studioService = studioService;
            this.genreService = genreService;
        }

        private readonly IGameService gameService;
        private readonly IStudioService studioService;
        private readonly IGenreService genreService;

        [Route("{id}")]
        public ICollection<GameRateTransferModel> GetGamesByGenreId(Guid id)
        {
            var genre = genreService.GetGenreInfoTransferById(id);
            return genre != null ? genre.Games : new List<GameRateTransferModel>();
        }

        public IEnumerable<GameInfoTransferModel> GetGames() => gameService.GetGameInfoTransferAll();
    }
}
