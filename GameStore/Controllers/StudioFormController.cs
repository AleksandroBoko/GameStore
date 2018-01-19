using GameStore.Domains.Domain;
using GameStore.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.Controllers
{
    public class StudioFormController : Controller
    {
        public StudioFormController(IStudioService studioService)
        {
            this.studioService = studioService;
        }

        private readonly IStudioService studioService;

        // GET: StudioForm
        public ActionResult Form()
        {
            return View();
        }

        public void CreateStudio(StudioModel studio)
        {
            studioService.Add(studio);
        }
    }
}