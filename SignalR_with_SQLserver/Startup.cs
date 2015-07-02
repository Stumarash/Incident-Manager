using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
//using Microsoft.AspNet.SignalR;
//using System.Configuration;


[assembly:OwinStartup(typeof(SignalR_with_SQLserver.Startup))]
namespace SignalR_with_SQLserver
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // GlobalHost.DependencyResolver.UseSqlServer(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
            app.MapSignalR();
        }
    }
}