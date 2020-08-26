using System;
using System.IO;
using Serilog.Events;
using Serilog.Parsing;
using TheDialgaTeam.Core.Logger.Serilog.Formatting.Ansi.Formatter;

namespace TheDialgaTeam.Core.Logger.Serilog.Formatting.Ansi.Token
{
    internal class NewLineTokenFormatter : ITokenFormatter
    {
        private readonly PropertyToken _propertyToken;

        public NewLineTokenFormatter(PropertyToken propertyToken)
        {
            _propertyToken = propertyToken;
        }

        public void Format(LogEvent logEvent, TextWriter output)
        {
            PaddingFormatter.Format(output, Environment.NewLine, _propertyToken.Alignment);
        }
    }
}