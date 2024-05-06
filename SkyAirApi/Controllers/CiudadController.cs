using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetModelSkyAir.Models;
using SkyAirApi.Repositories;

namespace SkyAirApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private ISkyAirRepository repo;

        public CiudadController(ISkyAirRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("[action]/{idCiudad}")]
        public async Task<ActionResult<Ciudad>>
            FindCiudadById(int idCiudad)
        {
            Ciudad ciudad = await this.repo.FindCiudadByIdAsync(idCiudad);
            return ciudad == null ? NotFound() : ciudad;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<Ciudad>>>
            GetAllCiudades()
        {
            return await this.repo.GetAllCiudadesAsync();
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<List<string>>>
            GetCiudadesMasVisitadas()
        {
            return await this.repo.GetCiudadesMasVisitadas();
        }
    }
}
