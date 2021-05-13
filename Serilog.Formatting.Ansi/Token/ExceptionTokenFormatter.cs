using System;
using System.IO;
using Serilog.Events;
using Serilog.Parsing;

namespace Serilog.Formatting.Ansi.Token
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

            AnsiEscapeCodeFormatter.Format(output, $"{logEvent.Exception}{Environment.NewLine}", _propertyToken);
        }
    }
}