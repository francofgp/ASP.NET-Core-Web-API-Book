using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyBGList.Constants;

namespace MyBGList.Controllers
{
    [EnableCors("AnyOrigin")]
    [ResponseCache(NoStore = true)]
    [Route("[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase

    {
        private readonly ILogger<BoardGamesController> _logger;
        public ErrorController(
            ILogger<BoardGamesController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IResult Error()
        {
            var context = HttpContext;
            var exceptionHandler = context.Features.Get<IExceptionHandlerPathFeature>();
            // TODO: logging, sending notifications, and more
            var details = new ProblemDetails();
            details.Detail = exceptionHandler?.Error.Message;
            details.Extensions["traceId"] =
            System.Diagnostics.Activity.Current?.Id ?? context.TraceIdentifier;
            details.Type =
            "https:/ /tools.ietf.org/html/rfc7231#section-6.6.1";
            details.Status = StatusCodes.Status500InternalServerError;

            _logger.LogError(
                CustomLogEvents.Error_Get,
                exceptionHandler?.Error,
            "An unhandled exception occurred.");

            return Results.Problem(details);

        }

        [Route("test")]
        [HttpGet]
        public IActionResult Test()
        {
            throw new Exception("test de error");
        }

    }
}
