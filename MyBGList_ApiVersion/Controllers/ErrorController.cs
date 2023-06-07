using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MyBGList.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [EnableCors("AnyOrigin")]
    [ResponseCache(NoStore = true)]
    [Route("v{version:ApiVersion}/[controller]")]
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
