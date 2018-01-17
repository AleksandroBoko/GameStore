using GameStore.Common;
using GameStore.Domains.Domain;
using GameStore.Services.Services;
using System;
using System.Web;
using System.Web.Mvc;

namespace GameStore.Controllers
{
    public class GameController : Controller
    {
        public GameController(IGenreService genreService, IStudioService studioService,
            IProducerService producerService, IGameService gameService)
        {
            this.genreService = genreService;
            this.studioService = studioService;
            this.producerService = producerService;
            this.gameService = gameService;
        }

        private readonly IGenreService genreService;
        private readonly IStudioService studioService;
        private readonly IProducerService producerService;
        private readonly IGameService gameService;

        // GET: Game
        public ActionResult GameForm()
        {
            return View();
        }

        [HttpPost]
        public void CreateGame(GameCreationTransferModel game, HttpPostedFileBase image)
        {
            if (game == null || image == null)
            {
                throw new ArgumentNullException("One of the parameters is null");
            }
            else
            {
                var gameModel = gameService.GetModelFromTransfer(game);
                var path = $"{ClientConfig.IMAGES_PATH}{System.IO.Path.GetFileName(image.FileName)}";
                gameService.Add(gameModel, System.IO.Path.GetFileName(image.FileName));
                image.SaveAs(Server.MapPath(path));
            }
        }
    }
}