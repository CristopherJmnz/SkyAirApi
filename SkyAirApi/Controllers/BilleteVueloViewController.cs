using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetModelSkyAir.Models;
using SkyAirApi.Repositories;

namespace SkyAirApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilleteVueloViewController : ControllerBase
    {
        private ISkyAirRepository repo;
        public BilleteVueloViewController(ISkyAirRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("[action]/{apellido}/{codVuelo}")]
        public async Task<ActionResult<BilleteVueloView>>
            FindBilleteByCodigoVueloAndApellido
            (string apellido, string codVuelo)
        {
            BilleteVueloView billete = await this.repo
                .FindBilleteViewByApellidoAndIdVueloAsync
                (codVuelo, apellido);

            return billete == null ? NotFound() : billete;
        }

        [HttpGet("[action]/{idVuelo}")]
        public async Task<ActionResult<BilleteVueloView>>
            FindBilleteView
            (int idVuelo)
        {
            BilleteVueloView billete = await this.repo
                .FindBilleteViewByIdAsync(idVuelo);

            return billete == null ? NotFound() : billete;
        }
    }
}
