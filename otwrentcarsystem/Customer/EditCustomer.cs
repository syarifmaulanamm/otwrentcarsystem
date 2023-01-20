using Microsoft.VisualBasic.ApplicationServices;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otwrentcarsystem.Customer
{
    public partial class EditCustomer : Form
    {
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected MySqlDataReader result;
        protected string query;
        protected string id;
        public EditCustomer(string customerId)
        {
            InitializeComponent();
            // Configure Database Connection
            conn = new Database().Connect();
            id = customerId;
            // Fetch Customer Data
            FetchData();
        }

        private void FetchData()
        {
            try
            {
                // Open Connection
                conn.Open();
                // Define SQL Query
                query = "SELECT * FROM customers where id=@id";
                // Define Mysql Command
                cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                // Get Result
                result = cmd.ExecuteReader();

                if(result.Read())
                {
                    name.Text = result["name"].ToString();
                    phone.Text = result["phone"].ToString();
                    email.Text = result["email"].ToString();
                    address.Text = result["address"].ToString();
                }

                // Close Connection
                conn.Close();
            } catch(Exception err)
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
                // Define Query for find username
                query = "UPDATE customers SET name=@name, phone=@phone, email=@email, address=@address WHERE id=@id";
                // Execute Sql Query
                cmd = new(query, conn);
                // Change variable
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@phone", phone.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@address", address.Text);
                cmd.ExecuteNonQuery();
                // Close Connection
                conn.Close();
                // Action After Submitted
                this.Close();
                MessageBox.Show("Customer Updated Successfully!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
