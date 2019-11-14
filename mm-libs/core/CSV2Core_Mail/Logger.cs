using log4net;

namespace CSV2Core_Mail
{
    public class Logger
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

        private Logger() { }
    }
}
