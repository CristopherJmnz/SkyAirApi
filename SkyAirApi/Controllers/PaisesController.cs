using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetModelSkyAir.Models;
using SkyAirApi.Repositories;

namespace SkyAirApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private ISkyAirRepository repo;
        public PaisesController(ISkyAirRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("[action]")]
        public async Task<List<Pais>> GetAllPaises()
        {
            return await this.repo.GetAllPaisesAsync();
        }
        [HttpGet("[action]/{idPais}")]
        public async Task<ActionResult<Pais>>
            FindPaisById(int idPais)
        {
            Pais pais = await this.repo
                .FindPaisByIdAsync(idPais);

            return pais != null ? pais : NotFound();
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<List<Pais>>>
            GetPaisesByContinente(int idContinente)
        {
            return await this.repo
                .GetPaisesByContinenteAsync(idContinente);
        }
    }
}
