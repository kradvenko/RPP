using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RPPMain
{
    class Connection
    {
        //const String connectionString = "Data Source=SERVIDOR02;Initial Catalog=RPP_Main;Persist Security Info=True;User ID=Dev;Password=dev007";
        const String connectionString = "Data Source=192.168.137.37;Initial Catalog=RPP_Main;Persist Security Info=True;User ID=rppyc;Password=Pass123456";

        public static String getConnection()
        {
            return connectionString;
        }
    }
}
