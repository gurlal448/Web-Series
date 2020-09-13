
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Webseries;

namespace MyMovieStore
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1stop_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1start_Click(object sender, EventArgs e)
        {
            this.Hide();
            ApplicationForm ap = new ApplicationForm();
            ap.Show();
            
        }
    }
}
