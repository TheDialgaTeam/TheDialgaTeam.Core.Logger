using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using TheDialgaTeam.Serilog.Formatting.Ansi;
using TheDialgaTeam.Serilog.Sinks.AnsiConsole.Sink;

namespace TheDialgaTeam.Serilog.Sinks.AnsiConsole
{
    public static class ConsoleLoggerConfigurationExtensions
    {
        private static readonly object DefaultSyncRoot = new object();

        public static LoggerConfiguration AnsiConsole(this LoggerSinkConfiguration sinkConfiguration, ITextFormatter? formatter = null, LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum, LoggingLevelSwitch? levelSwitch = null, LogEventLevel standardErrorFromLevel = LogEventLevel.Error, object? syncRoot = null)
        {
            syncRoot ??= DefaultSyncRoot;
            return sinkConfiguration.Sink(new ConsoleSink(formatter ?? new AnsiOutputTemplateTextFormatter(), standardErrorFromLevel, syncRoot), restrictedToMinimumLevel, levelSwitch);
        }
    }
}