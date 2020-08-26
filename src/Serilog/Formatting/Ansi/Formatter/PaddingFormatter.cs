using System;
using System.IO;
using Serilog.Parsing;

namespace TheDialgaTeam.Core.Logger.Serilog.Formatting.Ansi.Formatter
{
    internal static class PaddingFormatter
    {
        public static void Format(TextWriter textWriter, string text, Alignment? alignment)
        {
            var textLength = text.Length;

            if (alignment == null || textLength >= alignment.Value.Width)
            {
                textWriter.Write(text);
            }
            else
            {
                var amountToPad = alignment.Value.Width - textLength;

                if (alignment.Value.Direction == AlignmentDirection.Left)
                {
                    textWriter.Write(text);
                }

                for (var i = amountToPad - 1; i >= 0; i--)
                {
                    textWriter.Write(' ');
                }

                if (alignment.Value.Direction == AlignmentDirection.Right)
                {
                    textWriter.Write(text);
                }
            }
        }

        public static void Format(TextWriter textWriter, ReadOnlySpan<char> text, Alignment? alignment)
        {
            var textLength = text.Length;

            if (alignment == null || textLength >= alignment.Value.Width)
            {
                textWriter.Write(text);
            }
            else
            {
                var amountToPad = alignment.Value.Width - textLength;

                if (alignment.Value.Direction == AlignmentDirection.Left)
                {
                    textWriter.Write(text);
                }

                for (var i = amountToPad - 1; i >= 0; i--)
                {
                    textWriter.Write(' ');
                }

                if (alignment.Value.Direction == AlignmentDirection.Right)
                {
                    textWriter.Write(text);
                }
            }
        }
    }
}