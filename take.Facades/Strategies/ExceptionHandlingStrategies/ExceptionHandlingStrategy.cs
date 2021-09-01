using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace take.Facades.Strategies.ExceptionHandlingStrategies
{
    public abstract class ExceptionHandlingStrategy
    {
        public abstract Task<HttpContext> HandleAsync(HttpContext context, Exception exception);
    }
}
