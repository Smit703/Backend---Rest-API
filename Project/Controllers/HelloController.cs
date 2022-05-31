using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World!!");
        }
    }
}