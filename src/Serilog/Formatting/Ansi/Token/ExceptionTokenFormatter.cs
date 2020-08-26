using System.IO;
using Serilog.Events;
using Serilog.Parsing;
using TheDialgaTeam.Core.Logger.Serilog.Formatting.Ansi.Formatter;

namespace TheDialgaTeam.Core.Logger.Serilog.Formatting.Ansi.Token
{
    internal class ExceptionTokenFormatter : ITokenFormatter
    {
        private readonly PropertyToken _propertyToken;

        public ExceptionTokenFormatter(PropertyToken propertyToken)
        {
            _propertyToken = propertyToken;
        }

        public void Format(LogEvent logEvent, TextWriter output)
        {
            if (logEvent.Exception == null) return;
            
            PaddingFormatter.Format(output, logEvent.Exception.ToString(), _propertyToken.Alignment);
            output.WriteLine();
        }
    }
}