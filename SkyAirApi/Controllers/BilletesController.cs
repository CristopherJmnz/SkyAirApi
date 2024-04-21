using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetModelSkyAir.Models;
using SkyAirApi.Repositories;

namespace SkyAirApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilletesController : ControllerBase
    {
        private ISkyAirRepository repo;
        public BilletesController(ISkyAirRepository repo)
        {
            this.repo = repo;
        }

        [Authorize]
        [HttpPost("[action]")]
        public async Task<ActionResult> CreateBillete(Billete billete)
        {
            Billete billeteNew = await this.repo.CreateBilleteAsync
                (billete.IdVuelo, billete.EquipajeMano,
                billete.EquipajeCabina, billete.Asiento,
                billete.Precio, billete.Nombre, billete.DocumentoIdentidad,
                billete.Apellido, billete.Email, billete.TelefonoContacto,
                billete.IdClase);
            return Ok(billeteNew);
        }


        [HttpGet("[action]/{idVuelo}")]
        public async Task<ActionResult<List<string>>>
            GetAsientosBillete(int idVuelo)
        {
            return await this.repo
                .GetAsientosBilletesByVuelo(idVuelo);
        }
    }
}
