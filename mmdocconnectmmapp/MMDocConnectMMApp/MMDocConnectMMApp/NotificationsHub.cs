using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using MMDocConnectUtils;

namespace MediosConnectSignalR
{
    [HubName("notificationsHub")]
    public class NotificationsHub : Hub
    {
        public void JoinGroup(string groupName)
        {
            if (groupName != null)
                Groups.Add(Context.ConnectionId, groupName);            
        }
    }
}