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

        [Route("api/main/studios")]
        public IEnumerable<StudioInfoTransferModel> GetStudios() => studioService.GetStudioInfoTransferAll();

        [Route("api/main/genres")]
        public IEnumerable<GenreModel> GetGenres() => genreService.GetAll();

        [Route("api/main/genregames/{id}")]
        public ICollection<GameRateTransferModel> GetGenreGames(Guid id)
        {
            var genre = genreService.GetGenreInfoTransferById(id);
            if (genre != null)
            {
                return genre.Games;
            }
            else
            {
                return new List<GameRateTransferModel>();
            }
        }
    }
}
