using System;
using System.Web.Mvc;
using GameStore.Domains.Domain;
using GameStore.Services.Services;

namespace GameStore.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IService<GenreModel> genreService, IService<StudioModel> studioService,
            IService<ProducerModel> producerService, IService<GameModel> gameService)
        {
            this.genreService = genreService;
            this.studioService = studioService;
            this.producerService = producerService;
            this.gameService = gameService;
        }

        private readonly IService<GenreModel> genreService;
        private readonly IService<StudioModel> studioService;
        private readonly IService<ProducerModel> producerService;
        private readonly IService<GameModel> gameService;

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}