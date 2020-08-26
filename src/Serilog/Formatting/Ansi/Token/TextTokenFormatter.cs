using System.IO;
using Serilog.Events;
using TheDialgaTeam.Core.Logger.Serilog.Formatting.Ansi.Formatter;

namespace TheDialgaTeam.Core.Logger.Serilog.Formatting.Ansi.Token
{
    internal class TextTokenFormatter : ITokenFormatter
    {
        private readonly string _text;

        public TextTokenFormatter(string text)
        {
            _text = text;
        }

        public void Format(LogEvent logEvent, TextWriter output)
        {
            AnsiEscapeCodeFormatter.Format(output, _text);
        }
    }
}