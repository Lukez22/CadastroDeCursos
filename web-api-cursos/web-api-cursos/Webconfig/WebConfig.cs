using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api_cursos.Webconfig
{
    public class WebConfig
    {
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["lucas"].ConnectionString;
        }

        public static string GetLogFullPath()
        {
            return System.Configuration.ConfigurationManager.AppSettings["logFullPath"];
        }
    }
}