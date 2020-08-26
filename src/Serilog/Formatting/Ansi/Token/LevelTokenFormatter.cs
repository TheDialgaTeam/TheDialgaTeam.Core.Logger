using Serilog.Events;
using Serilog.Parsing;
using System;
using System.IO;
using TheDialgaTeam.Core.Logger.Serilog.Formatting.Ansi.Formatter;

namespace TheDialgaTeam.Core.Logger.Serilog.Formatting.Ansi.Token
{
    internal class LevelTokenFormatter : ITokenFormatter
    {
        private static readonly string[][] TitleCaseLevelMap =
        {
            new[] { "V", "Vb", "Vrb", "Verb" },
            new[] { "D", "De", "Dbg", "Dbug" },
            new[] { "I", "In", "Inf", "Info" },
            new[] { "W", "Wn", "Wrn", "Warn" },
            new[] { "E", "Er", "Err", "Eror" },
            new[] { "F", "Fa", "Ftl", "Fatl" }
        };

        private static readonly string[][] LowercaseLevelMap =
        {
            new[] { "v", "vb", "vrb", "verb" },
            new[] { "d", "de", "dbg", "dbug" },
            new[] { "i", "in", "inf", "info" },
            new[] { "w", "wn", "wrn", "warn" },
            new[] { "e", "er", "err", "eror" },
            new[] { "f", "fa", "ftl", "fatl" }
        };

        private static readonly string[][] UppercaseLevelMap =
        {
            new[] { "V", "VB", "VRB", "VERB" },
            new[] { "D", "DE", "DBG", "DBUG" },
            new[] { "I", "IN", "INF", "INFO" },
            new[] { "W", "WN", "WRN", "WARN" },
            new[] { "E", "ER", "ERR", "EROR" },
            new[] { "F", "FA", "FTL", "FATL" }
        };

        private readonly PropertyToken _propertyToken;

        public LevelTokenFormatter(PropertyToken propertyToken)
        {
            _propertyToken = propertyToken;
        }

        public void Format(LogEvent logEvent, TextWriter output)
        {
            var formatStringSpan = (_propertyToken.Format ?? string.Empty).AsSpan().Trim();

            if (formatStringSpan.Length < 2)
            {
                PaddingFormatter.Format(output, logEvent.Level.ToString(), _propertyToken.Alignment);
                return;
            }

            if (int.TryParse(formatStringSpan[1..], out var formatLength))
            {
                if (formatLength < 1) return;

                switch (formatStringSpan[0])
                {
                    case 'w':
                        if (formatLength > 4)
                        {
                            var result = logEvent.Level.ToString().ToLowerInvariant().AsSpan();
                            PaddingFormatter.Format(output, result.Length >= formatLength ? result : result[..formatLength], _propertyToken.Alignment);
                        }
                        else
                        {
                            PaddingFormatter.Format(output, LowercaseLevelMap[(int) logEvent.Level][formatLength - 1], _propertyToken.Alignment);
                        }

                        break;

                    case 'u':
                        if (formatLength > 4)
                        {
                            var result = logEvent.Level.ToString().ToUpperInvariant().AsSpan();
                            PaddingFormatter.Format(output, result.Length >= formatLength ? result : result[..formatLength], _propertyToken.Alignment);
                        }
                        else
                        {
                            PaddingFormatter.Format(output, UppercaseLevelMap[(int) logEvent.Level][formatLength - 1], _propertyToken.Alignment);
                        }

                        break;

                    case 't':
                        if (formatLength > 4)
                        {
                            var result = logEvent.Level.ToString().AsSpan();
                            PaddingFormatter.Format(output, result.Length >= formatLength ? result : result[..formatLength], _propertyToken.Alignment);
                        }
                        else
                        {
                            PaddingFormatter.Format(output, TitleCaseLevelMap[(int) logEvent.Level][formatLength - 1], _propertyToken.Alignment);
                        }

                        break;

                    default:
                        PaddingFormatter.Format(output, logEvent.Level.ToString(), _propertyToken.Alignment);
                        break;
                }
            }
            else
            {
                PaddingFormatter.Format(output, logEvent.Level.ToString(), _propertyToken.Alignment);
            }
        }
    }
}