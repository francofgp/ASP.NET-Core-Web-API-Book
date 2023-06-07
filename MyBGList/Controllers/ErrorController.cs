using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MyBGList.Controllers
{
    [EnableCors("AnyOrigin")]
    [ResponseCache(NoStore = true)]
    [Route("[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error()
        {
            return Problem();
        }

        [Route("test")]
        [HttpGet]
        public IActionResult Test()
        {
            throw new Exception("test");
        }

    }
}
