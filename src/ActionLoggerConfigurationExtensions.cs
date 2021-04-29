using System;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using TheDialgaTeam.Core.Logger.Sink;

namespace TheDialgaTeam.Core.Logger
{
    public static class ActionLoggerConfigurationExtensions
    {
        private static readonly object DefaultSyncRoot = new object();

        public static LoggerConfiguration Action(this LoggerSinkConfiguration sinkConfiguration, Action<string> outputAction, ITextFormatter formatter, LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum, LoggingLevelSwitch? levelSwitch = null, LogEventLevel standardErrorFromLevel = LogEventLevel.Error, object? syncRoot = null)
        {
            syncRoot ??= DefaultSyncRoot;
            return sinkConfiguration.Sink(new ActionSink(outputAction, formatter, syncRoot), restrictedToMinimumLevel, levelSwitch);
        }
    }
}