using log4net;

namespace Logger
{
    public class ServerLog
    {
        private static ILog _logInstance;

        public static ILog Instance
        {
            get
            {
                if (_logInstance == null)
                {
                    _logInstance = LogManager.GetLogger("ServerLog");
                    log4net.Config.XmlConfigurator.Configure();
                }
                return _logInstance;
            }
        }

        private ServerLog() { }
    }
}