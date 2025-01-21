using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello, world!");
        }
    }
}
