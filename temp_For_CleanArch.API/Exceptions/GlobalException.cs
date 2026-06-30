using GitHub_CleanArch.Exceptions.ExceptionTypes;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GitHub_CleanArch.Exceptions
{
    public class GlobalException : IExceptionHandler
    {
        private readonly ILogger<GlobalException> logger;

        public GlobalException(ILogger<GlobalException> logger)
        {
            this.logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError(exception, exception.Message);


            var (statuscode, title, detail) = exception switch
            {
                FluentValidation.ValidationException ve =>(StatusCodes.Status400BadRequest,
                "Validation Error",
                string.Join(" - ", ve.Errors.Select(e => e.ErrorMessage))), 

                NotFoundException ne => (StatusCodes.Status404NotFound, "NotFound Exception", exception.Message),

                _ => (StatusCodes.Status500InternalServerError, "InternalServer Exception", exception.Message)
            };


            var error = new ProblemDetails
            {
                Detail = detail,
                Status = statuscode,
                Title = title,
            };

            httpContext.Response.StatusCode = statuscode;
            await httpContext.Response.WriteAsJsonAsync(error, cancellationToken);

            return true;
        }
    }
}
