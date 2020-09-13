
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webseries.DataBaseOperations
{
    public class Customer
    {
        // Add customer
        public bool AddCustomer(string name,string address,string phone)
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();
            cmd.CommandText = "insert into customer(Name,Address,Phone) values(@Name,@Address,@Phone)";
            cmd.Parameters.AddWithValue("@Name",name);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Phone",phone);
            bool ans = cmd.ExecuteNonQuery() > 0;
            cmd.Dispose();
            
            return ans;
        }


        // Get My Customers
        public DataTable GetAllCustomers()
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();

            cmd.CommandText = "SELECT * FROM customer";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cmd.Dispose();
            return ds;
        }


        // Get CustomersInfo from selected Customer Id
        public string[] GetCustomersInfo(int custId)
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();
            cmd.CommandText = "SELECT * FROM customer where custId = @custId";
            cmd.Parameters.AddWithValue("@custId", custId);
            SqlDataReader reader = cmd.ExecuteReader();
            
            string[] data = null;
            if (reader.Read())
            {   
                data = new string[3];
                data[0] = reader["name"].ToString();
                data[1] = reader["address"].ToString();
                data[2] = reader["phone"].ToString();
            }
            reader.Dispose();
            cmd.Dispose();
            return data;
        }

        // Delete customer
        public bool DeleteCustomer(string CustID)
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();
            cmd.CommandText = "prcDelCust"; // stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@custId", CustID);
            bool ans = cmd.ExecuteNonQuery() > 0;
            cmd.Dispose();
            return ans;
        }


        // Update customer
        public bool UpdateCustomer(string name,string address,string phone, string CustId)
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();
            cmd.CommandText = "update customer set name=@name, address=@address, phone=@phone where custId=@custId";
            cmd.Parameters.AddWithValue("@custId", CustId);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            bool ans = cmd.ExecuteNonQuery() > 0;
            cmd.Dispose();
            return ans;
        }

    }
}
