using CSV2Core.SessionSecurity;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogUtils
{
    public static class Logger
    {
        private static ILog log;

        public static void LogInfo(LogEntry logEntry)
        {
            log4net.Config.XmlConfigurator.Configure();
            log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            Thread logThread = new Thread(() => log.Info(logEntry));
            logThread.Start();
        }

        public static void LogDocAppInfo(LogEntry logEntry, string practiceName)
        {
            GlobalContext.Properties["LogDirectory"] = practiceName.Replace("\\", "").Replace(":", "").Replace("/", "").Replace("*", "").Replace("\"", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace("|", "");
            log4net.Config.XmlConfigurator.Configure();
            log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            Thread logThread = new Thread(() => log.Info(logEntry));
            logThread.Start();
        }
    }
}
