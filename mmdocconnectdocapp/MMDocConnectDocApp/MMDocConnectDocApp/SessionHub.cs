using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace MediosConnectSignalR
{
    [HubName("sessionHub")]
    public class SessionHub : Hub
    {
        public void JoinGroup(string groupName)
        {
            if (groupName != null)
                Groups.Add(Context.ConnectionId, groupName);
        }
    }
}