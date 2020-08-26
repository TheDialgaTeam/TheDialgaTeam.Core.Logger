using System.IO;
using Serilog.Events;
using Serilog.Parsing;
using TheDialgaTeam.Core.Logger.Serilog.Formatting.Ansi.Formatter;

namespace TheDialgaTeam.Core.Logger.Serilog.Formatting.Ansi.Token
{
    internal class PropertyTokenFormatter : ITokenFormatter
    {
        private readonly PropertyToken _propertyToken;

        public PropertyTokenFormatter(PropertyToken propertyToken)
        {
            _propertyToken = propertyToken;
        }

        public void Format(LogEvent logEvent, TextWriter output)
        {
            if (!logEvent.Properties.TryGetValue(_propertyToken.PropertyName, out var logEventPropertyValue)) return;

            var writer = new StringWriter();
            logEventPropertyValue.Render(writer, _propertyToken.Format);
            AnsiEscapeCodeFormatter.Format(output, writer.ToString(), _propertyToken.Alignment);
        }
    }
}