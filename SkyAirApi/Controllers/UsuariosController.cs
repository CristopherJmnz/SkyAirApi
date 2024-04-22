using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NugetModelSkyAir.Models;
using SkyAirApi.Helpers;
using SkyAirApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SkyAirApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private ISkyAirRepository repo;
        private HelperActionServicesOAuth helper;
        public UsuariosController
            (ISkyAirRepository repo,HelperActionServicesOAuth helper)
        {
            this.repo = repo;
            this.helper = helper;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Usuario>>LogIn(LoginModel model)
        {
            return await this.repo.LogInAsync(model.UserName,model.Password);
        }
    }
}
