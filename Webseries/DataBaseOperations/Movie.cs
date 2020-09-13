
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webseries.DataBaseOperations
{
    public class Movie
    {
        // Add Movie
        public bool AddMovie(string Title, string Year, string Rating, string Genre, string RentCost)
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();
            cmd.CommandText = "insert into WebSeries values(@Title,@Year,@RentCost,@Genre,@Rating)";
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Year", Year);
            cmd.Parameters.AddWithValue("@RentCost", RentCost);
            cmd.Parameters.AddWithValue("@Genre", Genre);
            cmd.Parameters.AddWithValue("@Rating", Rating);
           
            bool ans = cmd.ExecuteNonQuery() > 0;
            cmd.Dispose();
            return ans;
        }

        // Get My Movies
        public DataTable GetAllMovies()
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();

            cmd.CommandText = "SELECT * FROM WebSeries";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cmd.Dispose();
            return ds;
        }

        // Get Available Movies for comboBox
        public DataTable GetMoviesForDDL()
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();
            cmd.CommandText = "SELECT * FROM WebSeries";
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cmd.Dispose();
            return ds;
        }

        // Delete Movie
        public bool DeleteMovie(string MovieId)
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();
            cmd.CommandText = "delete from WebSeries where MovieId=@MovieId";
            cmd.Parameters.AddWithValue("@MovieId", MovieId);
            bool ans = cmd.ExecuteNonQuery() > 0;
            cmd.Dispose();
            return ans;
        }


        // Update Movie
        public bool UpdateMovie(string Title, string Year, string Rating, string Genre, string RentCost,string MovieId)
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();
            cmd.CommandText = "update WebSeries set title=@title,year=@year,Rating=@rating,genre=@genre,RentalCost=@rentcost where movieId=@movieId";
            cmd.Parameters.AddWithValue("@movieId", MovieId);
            cmd.Parameters.AddWithValue("@title", Title);
            cmd.Parameters.AddWithValue("@year", Year);
            cmd.Parameters.AddWithValue("@rating", RentCost);
            cmd.Parameters.AddWithValue("@genre", Genre);
            cmd.Parameters.AddWithValue("@rentcost", Rating);
            bool ans = cmd.ExecuteNonQuery() > 0;
            cmd.Dispose();
            return ans;
        }

        // Get Movie Info from selected Movie Id
        public string[] GetMoviesInfo(int MovieId)
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();
            cmd.CommandText = "SELECT title,year,rentalcost,rating,genre FROM WebSeries where MovieId = @MovieId";
            cmd.Parameters.AddWithValue("@MovieId", MovieId);
            SqlDataReader reader = cmd.ExecuteReader();
            string[] data = null;
            
            if (reader.Read())
            {
               
                data = new string[5];
                data[0] = reader[0].ToString();
                data[1] = reader[1].ToString();
                data[2] = reader[2].ToString();
                data[3] = reader[3].ToString();
                data[4] = reader[4].ToString();
            }
            reader.Dispose();
            cmd.Dispose();
            return data;
        }

    }
}
