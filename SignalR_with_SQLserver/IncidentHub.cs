using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR_with_SQLserver
{
    public class IncidentHub : Hub
    {
        public static void Show()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<IncidentHub>();
            context.Clients.All.displayStatus();
        }
    }
}