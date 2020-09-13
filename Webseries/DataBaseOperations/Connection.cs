using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webseries.DataBaseOperations
{
    public class Connection
    {
        private static SqlConnection con = null;

        private Connection() { }

        //Connection with Database
        public static SqlConnection StartConnection()
        {
            if (con == null)
            {
                con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
                con.Open();
            }

            return con; // if connection object already exists, then return the last connection object
        }

        //Close the Connection from database
        public static void CloseConnection()
        {
            if (con != null)
            {
                con.Dispose();
            }
            con = null;
        }

    }
}
