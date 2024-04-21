using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetModelSkyAir.Models;
using SkyAirApi.Repositories;

namespace SkyAirApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        private ISkyAirRepository repo;
        public VuelosController(ISkyAirRepository repo)
        {
            this.repo = repo;
        }

        [Authorize]
        [HttpPut("[action]/{idVuelo}")]
        public async Task<ActionResult>
            CancelarVuelo(int idVuelo)
        {

            await this.repo.CancelarVuelo(idVuelo);
            return Ok();
        }

        [Authorize]
        [HttpPut("[action]/{idVuelo}/{idEstado}")]
        public async Task<ActionResult>
            CambiarEstadoVuelo(int idVuelo, int idEstado)
        {

            await this.repo.CambiarEstadoVuelo(idVuelo, idEstado);
            return Ok();
        }

        [Authorize]
        [HttpGet("[action]/{idVuelo}")]
        public async Task<ActionResult<Vuelo>>
            FindVueloById(int idVuelo)
        {
            Vuelo vuelo = await this.repo.FindVueloByIdAsync(idVuelo);
            return vuelo == null ? NotFound() : vuelo;
        }

        [Authorize]
        [HttpPost("[action]")]
        public async Task<ActionResult>
            CreateVuelo(Vuelo vuelo)
        {

            await this.repo.CreateVuelo
                (vuelo.IdAvion, vuelo.IdOrigen, vuelo.IdDestino,
                vuelo.FechaSalida, vuelo.PrecioEstandar, vuelo.IdEstado);
            return Ok();
        }
    }
}
