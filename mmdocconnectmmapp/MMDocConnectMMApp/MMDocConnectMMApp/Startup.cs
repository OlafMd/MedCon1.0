﻿using Microsoft.Owin;
using MMDocConnectMMApp;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace MMDocConnectMMApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR("/signalr", new Microsoft.AspNet.SignalR.HubConfiguration());
        }
    }
}