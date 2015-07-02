using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace SignalR_with_SQLserver
{
    public class IncidentInfo
    {
        public string IncidentID { get; set; }
        public string incidentType { get; set; }
        public string status { get; set; }
        public string location { get; set; }
        public string date{get;set;}
        public string time{get;set;}
        public string dispatched{get;set;}
       // public string reporter { get; }

    }

    public class IncidentInfoRepository
    {
        private static SqlConnection connect;
        //private static string connectString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        private SqlCommand command;
        public IEnumerable<IncidentInfo> GetData()
        {
            using ( connect = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
           connect.Open();
           using ( command = new SqlCommand(@"SELECT [incidentID],[incidentType],[time],[date],[location],[incidentStatus],[dispatched] FROM [dbo].[IncidentManager]", connect))
               /**
                * set command object to null so that we can be sure that it doesn't have a notification associated to it
                * */
               command.Notification = null;
               SqlDependency dependency = new SqlDependency(command);
               dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
            if (connect.State == ConnectionState.Closed)
                connect.Open();

            using (var reader = command.ExecuteReader())
                return reader.Cast<IDataRecord>().Select(x => new IncidentInfo() { IncidentID = x.GetString(0), incidentType = x.GetString(1), status = x.GetString(2), location = x.GetString(3), date = x.GetString(4), time = x.GetString(5), dispatched = x.GetString(6) }).ToList();
        }

        //i call incidentHub(Show()) method to refresh the grid
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            IncidentHub.Show();
        }

    }
}