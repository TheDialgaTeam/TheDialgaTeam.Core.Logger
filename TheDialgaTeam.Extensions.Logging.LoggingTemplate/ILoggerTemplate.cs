#if NETSTANDARD2_0_OR_GREATER
using System;

#endif

namespace TheDialgaTeam.Extensions.Logging.LoggingTemplate
{
    public interface ILoggerTemplate<out T>
    {
        void LogTrace(string message, bool includeDefaultTemplate, params object[] args);

#if NETSTANDARD2_0_OR_GREATER
        void LogTrace(Exception exception, string message, bool includeDefaultTemplate, params object[] args);
#endif

        void LogDebug(string message, bool includeDefaultTemplate, params object[] args);

#if NETSTANDARD2_0_OR_GREATER
        void LogDebug(Exception exception, string message, bool includeDefaultTemplate, params object[] args);
#endif

        void LogInformation(string message, bool includeDefaultTemplate, params object[] args);

#if NETSTANDARD2_0_OR_GREATER
        void LogInformation(Exception exception, string message, bool includeDefaultTemplate, params object[] args);
#endif

        void LogWarning(string message, bool includeDefaultTemplate, params object[] args);

#if NETSTANDARD2_0_OR_GREATER
        void LogWarning(Exception exception, string message, bool includeDefaultTemplate, params object[] args);
#endif

        void LogError(string message, bool includeDefaultTemplate, params object[] args);

#if NETSTANDARD2_0_OR_GREATER
        void LogError(Exception exception, string message, bool includeDefaultTemplate, params object[] args);
#endif

        void LogCritical(string message, bool includeDefaultTemplate, params object[] args);

#if NETSTANDARD2_0_OR_GREATER
        void LogCritical(Exception exception, string message, bool includeDefaultTemplate, params object[] args);
#endif
    }
}