using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TokenProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        [HttpGet("GetList")]
        [Authorize]
        public IEnumerable<string> Get()
        {
            var rolesClaims = HttpContext.User.Claims.Where(p => p.Type.Contains("role"));
            var principal = HttpContext.User;
            if (principal.Claims != null)
            {
                foreach (var item in principal.Claims)
                {

                }
            }
            return new string[] { "Tanju", "Bozok", ".Net Core 3.1", "Json Web Token", "Swagger", "-Authorize", "İşlemleri" };
        }

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "Authorize etiketi yok, Token kontrolü zorunlu değil.";
        }
    }
}
