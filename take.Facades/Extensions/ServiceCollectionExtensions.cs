using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using take.Facades.Strategies.ExceptionHandlingStrategies;
using take.Models;
using take.Services.Interfaces;
using take.Models.UI;
using take.Facades;
using take.Facades.Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using RestEase;

using Serilog;
using Serilog.Exceptions;

namespace take.Facades.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        private const string APPLICATION_KEY = "Application";
        private const string SETTINGS_SECTION = "Settings";

        /// <summary>
        /// Registers project's specific services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddSingletons(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection(SETTINGS_SECTION).Get<ApiSettings>();
            var githubService = RestClient.For<IGithubService>("https://api.github.com/users/takenet");

            services.AddSingleton(githubService);

            // Dependency injection
            services.AddSingleton(settings)
                    .AddSingleton(settings.BlipBotSettings)
                    .AddSingleton(githubService)
                    .AddSingleton<IRepositoriesFacade, RepositoriesFacade>();

            services.AddSingleton(provider =>
            {
                var logger = provider.GetService<ILogger>();
                return new Dictionary<Type, ExceptionHandlingStrategy>
                {
                    { typeof(ApiException), new ApiExceptionHandlingStrategy(logger) },
                    { typeof(NotImplementedException), new NotImplementedExceptionHandlingStrategy(logger) }
                };
            });

            // SERILOG settings
            services.AddSingleton<ILogger>(new LoggerConfiguration()
                     .ReadFrom.Configuration(configuration)
                     .Enrich.WithMachineName()
                     .Enrich.WithProperty(APPLICATION_KEY, Constants.PROJECT_NAME)
                     .Enrich.WithExceptionDetails()
                     .CreateLogger());
        }
    }
}
