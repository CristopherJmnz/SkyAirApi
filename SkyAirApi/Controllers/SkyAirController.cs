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

    }
}
