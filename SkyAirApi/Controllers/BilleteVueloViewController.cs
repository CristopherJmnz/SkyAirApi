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
            (int idBillete)
        {
            BilleteVueloView billete = await this.repo
                .FindBilleteViewByIdAsync(idBillete);

            return billete == null ? NotFound() : billete;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<BilleteVueloView>>> 
            GetBilletesViewById([FromQuery]List<int>idBillete)
        {
            return await this.repo.GetBilletesViewById(idBillete);
        }
    }
}
