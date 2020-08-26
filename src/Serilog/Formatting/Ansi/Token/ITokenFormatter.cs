using System.IO;
using Serilog.Events;

namespace TheDialgaTeam.Core.Logger.Serilog.Formatting.Ansi.Token
{
    internal interface ITokenFormatter
    {
        void Format(LogEvent logEvent, TextWriter output);
    }
}