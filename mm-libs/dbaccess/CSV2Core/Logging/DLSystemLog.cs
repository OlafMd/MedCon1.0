using System;
using System.Diagnostics;

namespace CSV2Core.Logging
{
    /// <summary>
    /// Logger that logs to the system logger with 'DLCoreLog' as the log source
    /// </summary>
    public static class DLSystemLog
    {
        public static readonly string LogSource = "DLCoreLog";
        public static readonly DLLogSeverity MinimumLogLevel = DLLogSeverity.INFO;

        static DLSystemLog()
        {
            try
            {
                if (EventLog.SourceExists(LogSource) == false)
                {
                    EventLog.CreateEventSource(LogSource, LogSource);
                }
            }
            catch
            {
                //Should not be thrown here
            }
        }


        #region Logging Methods

        /// <summary>
        /// Logs the current exception to the system logs with DLLogSeverity.ERROR as the severity type
        /// </summary>
        /// <param name="ex">Exception to be logged</param>
        public static void add(Exception ex)
        {
            add(ex.Message, DLLogSeverity.ERROR, ex);
        }

        public static void add(String _Message, DLLogSeverity _LogSeverity, Exception _Ex)
        {
            EventLogEntryType SystemLogType;
            switch (_LogSeverity)
            {
                case DLLogSeverity.CRITICAL:
                case DLLogSeverity.SERIOUS:
                case DLLogSeverity.ERROR:
                    SystemLogType = EventLogEntryType.Error;
                    break;
                case DLLogSeverity.WARNING:
                case DLLogSeverity.CONFIG:
                    SystemLogType = EventLogEntryType.Warning;
                    break;
                case DLLogSeverity.INFO:
                case DLLogSeverity.DEBUG:
                    SystemLogType = EventLogEntryType.Information;
                    break;
                default:
                    SystemLogType = EventLogEntryType.Error;
                    break;
            }


            DLSystemLog.add(_Message, SystemLogType, _Ex, (int)_LogSeverity);
        }


        public static void add(String _Message, EventLogEntryType _Type, Exception _Ex, int _EventID)
        {
            try
            {
                using (EventLog systemLog = new EventLog())
                {
                    String LogMessage = DLLogSupport.GenerateLogString(_Message, _Ex);
                    systemLog.Source = LogSource;
                    systemLog.WriteEntry(LogMessage, _Type, _EventID);
                }
            }
            catch
            {

            }
        }

        #endregion
    }
}
