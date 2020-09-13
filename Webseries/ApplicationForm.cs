
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Webseries.DataBaseOperations;
namespace Webseries
{
    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
        {
            InitializeComponent();
            listBox1RentedMOvies.Enabled = false;
        }

        // add new customer implementation
        private void AddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                  // set selected tab = customer
                   TabControl.SelectedTab = TabControl.TabPages["Customers"];
                
                    string name, address, phone;
                    name = txtName.Text.Trim();
                    address = txtAddress.Text.Trim();
                    phone = txtPhone.Text.Trim();

                    if (name=="")
                    {
                        MessageBox.Show("Please enter Customer name !");
                        txtName.Focus();
                    }
                    else if (address=="")
                    {
                        MessageBox.Show(" Please enter Customer address!");
                        txtAddress.Focus();
                    }
                    else if (phone=="")
                    {
                        MessageBox.Show("Please enter phone number!");
                        txtPhone.Focus();
                    }
                   
                    else
                    {
                        
                        if (new Customer().AddCustomer(name, address, phone))
                        {

                            BindDdlCustomer(); // method calling to Bind comboBox Customer
                            BindGridCustomer(); // method calling to Bind GridView Customer
                            MessageBox.Show("New customer added!");

                            txtAddress.Clear();
                            txtName.Clear();
                            txtPhone.Clear();

                        }
                        else
                        {
                            MessageBox.Show("Unable to add this customer!");
                        }
                    }
                
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindDdlCustomer(); // method calling

            BindGridCustomer(); // method calling to bind customer grid
            BindDdlMovie(); // method calling to Bind comboBox movie

