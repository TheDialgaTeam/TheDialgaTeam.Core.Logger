using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace TheDialgaTeam.Core.Logger.Extensions.Logging
{
    internal class LoggerTemplate<T> : ILoggerTemplate<T>
    {
        private readonly ILogger<T> _logger;
        private readonly LoggerTemplateConfiguration _loggerTemplateConfiguration;

        public LoggerTemplate(ILogger<T> logger, LoggerTemplateConfiguration loggerTemplateConfiguration)
        {
            _logger = logger;
            _loggerTemplateConfiguration = loggerTemplateConfiguration;
        }

        public static LoggerTemplate<T> CreateLoggerTemplate(ILogger<T> logger, LoggerTemplateConfiguration loggerTemplateConfiguration)
        {
            return new LoggerTemplate<T>(logger, loggerTemplateConfiguration);
        }

        public void LogTrace(string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                GenerateAndLog(_logger.LogTrace, message, args, _loggerTemplateConfiguration.Trace);
            }
            else
            {
                _logger.LogTrace(message, args);
            }
        }

        public void LogTrace(Exception exception, string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                GenerateAndLog(_logger.LogTrace, exception, message, args, _loggerTemplateConfiguration.Trace);
            }
            else
            {
                _logger.LogTrace(exception, message, args);
            }
        }

        public void LogDebug(string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                GenerateAndLog(_logger.LogDebug, message, args, _loggerTemplateConfiguration.Debug);
            }
            else
            {
                _logger.LogDebug(message, args);
            }
        }

        public void LogDebug(Exception exception, string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                GenerateAndLog(_logger.LogDebug, exception, message, args, _loggerTemplateConfiguration.Debug);
            }
            else
            {
                _logger.LogDebug(exception, message, args);
            }
        }

        public void LogInformation(string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                GenerateAndLog(_logger.LogInformation, message, args, _loggerTemplateConfiguration.Information);
            }
            else
            {
                _logger.LogInformation(message, args);
            }
        }

        public void LogInformation(Exception exception, string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                GenerateAndLog(_logger.LogInformation, exception, message, args, _loggerTemplateConfiguration.Information);
            }
            else
            {
                _logger.LogInformation(exception, message, args);
            }
        }

        public void LogWarning(string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                GenerateAndLog(_logger.LogWarning, message, args, _loggerTemplateConfiguration.Warning);
            }
            else
            {
                _logger.LogWarning(message, args);
            }
        }

        public void LogWarning(Exception exception, string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                GenerateAndLog(_logger.LogWarning, exception, message, args, _loggerTemplateConfiguration.Warning);
            }
            else
            {
                _logger.LogWarning(exception, message, args);
            }
        }

        public void LogError(string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                GenerateAndLog(_logger.LogError, message, args, _loggerTemplateConfiguration.Error);
            }
            else
            {
                _logger.LogError(message, args);
            }
        }

        public void LogError(Exception exception, string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                GenerateAndLog(_logger.LogError, exception, message, args, _loggerTemplateConfiguration.Error);
            }
            else
            {
                _logger.LogError(exception, message, args);
            }
        }

        public void LogCritical(string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                GenerateAndLog(_logger.LogCritical, message, args, _loggerTemplateConfiguration.Critical);
            }
            else
            {
                _logger.LogCritical(message, args);
            }
        }

        public void LogCritical(Exception exception, string message, bool includeDefaultTemplate, params object[] args)
        {
            if (includeDefaultTemplate)
            {
                GenerateAndLog(_logger.LogCritical, exception, message, args, _loggerTemplateConfiguration.Critical);
            }
            else
            {
                _logger.LogCritical(exception, message, args);
            }
        }

        private (string, object[]) GenerateTemplate(string message, IEnumerable<object> args, LoggerTemplateArgs templateArgs)
        {
            var newTemplate = $"{templateArgs.DefaultPrefixTemplate ?? _loggerTemplateConfiguration.Global.DefaultPrefixTemplate ?? ""}{message}{templateArgs.DefaultPostfixTemplate ?? _loggerTemplateConfiguration.Global.DefaultPostfixTemplate ?? ""}";
            var newArgs = new List<object>();

            if (templateArgs.DefaultPrefixTemplate != null && templateArgs.DefaultPrefixTemplateArgs != null)
            {
                newArgs.AddRange(templateArgs.DefaultPrefixTemplateArgs());
            }
            else if (_loggerTemplateConfiguration.Global.DefaultPrefixTemplate != null && _loggerTemplateConfiguration.Global.DefaultPrefixTemplateArgs != null)
            {
                newArgs.AddRange(_loggerTemplateConfiguration.Global.DefaultPrefixTemplateArgs());
            }

            newArgs.AddRange(args);

            if (templateArgs.DefaultPostfixTemplate != null && templateArgs.DefaultPostfixTemplateArgs != null)
            {
                newArgs.AddRange(templateArgs.DefaultPostfixTemplateArgs());
            }
            else if (_loggerTemplateConfiguration.Global.DefaultPostfixTemplate != null && _loggerTemplateConfiguration.Global.DefaultPostfixTemplateArgs != null)
            {
                newArgs.AddRange(_loggerTemplateConfiguration.Global.DefaultPostfixTemplateArgs());
            }

            return (newTemplate, newArgs.ToArray());
        }

        private void GenerateAndLog(Action<string, object[]> logAction, string message, IEnumerable<object> args, LoggerTemplateArgs templateArgs)
        {
            var (newTemplate, newArgs) = GenerateTemplate(message, args, templateArgs);
            logAction(newTemplate, newArgs);
        }

        private void GenerateAndLog(Action<Exception, string, object[]> logAction, Exception exception, string message, IEnumerable<object> args, LoggerTemplateArgs templateArgs)
        {
            var (newTemplate, newArgs) = GenerateTemplate(message, args, templateArgs);
            logAction(exception, newTemplate, newArgs);
        }
    }
}