using System;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Sinks.Action.Sink;

namespace Serilog.Sinks.Action
{
    public static class ActionLoggerConfigurationExtensions
    {
        private static readonly object DefaultSyncRoot = new object();

#if NETSTANDARD2_1_OR_GREATER
        public static LoggerConfiguration Action(this LoggerSinkConfiguration sinkConfiguration, Action<string> outputAction, ITextFormatter formatter, LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum, LoggingLevelSwitch? levelSwitch = null, object? syncRoot = null)
        #else
        public static LoggerConfiguration Action(this LoggerSinkConfiguration sinkConfiguration, Action<string> outputAction, ITextFormatter formatter, LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum, LoggingLevelSwitch levelSwitch = null, object syncRoot = null)
#endif
        {
#if NETSTANDARD2_1_OR_GREATER
            syncRoot ??= DefaultSyncRoot;
#else
            syncRoot = syncRoot ?? DefaultSyncRoot;
#endif
            return sinkConfiguration.Sink(new ActionSink(outputAction, formatter, syncRoot), restrictedToMinimumLevel, levelSwitch);
        }
    }
}