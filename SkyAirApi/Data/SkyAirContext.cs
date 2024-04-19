using Microsoft.EntityFrameworkCore;
using NugetModelSkyAir.Models;

namespace SkyAirApi.Data
{
    public class SkyAirContext : DbContext
    {
        public SkyAirContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Continente> Continentes { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Avion> Aviones { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<CiudadView> CiudadesView { get; set; }
        public DbSet<VueloView> VuelosView { get; set; }
        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<TipoClase> Clases { get; set; }
        public DbSet<Billete> Billetes { get; set; }
        public DbSet<BilleteVueloView> BilletesView { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<EstadoVuelo> Estados { get; set; }
    }
}
