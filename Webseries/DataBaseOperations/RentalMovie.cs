
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webseries.DataBaseOperations
{
    public class RentalMovie
    {
        // Add Movie
        public bool RentMovie(string CustId, string MovieId, string IssueDate, string ReturnDate, int TotalRent)
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();
            cmd.CommandText = "prcRentMovie"; // stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MovieID", MovieId);
            cmd.Parameters.AddWithValue("@CustID", CustId);
            cmd.Parameters.AddWithValue("@RentDate", IssueDate);
            cmd.Parameters.AddWithValue("@ReturnDate", ReturnDate);
            cmd.Parameters.AddWithValue("@TotalRent", TotalRent);
            bool ans = cmd.ExecuteNonQuery() > 0;
            cmd.Dispose();
            return ans;
        }

        // Get All RentedData
        public DataTable GetAllRentedData()
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();
            // stored procedure to show all rented movies order by isuue date descending
            cmd.CommandText = "ShowRentedData"; 
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cmd.Dispose();
            return ds;
        }

       

        // Get All RentedMovie for DDL
        public DataTable GetRentedMoviesDDL()
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();
            
            cmd.CommandText = "select rm.MovieID, Title from RentedMovies rm join movies mv on rm.movieid= mv.movieid where rentedDate is not null group by Title, rm.MovieID";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cmd.Dispose();
            return ds;
        }


        // Return Movie
        public bool ReturnMovie(int MovieID, int CustId)
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();
            cmd.CommandText = "prcReturnMovie"; // stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@movieID", MovieID);
            cmd.Parameters.AddWithValue("@CustID", CustId);

            bool ans = cmd.ExecuteNonQuery() > 0;
            cmd.Dispose();
            return ans;
        }


        //Customers who borrows most movies
        public DataTable CustomersWhoBorrowMostMovies()
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();
            cmd.CommandText = "prcCustWhoBorrowMostMovies"; // store procedure
            cmd.CommandType = CommandType.StoredProcedure;
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cmd.Dispose();
            return ds;
        }

        //Most popular movies
        public DataTable MostPopularMovies()
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();
            cmd.CommandText = "prcMostPopularMovies"; // store procedure
            cmd.CommandType = CommandType.StoredProcedure;
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cmd.Dispose();
            return ds;
        }

        
    }
}
