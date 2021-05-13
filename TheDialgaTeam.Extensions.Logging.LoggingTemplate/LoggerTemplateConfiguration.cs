using System;

namespace TheDialgaTeam.Extensions.Logging.LoggingTemplate
{
    public class LoggerTemplateConfiguration
    {
        public string DefaultTemplate { get; }

        public object[] DefaultArgs { get; }

        public LoggerTemplateConfiguration()
        {
            DefaultTemplate = "{DateTimeOffset:yyyy-MM-dd HH:mm:ss}";
            DefaultArgs = new object[] { DateTimeOffset.Now };
        }

        public LoggerTemplateConfiguration(string defaultTemplate, params object[] defaultArgs)
        {
            DefaultTemplate = defaultTemplate;
            DefaultArgs = defaultArgs;
        }
    }
}