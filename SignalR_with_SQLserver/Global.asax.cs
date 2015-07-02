using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Microsoft.AspNet.SignalR;
using System.Web.Routing;


namespace SignalR_with_SQLserver
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //RouteTable.Routes.MapHubs();
           // RouteConfig.RegisterRoutes();

            SqlDependency.Start(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            SqlDependency.Stop(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
        }
    }
}