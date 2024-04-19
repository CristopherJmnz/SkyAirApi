using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetModelSkyAir.Models;
using SkyAirApi.Repositories;

namespace SkyAirApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkyAirController : ControllerBase
    {
        private ISkyAirRepository repo;
        public SkyAirController(ISkyAirRepository repo)
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

        [HttpGet("[action]/{origen}/{destino}/" +
            "{fechaIda}/{kids}/{adultos}")]
        public async Task<ActionResult<List<VueloView>>>
            SearchVuelo(string origen, string destino,
            DateTime fechaIda, int kids, int adultos)
        {
            List<VueloView> vuelos = await this.repo.SearchVueloAsync
                (origen, destino, fechaIda, kids, adultos);
            return vuelos;
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
        public async Task<ActionResult<List<Avion>>>
            GetAvionesAsync()
        {
            return await this.repo.GetAvionesAsync();
        }

        [HttpPut("[action]/{idVuelo}")]
        public async Task<ActionResult>
            CancelarVuelo(int idVuelo)
        {

            await this.repo.CancelarVuelo(idVuelo);
            return Ok();
        }

        [HttpPut("[action]/{idVuelo}/{idEstado}")]
        public async Task<ActionResult>
            CambiarEstadoVuelo(int idVuelo, int idEstado)
        {

            await this.repo.CambiarEstadoVuelo(idVuelo, idEstado);
            return Ok();
        }

        [HttpGet("[action]/{idVuelo}")]
        public async Task<ActionResult<Vuelo>>
            FindVueloById(int idVuelo)
        {
            Vuelo vuelo = await this.repo.FindVueloByIdAsync(idVuelo);
            return vuelo == null ? NotFound() : vuelo;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult>
            CreateVuelo(Vuelo vuelo)
        {

            await this.repo.CreateVuelo
                (vuelo.IdAvion, vuelo.IdOrigen, vuelo.IdDestino,
                vuelo.FechaSalida, vuelo.PrecioEstandar, vuelo.IdEstado);
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<EstadoVuelo>>>
            GetEstadosVuelo()
        {
            return await this.repo.GetEstadosVueloAsync();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<TipoClase>>>
            GetTiposClase()
        {
            return await this.repo.GetClasesAsync();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> CreateBillete(Billete billete)
        {
            await this.repo.CreateBilleteAsync
                (billete.IdVuelo, billete.EquipajeMano,
                billete.EquipajeCabina, billete.Asiento,
                billete.Precio, billete.Nombre, billete.DocumentoIdentidad,
                billete.Apellido, billete.Email, billete.TelefonoContacto,
                billete.IdClase);
            return Ok();
        }

        [HttpGet("[action]/{idVuelo}")]
        public async Task<ActionResult<List<string>>>
            GetAsientosBillete(int idVuelo)
        {
            return await this.repo
                .GetAsientosBilletesByVuelo(idVuelo);
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
