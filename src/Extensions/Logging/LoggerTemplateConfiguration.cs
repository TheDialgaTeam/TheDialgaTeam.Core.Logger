using System;

namespace TheDialgaTeam.Core.Logger.Extensions.Logging
{
    public class LoggerTemplateConfiguration
    {
        public LoggerTemplateArgs Trace { get; } = new LoggerTemplateArgs();

        public LoggerTemplateArgs Debug { get; } = new LoggerTemplateArgs();

        public LoggerTemplateArgs Information { get; } = new LoggerTemplateArgs();

        public LoggerTemplateArgs Warning { get; } = new LoggerTemplateArgs();

        public LoggerTemplateArgs Error { get; } = new LoggerTemplateArgs();

        public LoggerTemplateArgs Critical { get; } = new LoggerTemplateArgs();

        public LoggerTemplateArgs Global { get; } = new LoggerTemplateArgs();

        public LoggerTemplateConfiguration()
        {
            Global.DefaultPrefixTemplate = "{DateTimeOffset:yyyy-MM-dd HH:mm:ss} ";
            Global.DefaultPrefixTemplateArgs = () => new object[] { DateTimeOffset.Now };
        }

        public LoggerTemplateConfiguration(Action<LoggerTemplateConfiguration> configureAction)
        {
            configureAction(this);
        }
    }
}