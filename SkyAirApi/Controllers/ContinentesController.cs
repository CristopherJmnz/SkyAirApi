using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetModelSkyAir.Models;
using SkyAirApi.Repositories;

namespace SkyAirApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinentesController : ControllerBase
    {
        private ISkyAirRepository repo;
        public ContinentesController(ISkyAirRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<Continente>>>
            GetContinentes()
        {
            return await this.repo.GetAllContinentesAsync();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<string>>>
            GetContinentesNames()
        {
            return await this.repo.GetContinentesNameAsync();
        }
    }
}
