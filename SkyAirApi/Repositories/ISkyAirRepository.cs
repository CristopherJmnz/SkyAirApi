using NugetModelSkyAir.Models;

namespace SkyAirApi.Repositories
{
    public interface ISkyAirRepository
    {
        #region CONTINENTES
        Task<List<Continente>> GetAllContinentesAsync();
        Task<List<string>> GetContinentesNameAsync();

        #endregion

        #region PAISES
        Task<List<Pais>> GetAllPaisesAsync();
        Task<Pais> FindPaisByIdAsync(int idPais);
        Task<List<Pais>> GetPaisesByContinenteAsync(int idContinente);

        #endregion

        #region CIUDADES VIEW
        Task<List<CiudadView>> 
            GetAllCiudadesViewAsync();
        Task<List<CiudadView>> 
            GetCiudadesViewByContinenteAsync(int idContinente);
        Task<CiudadView> 
            FindCiudadViewByIdAsync(int idCiudad);
        Task<CiudadView> 
            FindCiudadViewByNameAsync(string nombre);


        #endregion

        #region VUELOS VIEW
        Task<List<VueloView>> GetAllVuelosViewAsync();
        Task<List<VueloView>> GetVuelosViewByContinente
            (int idContinente);
        Task<List<VueloView>> GetVuelosViewByPais(int idPais);
        Task<List<VueloView>> GetVuelosViewByCiudad
            (int idCiudad);
        Task<ModelPaginacionVuelosView> GetVuelosPaginacion
            (int posicion);
        Task<VueloView> FindVueloViewByIdAsync(int idVuelo);
        Task<List<VueloView>> SearchVueloAsync
            (string origen, string destino, DateTime fechaIda,
            int kids, int adultos);
        Task<List<VueloView>> SearchVueloAsync
            (string origen, string destino, DateTime fechaIda,
            DateTime fechaVuelta, int kids, int adultos);
        #endregion

        #region CIUDADES
        Task<Ciudad> FindCiudadByIdAsync(int idCiudad);
        Task<List<Ciudad>> GetAllCiudadesAsync();

        #endregion

        #region AVIONES

        Task<List<Avion>> GetAvionesAsync();
        Task CreateAvion(string modelo, int capacidad, int velocidad);
        Task<int> GetMaxAvionIdAsync();

        #endregion


        #region VUELOS
        Task CancelarVuelo(int idVuelo);
        Task CambiarEstadoVuelo(int idVuelo, int idEstado);
        Task<Vuelo> FindVueloByIdAsync(int idVuelo);

        Task CreateVuelo
            (int idAvion, int idOrigen, int idDestino,
            DateTime fechaSalida, decimal precioEstandar, int idEstado);

        Task RestarAsientoAsync(int idVuelo);

        Task<int>GetMaxIdVuelo();

        #endregion

        #region ESTADOS VUELO

        Task<List<EstadoVuelo>> GetEstadosVueloAsync();
        #endregion

        #region TIPO CLASES

        Task<List<TipoClase>> GetClasesAsync();
        #endregion


        #region BILLETES
        Task<int> GetMaxBilleteIdAsync();
        Task <Billete> CreateBilleteAsync
            (int idVuelo, int equipajeMano, int equipajeCabina, string asiento,
            decimal precio, string nombre, string documento, string apellido,
            string email, string telefonoContacto, int idClase);
        Task<List<string>> GetAsientosBilletesByVuelo(int idVuelo);

        #endregion

        #region BilleteVueloView
        Task<BilleteVueloView> FindBilleteViewByApellidoAndIdVueloAsync(string codVuelo, string apellido);
        Task<BilleteVueloView> FindBilleteViewByIdAsync(int idBillete);
        Task<List<BilleteVueloView>> GetBilletesViewById(List<int> idBilletes); 
        #endregion

        #region USUARIOS

        Task<Usuario> LogInAsync(string email, string password);

        #endregion
    }
}
