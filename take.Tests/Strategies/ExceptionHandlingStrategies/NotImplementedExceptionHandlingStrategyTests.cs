using System.Threading.Tasks;

using take.Facades.Strategies.ExceptionHandlingStrategies;
using take.Tests.Setup.Controller;

using Microsoft.AspNetCore.Http;

using NSubstitute;

using Serilog;

using Shouldly;

using Xunit;

namespace take.Tests.Strategies.ExceptionHandlingStrategies
{
    public class NotImplementedExceptionHandlingStrategyTests
    {
        private readonly ILogger _logger;

        public NotImplementedExceptionHandlingStrategyTests()
        {
            _logger = Substitute.For<ILogger>();
        }

        private NotImplementedExceptionHandlingStrategy CreateNotImplementedExceptionHandlingStrategy()
        {
            return new NotImplementedExceptionHandlingStrategy(_logger);
        }

        [Fact]
        public async Task HandleAsyncExpectedBehaviorAsync()
        {
            var notImplementedExceptionHandlingStrategy = CreateNotImplementedExceptionHandlingStrategy();

            var context = ControllerSetup.HttpContext;
            var exception = ControllerSetup.NotImplementedException;

            var result = await notImplementedExceptionHandlingStrategy.HandleAsync(
                context,
                exception);

            result.Response.StatusCode.ShouldBe(StatusCodes.Status501NotImplemented);
        }
    }
}
