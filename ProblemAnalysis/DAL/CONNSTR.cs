using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class CONNSTR
    {
        public static string CONN = System.Configuration.ConfigurationManager.ConnectionStrings["QIJIConn"].ConnectionString;

    }
}
