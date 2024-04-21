using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetModelSkyAir.Models;
using SkyAirApi.Repositories;

namespace SkyAirApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposClaseController : ControllerBase
    {
        private ISkyAirRepository repo;

        public TiposClaseController(ISkyAirRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<TipoClase>>>
            GetTiposClase()
        {
            return await this.repo.GetClasesAsync();
        }
    }
}
