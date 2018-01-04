using System;
using System.Web.Mvc;
using GameStore.Domains.Domain;
using GameStore.Services.Services;

namespace GameStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<GenreModel> genreService;

        public HomeController(IService<GenreModel> genreService)
        {
            this.genreService = genreService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}