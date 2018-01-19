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
        private const string URL_REDIRECT = "/Home";

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

        public RedirectResult CreateStudio(StudioModel studio)
        {
            studioService.Add(studio);
            return Redirect(URL_REDIRECT);
        }
    }
}