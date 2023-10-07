using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PostController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is a get request");
        }
    }
}
