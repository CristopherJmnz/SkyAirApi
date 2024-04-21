using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetModelSkyAir.Models;
using SkyAirApi.Repositories;

namespace SkyAirApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosVueloController : ControllerBase
    {
        private ISkyAirRepository repo;

        public EstadosVueloController(ISkyAirRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<EstadoVuelo>>>
            GetEstadosVuelo()
        {
            return await this.repo.GetEstadosVueloAsync();
        }
    }
}
