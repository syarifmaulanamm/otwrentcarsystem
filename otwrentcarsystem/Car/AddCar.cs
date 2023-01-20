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

namespace otwrentcarsystem.Car
{
    public partial class AddCar : Form
    {
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected string query;
        public AddCar()
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
                // Define Query for find username
                query = "INSERT INTO cars (model, category, year, price) VALUES (@model, @category, @year, @price)";
                // Execute Sql Query
                cmd = new(query, conn);
                // Change variable
                cmd.Parameters.AddWithValue("@model", model.Text);
                cmd.Parameters.AddWithValue("@category", category.Text);
                cmd.Parameters.AddWithValue("@year", year.Text);
                cmd.Parameters.AddWithValue("@price", price.Text);
                cmd.ExecuteNonQuery();
                // Close Connection
                conn.Close();
                // Action After Submitted
                this.Close();
                MessageBox.Show("Car Added Successfully!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
