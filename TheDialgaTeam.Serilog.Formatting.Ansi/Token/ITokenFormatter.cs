using System.IO;
using Serilog.Events;

namespace TheDialgaTeam.Serilog.Formatting.Ansi.Token
{
    internal interface ITokenFormatter
    {
        void Format(LogEvent logEvent, TextWriter output);
    }
}