using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppFullStackDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("v1/test")]
        [AllowAnonymous]
        public string GetTest()
        {
            return "Api AppFullStackDemo is Working!";
        }
    }
}