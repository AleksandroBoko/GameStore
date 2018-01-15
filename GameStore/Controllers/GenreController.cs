using GameStore.Domains.Domain;
using GameStore.Services.Services;
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

        [Route("getgenres")]
        public IEnumerable<GenreModel> GetGenres() => genreService.GetAll();
    }
}
