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
    [RoutePrefix("api/producer")]
    public class ProducerController : ApiController
    {
        public ProducerController(IProducerService producerService)
        {
            this.producerService = producerService;
        }

        private readonly IProducerService producerService;

        public IEnumerable<ProducerInfoTransferModel> GetProducers() => producerService.GetProducerInfoTransferAll();
    }
}
