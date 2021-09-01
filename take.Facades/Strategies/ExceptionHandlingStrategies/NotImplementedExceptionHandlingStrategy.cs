using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;
using RestEase;
using take.Models;

namespace take.Facades.Strategies.ExceptionHandlingStrategies
{
    public class NotImplementedExceptionHandlingStrategy : ExceptionHandlingStrategy
    {
        private readonly ILogger _logger;

        public NotImplementedExceptionHandlingStrategy(ILogger logger)
        {
            _logger = logger;
        }

        public override async Task<HttpContext> HandleAsync(HttpContext context, Exception exception)
        {
            var notImplementeException = exception as NotImplementedException;
            _logger.Error(notImplementeException, "[{@user}] Error: {@exception}", context.Request.Headers[Constants.BLIP_USER_HEADER], notImplementeException.Message);
            context.Response.StatusCode = StatusCodes.Status501NotImplemented;

            return await Task.FromResult(context);
        }
    }
}
