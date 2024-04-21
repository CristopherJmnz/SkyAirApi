using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetModelSkyAir.Models;
using SkyAirApi.Repositories;

namespace SkyAirApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadViewController : ControllerBase
    {
        private ISkyAirRepository repo;
        public CiudadViewController(ISkyAirRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<CiudadView>>>
            GetAllCiudadesView()
        {
            return await this.repo
                .GetAllCiudadesViewAsync();
        }

        [HttpGet("[action]/{idContinente}")]
        public async Task<ActionResult<List<CiudadView>>>
            GetCiudadesViewByContinente(int idContinente)
        {
            return await this.repo
                .GetCiudadesViewByContinenteAsync(idContinente);
        }

        [HttpGet("[action]/{idCiudad}")]
        public async Task<ActionResult<CiudadView>>
            FindCiudadViewById(int idCiudad)
        {
            return await this.repo
                .FindCiudadViewByIdAsync(idCiudad);
        }

        [HttpGet("[action]/{nombre}")]
        public async Task<ActionResult<CiudadView>>
            FindCiudadViewByName(string nombre)
        {
            return await this.repo
                .FindCiudadViewByNameAsync(nombre);
        }
    }
}
