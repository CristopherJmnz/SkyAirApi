using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetModelSkyAir.Models;
using SkyAirApi.Repositories;

namespace SkyAirApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosViewController : ControllerBase
    {
        private ISkyAirRepository repo;
        public VuelosViewController(ISkyAirRepository repo)
        {
            this.repo = repo;
        }


        [HttpGet("[action]")]
        public async Task<ActionResult<List<VueloView>>>
    GetAllVuelosView()
        {
            return await this.repo
                .GetAllVuelosViewAsync();
        }

        [HttpGet("[action]/{idContinente}")]
        public async Task<ActionResult<List<VueloView>>>
    GetVuelosViewByContinente(int idContinente)
        {
            return await this.repo
                .GetVuelosViewByContinente(idContinente);
        }

        [HttpGet("[action]/{idPais}")]
        public async Task<ActionResult<List<VueloView>>>
    GetVuelosViewByPais(int idPais)
        {
            return await this.repo
                .GetVuelosViewByPais(idPais);
        }

        [HttpGet("[action]/{idCiudad}")]
        public async Task<ActionResult<List<VueloView>>>
    GetVuelosViewByCiudad(int idCiudad)
        {
            return await this.repo
                .GetVuelosViewByCiudad(idCiudad);
        }

        [HttpGet("[action]/{posicion}")]
        public async Task<ActionResult<ModelPaginacionVuelosView>>
            GetVuelosPaginacion(int posicion)
        {
            return await this.repo.GetVuelosPaginacion(posicion);
        }

        [HttpGet("[action]/{idVuelo}")]
        public async Task<ActionResult<VueloView>>
            FindVueloViewById(int idVuelo)
        {
            return await this.repo
                .FindVueloViewByIdAsync(idVuelo);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<List<VueloView>>>
            SearchVuelo(ModelSearchVuelo model)
        {
            List<VueloView> vuelos = await this.repo.SearchVueloAsync
                (model.Origen, model.Destino, model.FechaIda, model.Kids, model.Adultos);
            return vuelos;
        }

    }
}
