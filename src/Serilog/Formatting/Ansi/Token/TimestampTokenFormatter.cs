using System.IO;
using Serilog.Events;
using Serilog.Parsing;
using TheDialgaTeam.Core.Logger.Serilog.Formatting.Ansi.Formatter;

namespace TheDialgaTeam.Core.Logger.Serilog.Formatting.Ansi.Token
{
    internal class TimestampTokenFormatter : ITokenFormatter
    {
        private readonly PropertyToken _propertyToken;

        public TimestampTokenFormatter(PropertyToken propertyToken)
        {
            _propertyToken = propertyToken;
        }

        public void Format(LogEvent logEvent, TextWriter output)
        {
            PaddingFormatter.Format(output, logEvent.Timestamp.ToString(_propertyToken.Format), _propertyToken.Alignment);
        }
    }
}