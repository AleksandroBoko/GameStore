﻿using GameStore.Domains.Domain;
using GameStore.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void CreateGame(GameCreationTransferModel game, HttpPostedFileBase Image)
        {
            var tempGame = game;
            var path = $"~/Files/{System.IO.Path.GetFileName(Image.FileName)}";
            Image.SaveAs(Server.MapPath(path));          
        }        
    }
}