using GameStore.Domains.Domain;
using GameStore.Services.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace GameStore.Controllers
{
    [RoutePrefix("api/genre")]
    public class GenreController : ApiController
    {
        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        private readonly IGenreService genreService;

        public IEnumerable<GenreModel> GetGenres() => genreService.GetAll();

        [Route("genregames/{id}")]
        public ICollection<GameRateTransferModel> GetGenreGames(Guid id)
        {
            var genre = genreService.GetGenreInfoTransferById(id);
            return genre != null ? genre.Games : new List<GameRateTransferModel>();
        }
    }
}
