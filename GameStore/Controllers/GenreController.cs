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
    public class GenreController : ApiController
    {
        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        private readonly IGenreService genreService;

        [Route("api/genre/genres")]
        public IEnumerable<GenreModel> GetGenres() => genreService.GetAll();
    }
}
