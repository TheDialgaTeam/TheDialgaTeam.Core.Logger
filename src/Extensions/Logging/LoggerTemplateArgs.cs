using System;

namespace TheDialgaTeam.Core.Logger.Extensions.Logging
{
    public class LoggerTemplateArgs
    {
        public string? DefaultPrefixTemplate { get; set; }

        public Func<object[]>? DefaultPrefixTemplateArgs { get; set; }

        public string? DefaultPostfixTemplate { get; set; }

        public Func<object[]>? DefaultPostfixTemplateArgs { get; set; }
    }
}