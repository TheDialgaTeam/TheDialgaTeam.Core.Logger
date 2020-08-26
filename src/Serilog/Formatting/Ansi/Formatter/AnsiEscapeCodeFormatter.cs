using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Serilog.Parsing;

namespace TheDialgaTeam.Core.Logger.Serilog.Formatting.Ansi.Formatter
{
    internal static class AnsiEscapeCodeFormatter
    {
        private const int StandardOutputHandleId = -11;
        private const int EnableVirtualTerminalProcessingMode = 4;
        private const long InvalidHandleValue = -1;

        private const string AnsiEscapeRegex = "((?:\\u001b\\[[0-9:;<=>?]*[\\s!\"#$%&'()*+,\\-./]*[@A-Z[\\]^_`a-z{|}~])|(?:\\u001b[@A-Z\\[\\]^_]))";

        private static readonly bool IsAnsiEscapeCodeSupported;

        private static readonly ConsoleColor DefaultForegroundColor;
        private static readonly ConsoleColor DefaultBackgroundColor;

        static AnsiEscapeCodeFormatter()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                IsAnsiEscapeCodeSupported = true;
            }
            else
            {
                var stdout = GetStdHandle(StandardOutputHandleId);

                if (stdout != (IntPtr) InvalidHandleValue && GetConsoleMode(stdout, out var mode))
                {
                    IsAnsiEscapeCodeSupported = SetConsoleMode(stdout, mode | EnableVirtualTerminalProcessingMode);
                }
                else
                {
                    IsAnsiEscapeCodeSupported = false;
                }
            }

            DefaultForegroundColor = Console.ForegroundColor;
            DefaultBackgroundColor = Console.BackgroundColor;
        }

        public static void Format(TextWriter textWriter, string text, Alignment? alignment = null)
        {
            var isCompatibleAnsiOutput = textWriter == Console.Out || textWriter == Console.Error;

            if (isCompatibleAnsiOutput)
            {
                if (IsAnsiEscapeCodeSupported)
                {
                    PaddingFormatter.Format(textWriter, text, alignment);
                }
                else
                {
                    var ansiTokens = Regex.Matches(text, AnsiEscapeRegex);

                    if (ansiTokens.Count == 0)
                    {
                        PaddingFormatter.Format(textWriter, text, alignment);
                        return;
                    }

                    var textSpan = text.AsSpan();
                    var textSpanLength = textSpan.Length;
                    var currentIndex = 0;

                    foreach (Match ansiToken in ansiTokens)
                    {
                        var ansiTokenIndex = ansiToken.Index;
                        var ansiTokenIndexOffset = ansiTokenIndex - currentIndex;
                        var ansiTokenLength = ansiToken.Length;

                        if (currentIndex == ansiTokenIndex)
                        {
                            currentIndex += ansiTokenLength;
                        }
                        else if (currentIndex < ansiTokenIndex)
                        {
                            textWriter.Write(textSpan.Slice(currentIndex, ansiTokenIndexOffset));
                            currentIndex += ansiTokenIndexOffset + ansiTokenLength;
                        }

                        switch (ansiToken.Value)
                        {
                            case AnsiEscapeCodeConstants.BlackForegroundColor:
                                Console.ForegroundColor = ConsoleColor.Black;
                                break;

                            case AnsiEscapeCodeConstants.DarkRedForegroundColor:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;

                            case AnsiEscapeCodeConstants.DarkGreenForegroundColor:
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;

                            case AnsiEscapeCodeConstants.DarkYellowForegroundColor:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                break;

                            case AnsiEscapeCodeConstants.DarkBlueForegroundColor:
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                break;

                            case AnsiEscapeCodeConstants.DarkMagentaForegroundColor:
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                break;

                            case AnsiEscapeCodeConstants.DarkCyanForegroundColor:
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                break;

                            case AnsiEscapeCodeConstants.DarkGrayForegroundColor:
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                break;

                            case AnsiEscapeCodeConstants.GrayForegroundColor:
                            case "\u001b[30;1m":
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;

                            case AnsiEscapeCodeConstants.RedForegroundColor:
                            case "\u001b[31;1m":
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;

                            case AnsiEscapeCodeConstants.GreenForegroundColor:
                            case "\u001b[32;1m":
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;

                            case AnsiEscapeCodeConstants.YellowForegroundColor:
                            case "\u001b[33;1m":
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;

                            case AnsiEscapeCodeConstants.BlueForegroundColor:
                            case "\u001b[34;1m":
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;

                            case AnsiEscapeCodeConstants.MagentaForegroundColor:
                            case "\u001b[35;1m":
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;

                            case AnsiEscapeCodeConstants.CyanForegroundColor:
                            case "\u001b[36;1m":
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;

                            case AnsiEscapeCodeConstants.WhiteForegroundColor:
                            case "\u001b[37;1m":
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            case AnsiEscapeCodeConstants.BlackBackgroundColor:
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            case AnsiEscapeCodeConstants.DarkRedBackgroundColor:
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                break;

                            case AnsiEscapeCodeConstants.DarkGreenBackgroundColor:
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                break;

                            case AnsiEscapeCodeConstants.DarkYellowBackgroundColor:
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                break;

                            case AnsiEscapeCodeConstants.DarkBlueBackgroundColor:
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                break;

                            case AnsiEscapeCodeConstants.DarkMagentaBackgroundColor:
                                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                break;

                            case AnsiEscapeCodeConstants.DarkCyanBackgroundColor:
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                break;

                            case AnsiEscapeCodeConstants.DarkGrayBackgroundColor:
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                break;

                            case AnsiEscapeCodeConstants.GrayBackgroundColor:
                            case "\u001b[40;1m":
                                Console.BackgroundColor = ConsoleColor.Gray;
                                break;

                            case AnsiEscapeCodeConstants.RedBackgroundColor:
                            case "\u001b[41;1m":
                                Console.BackgroundColor = ConsoleColor.Red;
                                break;

                            case AnsiEscapeCodeConstants.GreenBackgroundColor:
                            case "\u001b[42;1m":
                                Console.BackgroundColor = ConsoleColor.Green;
                                break;

                            case AnsiEscapeCodeConstants.YellowBackgroundColor:
                            case "\u001b[43;1m":
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                break;

                            case AnsiEscapeCodeConstants.BlueBackgroundColor:
                            case "\u001b[44;1m":
                                Console.BackgroundColor = ConsoleColor.Blue;
                                break;

                            case AnsiEscapeCodeConstants.MagentaBackgroundColor:
                            case "\u001b[45;1m":
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                break;

                            case AnsiEscapeCodeConstants.CyanBackgroundColor:
                            case "\u001b[46;1m":
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                break;

                            case AnsiEscapeCodeConstants.WhiteBackgroundColor:
                            case "\u001b[47;1m":
                                Console.BackgroundColor = ConsoleColor.White;
                                break;

                            case AnsiEscapeCodeConstants.Reset:
                                Console.ForegroundColor = DefaultForegroundColor;
                                Console.BackgroundColor = DefaultBackgroundColor;
                                break;
                        }
                    }

                    if (currentIndex < textSpanLength)
                    {
                        textWriter.Write(textSpan.Slice(currentIndex, textSpanLength - currentIndex));
                    }
                }
            }
            else
            {
                PaddingFormatter.Format(textWriter, Regex.Replace(text, AnsiEscapeRegex, string.Empty), alignment);
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int handleId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetConsoleMode(IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleMode(IntPtr handle, int mode);
    }
}