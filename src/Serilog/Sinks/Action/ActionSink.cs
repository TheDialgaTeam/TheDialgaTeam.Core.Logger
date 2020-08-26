using System;
using System.IO;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;

namespace TheDialgaTeam.Core.Logger.Serilog.Sinks.Action
{
    public class ActionSink : ILogEventSink
    {
        private readonly Action<string> _outputAction;
        private readonly ITextFormatter _formatter;
        private readonly object _syncRoot;

        public ActionSink(Action<string> outputAction, ITextFormatter formatter, object syncRoot)
        {
            _outputAction = outputAction;
            _formatter = formatter;
            _syncRoot = syncRoot;
        }

        public void Emit(LogEvent logEvent)
        {
            lock (_syncRoot)
            {
                using var stringWriter = new StringWriter();
                _formatter.Format(logEvent, stringWriter);
                _outputAction(stringWriter.ToString());
            }
        }
    }
}