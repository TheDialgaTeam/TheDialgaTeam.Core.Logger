using System.IO;
using Serilog.Events;
using Serilog.Parsing;

namespace TheDialgaTeam.Core.Logger.Serilog.Formatting.Ansi.Token
{
    internal class MessageTokenFormatter : ITokenFormatter
    {
        private readonly PropertyToken _propertyToken;

        public MessageTokenFormatter(PropertyToken propertyToken)
        {
            _propertyToken = propertyToken;
        }

        public void Format(LogEvent logEvent, TextWriter output)
        {
            var textFormatter = new AnsiOutputTemplateTextFormatter(logEvent.MessageTemplate.Tokens);
            textFormatter.Format(logEvent, output);
        }
    }
}