using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace TravelGuide.infrastructure
{
    public static class ConnectMSSql
    {
        public static string GetConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TravelGuideLocalDB"].ConnectionString.ToString();
            }
        }
    }
}