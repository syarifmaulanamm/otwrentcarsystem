using BCrypt.Net;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace otwrentcarsystem.User
{
    public partial class AddUser : Form
    {
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected string query;

        public AddUser()
        {
            InitializeComponent();
            // Configure Database Connection
            conn = new Database().Connect();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                // Open Connection
                conn.Open();
                // Define Query 
                query = "INSERT INTO users (name,username, password) VALUES (@name,@username, @password)";
                // Execute Sql Query
                cmd = new(query, conn);
                // Change variable
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.HashPassword(password.Text,12).ToString());
                cmd.ExecuteNonQuery();
                // Close Connection
                conn.Close();
                // Action After Submitted
                this.Close();
                MessageBox.Show("User Added Successfully!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
