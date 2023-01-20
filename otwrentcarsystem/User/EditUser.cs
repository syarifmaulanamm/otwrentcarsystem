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
    public partial class EditUser : Form
    {
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected MySqlDataReader result;
        protected string query;
        protected string id;

        public EditUser(string userId)
        {
            InitializeComponent();
            // Configure Database Connection
            conn = new Database().Connect();
            // Set Id
            id = userId;
            // Fetch Data
            FetchData();
        }

        private void FetchData()
        {
            try
            {
                // Open Connection
                conn.Open();
                // Define SQL Query
                query = "SELECT * FROM users where id=@id";
                // Define Mysql Command
                cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                // Get Result
                result = cmd.ExecuteReader();

                if (result.Read())
                {
                    name.Text = result["name"].ToString();
                    username.Text = result["username"].ToString();
                }

                // Close Connection
                conn.Close();
            }
            catch (Exception err)
            {
                // Show Error Dialog
                MessageBox.Show(err.Message);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                // Open Connection
                conn.Open();
                // Define Query 
                query = "UPDATE users SET name=@name, username=@username, password=@password WHERE id=@id";
                // Execute Sql Query
                cmd = new(query, conn);
                // Change variable
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.HashPassword(password.Text,12).ToString());
                cmd.ExecuteNonQuery();
                // Close Connection
                conn.Close();
                // Action After Submitted
                this.Close();
                MessageBox.Show("User Updated Successfully!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