            //BindDDLRentedMovies(); // method calling to Bind comboBox Rented movie
        }


        //// Bind comboBox Rented movie
        //private void BindDDLRentedMovies()
        //{
        //     DataTable dTable = new RentalMovie().GetRentedMoviesDDL();

        //    DataRow row = dTable.NewRow();
        //    row[0] = 0;
        //    row[1] = "--------";
        //    dTable.Rows.InsertAt(row, 0); // add item at INDEX = 0;

        //    ddlRentedMovies.DisplayMember = "Title";
        //    ddlRentedMovies.ValueMember = "MovieID";
        //    ddlRentedMovies.DataSource = dTable;
        //}

        //bind movies grid
        private void BindGridMovies()
        {
            DataTable dsTable = new Movie().GetAllMovies();
            gvMovies.DataSource = dsTable;
            gvMovies.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        //Bind Customer Grid to show data
        private void BindGridCustomer()
        {
            DataTable ds = new Customer().GetAllCustomers();
            CustomersDataGridView.DataSource = ds;
            CustomersDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        // Bind rented movies grid
        private void BindGridRentedMovies()
        {
            DataTable ds = new RentalMovie().GetAllRentedData();
            gvRental.DataSource = ds;
            gvRental.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        //Bind ComboBox Customer to show data 
        private void BindDdlCustomer()
        {
            DataTable ds = new Customer().GetAllCustomers();

            DataRow row = ds.NewRow();
            row[0] = 0;
            row[1] = "-----------";
            ds.Rows.InsertAt(row, 0); // add item at INDEX = 0;

            ddlCustomer.DisplayMember = "Name";
            ddlCustomer.ValueMember = "CustId";
            ddlCustomer.DataSource = ds; // Bind customer in Customer section
          
            
            // Bind customer in Movie Return section
            ddlAllCust.DisplayMember = "Name";
            ddlAllCust.ValueMember = "CustId";
            ddlAllCust.DataSource = ds;
        }

        // Bind ddl movies Available for rent
        private void BindDdlMovie()
        {
            DataTable dsMovie = new Movie().GetMoviesForDDL();

            DataRow row = dsMovie.NewRow();
            row[0] = 0;
            row[1] = "-----------";
            dsMovie.Rows.InsertAt(row, 0);

            ddlMovie.DisplayMember = "Title";
            ddlMovie.ValueMember = "MovieID";
            ddlMovie.DataSource = dsMovie;

        }

        // to delete a customer
        private void DeleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                // set selected tab = customer
                TabControl.SelectedTab = TabControl.TabPages["Customers"];
                string custId = ddlCustomer.SelectedValue.ToString();
                
                    DialogResult result = MessageBox.Show("Are you sure to delete this customer?", "Alert", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (new Customer().DeleteCustomer(custId))
                        {
                            BindDdlCustomer(); // method calling to Bind comboBox Customer
                            BindGridCustomer(); // method calling to Bind GridView Customer
                        txtName.Clear();
                        txtAddress.Clear();
                        txtPhone.Clear();
                        ddlCustomer.SelectedIndex = 0;
                            MessageBox.Show("Customer Deleted!");
                        }
                        else
                        {
                            MessageBox.Show("Unable to delete this customer");
                        }
                    }
                    

            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("REFERENCE"))
                {
                    MessageBox.Show("Can not delete this customer as this customer rented a movie!");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Update customer info
        private void UpdateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                // set selected tab = customer
                TabControl.SelectedTab = TabControl.TabPages["Customers"];

                string custId = ddlCustomer.SelectedValue.ToString();
                string name, address, phone;
                name = txtName.Text.Trim();
                address = txtAddress.Text.Trim();
                phone = txtPhone.Text.Trim();

                if (name == "")
                {
                    MessageBox.Show("Please Enter Customer Name");
                    txtName.Focus();
                }
                else if (address == "")
                {
                    MessageBox.Show("Please Enter Customer Address");
                    txtAddress.Focus();
                }
                else if (phone == "")
                {
                    MessageBox.Show("Please Enter Customer Phone number!");
                    txtPhone.Focus();
                }
               
                else
                {
                    
                    if (new Customer().UpdateCustomer(name, address, phone, custId))
                    {
                        
                        BindDdlCustomer(); // method calling to Bind comboBox Customer
                        BindGridCustomer(); // method calling to Bind GridView Customer
                        MessageBox.Show("Customer updated!");
                        txtName.Clear();
                        txtAddress.Clear();
                        txtPhone.Clear();
                        ddlCustomer.SelectedIndex = 0;

                    }
                    else
                    {
                        MessageBox.Show("Unable to update this customer!");
                    }
                }

            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message);
            }
        }

        // Add New Web Series 
        private void btnAddMOvie_Click(object sender, EventArgs e)
        {
            try
            {       //Set Active tab = WebSeries
                    TabControl.SelectedTab = TabControl.TabPages["WebSeries"];
                
                    string Title, RentCost, Year, Rating, Genre;
                    Title = txtTitle.Text.Trim();
                    RentCost = txtRentedCost.Text.Trim();
                    Rating = txtRating.Text.Trim();
                    Year = txtYear.Text.Trim();
                    Genre = txtGenre.Text.Trim();

                    if (Title=="")
                    {
                        MessageBox.Show("Web Series title is required!");
                    }
                    else if (Year=="")
                    {
                        MessageBox.Show("Released year is required!");
                    }
                   
                    else if (Genre=="")
                    {
                        MessageBox.Show("Genre is required!");
                    }
                    
                    else if (Rating=="")
                    {
                        MessageBox.Show("Rating is required!");
                    }
                    
                    else
                    {
                        
                        if (new Movie().AddMovie(Title,Year,Rating,Genre,RentCost))
                        {

                            BindGridMovies(); // method calling to Bind Grid Movies
                            BindDdlMovie(); // method calling to Bind ComboBox Movies
                            MessageBox.Show("Web Series Inseted!");

                            txtTitle.Clear();
                            txtYear.Clear();
                            txtRating.Clear();
                            txtGenre.Clear();
                            txtRentedCost.Clear();
                        }
                    }
                
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message);
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //your specific tabname
            if (TabControl.SelectedTab == TabControl.TabPages["WebSeries"])
            {
                BindGridMovies(); // method calling to Bind Grid Movies
                BindDdlMovie(); // method calling to Bind ComboBox Movies

            }
            else if (TabControl.SelectedTab == TabControl.TabPages["Customers"])
            {
                BindDdlCustomer(); // method calling to Bind comboBox Customer

                BindGridCustomer(); // method calling to Bind Grid Customer
            }
            else if (TabControl.SelectedTab == TabControl.TabPages["RentedWebSeries"])
            {
                BindGridRentedMovies(); //method calling to Bind Grid for all rental movies
                //BindDDLRentedMovies(); //method calling to Bind comboBox for rental movies only
            }
        }

        // To delete any movie 
        private void btnDelMOvie_Click(object sender, EventArgs e)
        {
            try
            {
                TabControl.SelectedTab = TabControl.TabPages["WebSeries"];
                string SeriesID = ddlMovie.SelectedValue.ToString();

                DialogResult result = MessageBox.Show("Are you sure to delete this Web Series?", "Alert", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (new Movie().DeleteMovie(SeriesID))
                    {
                        BindDdlMovie(); // method calling to Bind comboBox movie
                        BindGridMovies(); // method calling to Bind GridView movie
                        MessageBox.Show("Web Series Deleted!");

                        txtTitle.Clear();
                        txtYear.Clear();
                        txtRating.Clear();
                        txtGenre.Clear();
                        txtRentedCost.Clear();

                        ddlMovie.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Unable to delete this movie");
                    }
                }
                else
                {
                    // Not deleted
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("REFERENCE"))
                {
                    MessageBox.Show("Can not delete this movie as it is rented by a customer!");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Update Movie Data
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                TabControl.SelectedTab = TabControl.TabPages["WebSeries"]; 

                string MovieId = ddlMovie.SelectedValue.ToString();

                string Title, RentCost, Year, Rating, Genre;
                Title = txtTitle.Text.Trim();
                RentCost = txtRentedCost.Text.Trim();
                Rating = txtRating.Text.Trim();
                Year = txtYear.Text.Trim();
                Genre = txtGenre.Text.Trim();

                if (Title=="")
                {
                    MessageBox.Show("Series title is required!");
                }
                else if (Year=="")
                {
                    MessageBox.Show("Released year is required!");
                }
               
                else if (Genre=="")
                {
                    MessageBox.Show("Genre is required!");
                }
                
               
                else if (Rating=="")
                {
                    MessageBox.Show("Rating is required!");
                }
                
                else
                {
                   
                    if (new Movie().UpdateMovie(Title,Year,Rating,Genre,RentCost, MovieId))
                    {

                        BindGridMovies(); // method calling to Bind Grid Movies
                        BindDdlMovie(); // method calling to Bind ComboBox Movies
                        MessageBox.Show("Web Series Info Updated!");

                        txtTitle.Clear();
                        txtYear.Clear();
                        txtRating.Clear();
                        txtGenre.Clear();
                        txtRentedCost.Clear();
                        ddlMovie.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Unable to update this Web series!");

                    }
                }
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message);
            }
        }

        // Get Movie Cost 
        public int GetMovieCost( int MovieID)
        {
            SqlCommand cmd = Connection.StartConnection().CreateCommand();
            cmd.CommandText = " select RentalCost from WebSeries where MovieID=@MovieID"; // stored procedure
            
            cmd.Parameters.AddWithValue("@MovieID", MovieID);
            int RentalCost = 0;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                RentalCost = int.Parse(reader["RentalCost"].ToString());
            }
            reader.Close();
            cmd.Dispose();
            return RentalCost;
        }

        
        //Form closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    DialogResult result = MessageBox.Show("Do you really want to exit?", "Alert", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        // Connection to Database closed on form closing
                        Connection.CloseConnection();
                        Application.Exit();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Bind Customer details on selection changed
            try
            {
                int CustId = int.Parse(ddlCustomer.SelectedValue.ToString());
                if (CustId > 0)
                {
                    string[] data = new Customer().GetCustomersInfo(CustId);

                    if (data != null)
                    {
                        txtName.Text = data[0];
                        txtAddress.Text = data[1];
                        txtPhone.Text = data[2];
                    }

                }
                else
                {
                    txtAddress.Clear();
                    txtName.Clear();
                    txtPhone.Clear();
                    listBox1RentedMOvies.Enabled = false;
                    
                }
               
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message);
            }
        }

        //Bind movie details on selection changed
        private void ddlMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // get "movie id" here
                int MovieId = int.Parse(ddlMovie.SelectedValue.ToString());
                if (MovieId > 0)
                {

                    string[] data = new Movie().GetMoviesInfo(MovieId);
                    if (data != null)
                    {
                       
                        txtTitle.Text = data[0];
                        txtYear.Text = data[1];
                        txtRentedCost.Text = data[2];
                        txtRating.Text = data[3];
                        txtGenre.Text = data[4];
                        
                    }

                }
                else
                {
                    txtTitle.Clear();
                    txtYear.Clear();
                    txtRentedCost.Clear();
                    txtRating.Clear();
                    txtGenre.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Special Info
        private void button1ShowData_Click(object sender, EventArgs e)
        {
            try
            {
                //Customer Who Borrows Most Movies
                if (radioButton1.Checked)
                {
                    TabControl.SelectedTab = TabControl.TabPages["RentedWebSeries"];

                    DataTable dt = new RentalMovie().CustomersWhoBorrowMostMovies();
                    gvRental.DataSource = dt;
                    gvRental.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                else if (radioButton2.Checked) //Most Popular Movies
                {
                    TabControl.SelectedTab = TabControl.TabPages["RentedWebSeries"];
                    DataTable dt = new RentalMovie().MostPopularMovies();
                    gvRental.DataSource = dt;
                    gvRental.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                
                }
                else if (radioButton3.Checked) //Show All Rented Movies
                {
                    TabControl.SelectedTab = TabControl.TabPages["RentedWebSeries"];
                    BindGridRentedMovies();
                }
            }
            catch (Exception ex)
             {
                MessageBox.Show(ex.Message);
            }
        }

        private void ddlAllCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int CustID = int.Parse(ddlAllCust.SelectedValue.ToString());
                if (CustID > 0)
                {
                    listBox1RentedMOvies.Enabled = true;

                    SqlCommand cmd = Connection.StartConnection().CreateCommand();
                    string query = "select rm.MovieID, Title from RentedMovies rm join WebSeries mv on rm.movieid= mv.movieid where rentedDate is not null and custid=@custID group by Title, rm.MovieID";
                    cmd.CommandText = query;

                    cmd.Parameters.Add(new SqlParameter("@custID", CustID));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        listBox1RentedMOvies.DisplayMember = "Title";
                        listBox1RentedMOvies.ValueMember = "MovieID";
                        listBox1RentedMOvies.DataSource = dt;
                        da.Dispose();
                        cmd.Dispose();

                    }
                    else
                    {
                        listBox1RentedMOvies.DisplayMember = "Title";
                        listBox1RentedMOvies.ValueMember = "MovieID";
                        listBox1RentedMOvies.DataSource = dt;
                        da.Dispose();
                        cmd.Dispose();
                        listBox1RentedMOvies.Enabled = false;
                        // disbale combox list of rented movies 
                    }
                }
                else
                {
                    txtAddress.Clear();
                    txtName.Clear();
                    txtPhone.Clear();
                    listBox1RentedMOvies.Enabled = false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Compute the Rent Amount
        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string SeriesReleaseYear = txtYear.Text.Trim();
                string PresentYear = DateTime.Now.Year.ToString();
                if (SeriesReleaseYear=="")
                {
                    txtRentedCost.Text = "";
                }

                else
                {
                    int age = int.Parse(PresentYear) - int.Parse(SeriesReleaseYear);
                    //if videos are older than 5 years (Release Date) then they cost $2 otherwise it cost $5
                    if (age > 5)
                    {
                        txtRentedCost.Text = "2";
                    }
                    else
                    {
                        txtRentedCost.Text = "5";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Issue Web Series to Customer
        private void btnIssueMovie_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Set Active tab = Rented Web Series
               
                string CustId, MovieId, IssueDate, ReturnDate;
                int totalDays=0;
                CustId = ddlCustomer.SelectedValue.ToString();
                MovieId = ddlMovie.SelectedValue.ToString();
                IssueDate = dtIsuue.Value.ToShortDateString();
                ReturnDate = dtReturn.Value.ToShortDateString();
                if (CustId=="0")
                {
                    MessageBox.Show("Please select a Customer from customer arena");
                }
                else if (MovieId=="0")
                {
                    MessageBox.Show("Please select a Web series from Web Series arena");
                }

                else if (IssueDate == ReturnDate)
                {
                    totalDays = 1;
                    int RentalCost = GetMovieCost(int.Parse(MovieId)); // Getting rental cost for that movie

                    int TotalRent = totalDays * RentalCost; // Calculated the TotalRent

                    if (DateTime.Parse(IssueDate) > DateTime.Parse(ReturnDate))
                    {
                        MessageBox.Show("Issue date can not b greater than retun date");
                    }
                    else
                    {

                        if (new RentalMovie().RentMovie(CustId, MovieId, IssueDate, ReturnDate, TotalRent))
                        {

                            BindGridRentedMovies(); //method calling to Bind Grid for all rental movies
                                                    //BindDDLRentedMovies(); // method calling to Bind comboBox Rented movie
                            MessageBox.Show("Web Series rented successfully!");

                        }
                        else
                        {
                            MessageBox.Show("Failed to rent this Web Series");
                        }
                    }
                }
                else
                {
                    totalDays = Convert.ToInt32((DateTime.Parse(ReturnDate) - DateTime.Parse(IssueDate)).TotalDays);
                    int RentalCost = GetMovieCost(int.Parse(MovieId)); // Getting rental cost for that movie

                    int TotalRent = totalDays * RentalCost; // Calculated the TotalRent

                    if (DateTime.Parse(IssueDate) > DateTime.Parse(ReturnDate))
                    {
                        MessageBox.Show("Issue date can not b greater than retun date");
                    }
                    else
                    {

                        if (new RentalMovie().RentMovie(CustId, MovieId, IssueDate, ReturnDate, TotalRent))
                        {

                            BindGridRentedMovies(); //method calling to Bind Grid for all rental movies
                                                    //BindDDLRentedMovies(); // method calling to Bind comboBox Rented movie
                            MessageBox.Show("Web Series rented successfully!");

                        }
                        else
                        {
                            MessageBox.Show("Failed to rent this Web Series");
                        }
                    }

                }
                // set active tab = Rented Web Series
                TabControl.SelectedTab = TabControl.TabPages["RentedWebSeries"];
                ddlAllCust.SelectedIndex = 0;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Return Web Series - Implementation
        private void btnReturnMovie_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                listBox1RentedMOvies.SelectionMode = SelectionMode.One;
                if (listBox1RentedMOvies.Items.Count > 0)
                {
                    int MoviId = int.Parse((listBox1RentedMOvies.SelectedItem as DataRowView)["MovieId"].ToString());
                    int CustId = int.Parse(ddlCustomer.SelectedValue.ToString());
                    if (CustId == 0)
                    {
                    }
                    if (new RentalMovie().ReturnMovie(MoviId, CustId))
                    {
                        // BindDdlMovie(); // method calling to Bind comboBox movie
                        //BindDDLRentedMovies(); // method calling to Bind comboBox Rented movie
                        // BindGridMovies(); // method calling to Bind Grid movie
                        BindGridRentedMovies(); //method calling to Bind Grid for all rental movies

                        MessageBox.Show("Web Series Returned Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Unable to return this Web Series!");
                    }
                    //Set Active tab = Rented Web Series
                    TabControl.SelectedTab = TabControl.TabPages["RentedWebSeries"];
                }
                else
                {
                    MessageBox.Show("No Web series available to return");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //private void btnExit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Closes the connection with database and Exit the App.
        //        DialogResult result = MessageBox.Show("Do you really want to exit?", "Alert", MessageBoxButtons.YesNo);
        //        if (result == DialogResult.Yes)
        //        {
        //            // Connection to Database closed on form closing
        //            DataConnection.CloseConnection();
        //            Application.ExitThread();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
