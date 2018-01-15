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
    public class StudioController : ApiController
    {
        public StudioController(IStudioService studioService)
        {
            this.studioService = studioService;
        }

        private readonly IStudioService studioService;

        [Route("api/studio/studios")]
        public IEnumerable<StudioModel> GetStudios() => studioService.GetAll();
    }
}
