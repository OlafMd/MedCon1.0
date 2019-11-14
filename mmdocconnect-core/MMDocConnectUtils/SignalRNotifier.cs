using System;
using System.Collections.Generic;

namespace MMDocConnectUtils
{
    public class SignalRNotifier
    {
        private static object lockObj = new object();

        public List<string> usersThatAreAlreadyReceievingNotifications { get; set; }

        public List<string> userSessionTokens { get; set; }

        public List<string> usersThatAreAlreadyReceievingNewDashboardData { get; set; }

        public Dictionary<string, TileInfo> lastSentDashboardData { get; set; }

        public Dictionary<string, TileInfo> lastSentNotificationData { get; set; }

        private static volatile SignalRNotifier _instance;
        private SignalRNotifier()
        {
            usersThatAreAlreadyReceievingNotifications = new List<string>();
            usersThatAreAlreadyReceievingNewDashboardData = new List<string>();
            lastSentDashboardData = new Dictionary<string, TileInfo>();
            lastSentNotificationData = new Dictionary<string, TileInfo>();
            userSessionTokens = new List<string>();
        }

        public static SignalRNotifier Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObj)
                    {

                        if (_instance == null)
                        {
                            _instance = new SignalRNotifier();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}
