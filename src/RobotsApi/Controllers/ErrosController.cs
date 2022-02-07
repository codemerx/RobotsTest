using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RobotsParser.Exceptions;
using RobotsService.Exceptions;
using System.Net;

namespace RobotsApi.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error-development")]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return this.NotFound();
            }

            IExceptionHandlerFeature? context =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            Exception exception = context.Error;
            HttpStatusCode code = GetStatusCode(exception);

            return this.Problem(
                detail: exception.StackTrace,
                title: exception.Message,
                statusCode: (int)code);
        }

        [Route("error")]
        public IActionResult Error()
        {
            IExceptionHandlerFeature context = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            Exception exception = context.Error;
            HttpStatusCode code = GetStatusCode(exception);
            
            if (code != HttpStatusCode.InternalServerError)
            {
                return this.Problem(
                    title: exception.Message,
                    statusCode: (int)code);
            }
            else
            {
                return this.Problem();
            }
        }

        private static HttpStatusCode GetStatusCode(Exception exception)
        {
            HttpStatusCode code = HttpStatusCode.InternalServerError;

            if (exception is GridNotFoundException) code = HttpStatusCode.NotFound;
            else if (exception is InvalidInputException) code = HttpStatusCode.BadRequest;

            return code;
        }
    }
}
