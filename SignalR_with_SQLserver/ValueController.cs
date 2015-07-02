using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR_with_SQLserver
{
    //here i am creating object of IncidentInfoRepository and Get method which will be calling GetData() method
    public class ValueController
    {
        IncidentInfoRepository objRepo = new IncidentInfoRepository();
        public IEnumerable<IncidentInfo> Get()
        {
            return objRepo.GetData();
        }
    }
}