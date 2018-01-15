using GameStore.Domains.Domain;
using GameStore.Services.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace GameStore.Controllers
{
    [RoutePrefix("api/studio")]
    public class StudioController : ApiController
    {
        public StudioController(IStudioService studioService)
        {
            this.studioService = studioService;
        }

        private readonly IStudioService studioService;

        public IEnumerable<StudioModel> GetStudios() => studioService.GetAll();
    }
}
