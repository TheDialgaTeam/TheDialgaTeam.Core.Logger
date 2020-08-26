using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TheDialgaTeam.Core.Logger.Extensions.Logging
{
    public static class LoggerTemplateExtensions
    {
        public static IServiceCollection AddLoggingTemplate(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton(_ => new LoggerTemplateConfiguration());
            serviceCollection.TryAddSingleton(typeof(ILoggerTemplate<>), typeof(LoggerTemplate<>));
            return serviceCollection;
        }

        public static IServiceCollection AddLoggingTemplate(this IServiceCollection serviceCollection, LoggerTemplateConfiguration loggerTemplateConfiguration)
        {
            serviceCollection.TryAddSingleton(_ => loggerTemplateConfiguration);
            serviceCollection.TryAddSingleton(typeof(ILoggerTemplate<>), typeof(LoggerTemplate<>));
            return serviceCollection;
        }
    }
}