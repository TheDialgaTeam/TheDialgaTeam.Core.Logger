using System;

namespace TheDialgaTeam.Core.Logger.Extensions.Logging
{
    public interface ILoggerTemplate<T>
    {
        void LogTrace(string message, bool includeDefaultTemplate, params object[] args);

        void LogTrace(Exception exception, string message, bool includeDefaultTemplate, params object[] args);

        void LogDebug(string message, bool includeDefaultTemplate, params object[] args);

        void LogDebug(Exception exception, string message, bool includeDefaultTemplate, params object[] args);

        void LogInformation(string message, bool includeDefaultTemplate, params object[] args);

        void LogInformation(Exception exception, string message, bool includeDefaultTemplate, params object[] args);

        void LogWarning(string message, bool includeDefaultTemplate, params object[] args);

        void LogWarning(Exception exception, string message, bool includeDefaultTemplate, params object[] args);

        void LogError(string message, bool includeDefaultTemplate, params object[] args);

        void LogError(Exception exception, string message, bool includeDefaultTemplate, params object[] args);

        void LogCritical(string message, bool includeDefaultTemplate, params object[] args);

        void LogCritical(Exception exception, string message, bool includeDefaultTemplate, params object[] args);
    }
}