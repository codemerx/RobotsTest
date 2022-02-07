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
        private readonly ILogger<ErrorsController> logger;

        public ErrorsController(ILogger<ErrorsController> logger)
        {
            this.logger = logger;
        }

        [Route("error-development")]
        public ActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return this.NotFound();
            }

            IExceptionHandlerFeature context = this.HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            if (context == null)
            {
                return this.NotFound();
            }

            Exception exception = context.Error;
            HttpStatusCode code = GetStatusCode(exception);

            this.logger.LogError(exception, "An exception was thrown with message \"{ExceptionMessage}\". Status code \"{StatusCode}\"", exception.Message, code);

            return this.Problem(
                detail: exception.StackTrace,
                title: exception.Message,
                statusCode: (int)code);
        }

        [Route("error")]
        public ActionResult Error()
        {
            IExceptionHandlerFeature context = this.HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            if (context == null)
            {
                return this.NotFound();
            }

            Exception exception = context.Error;
            HttpStatusCode code = GetStatusCode(exception);

            this.logger.LogError(exception, "An exception was thrown with message \"{ExceptionMessage}\". Status code \"{StatusCode}\"", exception.Message, code);

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
