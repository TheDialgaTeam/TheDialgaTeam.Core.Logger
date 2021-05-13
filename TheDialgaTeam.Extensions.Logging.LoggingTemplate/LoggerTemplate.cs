using System;
using Microsoft.Extensions.Logging;

namespace TheDialgaTeam.Extensions.Logging.LoggingTemplate
{
    internal class LoggerTemplate<T> : ILoggerTemplate<T>
    {
        private readonly ILogger<T> _logger;
        private readonly LoggerTemplateConfiguration _loggerTemplateConfiguration;

        private string DefaultTemplate => _loggerTemplateConfiguration.DefaultTemplate;
        private object[] DefaultArgs => _loggerTemplateConfiguration.DefaultArgs;

        public LoggerTemplate(ILogger<T> logger, LoggerTemplateConfiguration loggerTemplateConfiguration)
        {
            _logger = logger;
            _loggerTemplateConfiguration = loggerTemplateConfiguration;
        }

        public void LogTrace(string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                _logger.LogTrace($"{DefaultTemplate} {message}", GenerateArgsWithDefaultTemplateArgs(args));
            }
            else
            {
                _logger.LogTrace(message, args);
            }
        }

#if NETSTANDARD2_0_OR_GREATER
        public void LogTrace(Exception exception, string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                _logger.LogTrace(exception, $"{DefaultTemplate} {message}", GenerateArgsWithDefaultTemplateArgs(args));
            }
            else
            {
                _logger.LogTrace(exception, message, args);
            }
        }
#endif

        public void LogDebug(string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                _logger.LogDebug($"{DefaultTemplate} {message}", GenerateArgsWithDefaultTemplateArgs(args));
            }
            else
            {
                _logger.LogDebug(message, args);
            }
        }

#if NETSTANDARD2_0_OR_GREATER
        public void LogDebug(Exception exception, string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                _logger.LogDebug(exception, $"{DefaultTemplate} {message}", GenerateArgsWithDefaultTemplateArgs(args));
            }
            else
            {
                _logger.LogDebug(exception, message, args);
            }
        }
#endif

        public void LogInformation(string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                _logger.LogInformation($"{DefaultTemplate} {message}", GenerateArgsWithDefaultTemplateArgs(args));
            }
            else
            {
                _logger.LogInformation(message, args);
            }
        }

#if NETSTANDARD2_0_OR_GREATER
        public void LogInformation(Exception exception, string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                _logger.LogInformation(exception, $"{DefaultTemplate} {message}", GenerateArgsWithDefaultTemplateArgs(args));
            }
            else
            {
                _logger.LogInformation(exception, message, args);
            }
        }
#endif

        public void LogWarning(string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                _logger.LogWarning($"{DefaultTemplate} {message}", GenerateArgsWithDefaultTemplateArgs(args));
            }
            else
            {
                _logger.LogWarning(message, args);
            }
        }

#if NETSTANDARD2_0_OR_GREATER
        public void LogWarning(Exception exception, string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                _logger.LogWarning(exception, $"{DefaultTemplate} {message}", GenerateArgsWithDefaultTemplateArgs(args));
            }
            else
            {
                _logger.LogWarning(exception, message, args);
            }
        }
#endif

        public void LogError(string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                _logger.LogError($"{DefaultTemplate} {message}", GenerateArgsWithDefaultTemplateArgs(args));
            }
            else
            {
                _logger.LogError(message, args);
            }
        }

#if NETSTANDARD2_0_OR_GREATER
        public void LogError(Exception exception, string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                _logger.LogError(exception, $"{DefaultTemplate} {message}", GenerateArgsWithDefaultTemplateArgs(args));
            }
            else
            {
                _logger.LogError(exception, message, args);
            }
        }
#endif

        public void LogCritical(string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                _logger.LogCritical($"{DefaultTemplate} {message}", GenerateArgsWithDefaultTemplateArgs(args));
            }
            else
            {
                _logger.LogCritical(message, args);
            }
        }

#if NETSTANDARD2_0_OR_GREATER
        public void LogCritical(Exception exception, string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                _logger.LogCritical(exception, $"{DefaultTemplate} {message}", GenerateArgsWithDefaultTemplateArgs(args));
            }
            else
            {
                _logger.LogCritical(exception, message, args);
            }
        }
#endif

        private object[] GenerateArgsWithDefaultTemplateArgs(object[] args)
        {
            var defaultArgsLength = DefaultArgs.Length;
            var argsLength = args.Length;

            var newArgs = new object[defaultArgsLength + argsLength];

            Array.Copy(DefaultArgs, 0, newArgs, 0, defaultArgsLength);
            Array.Copy(args, 0, newArgs, defaultArgsLength, argsLength);

            return newArgs;
        }
    }
}