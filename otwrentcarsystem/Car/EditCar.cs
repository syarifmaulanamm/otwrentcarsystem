using Microsoft.VisualBasic.ApplicationServices;
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
using System.Xml.Linq;

namespace otwrentcarsystem.Car
{
    public partial class EditCar : Form
    {

        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected MySqlDataReader result;
        protected string query;
        protected string id;
        public EditCar(string carId)
        {
            InitializeComponent();
            // Configure Database Connection
            conn = new Database().Connect();
            id = carId;
            // Fetch Data from Database
            FetchData();
        }

        private void FetchData()
        {
            try
            {
                // Open Connection
                conn.Open();
                // Define SQL Query
                query = "SELECT * FROM cars where id=@id";
                // Define Mysql Command
                cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                // Get Result
                result = cmd.ExecuteReader();

                if (result.Read())
                {
                    model.Text = result["model"].ToString();
                    category.Text = result["category"].ToString();
                    year.Text = result["year"].ToString();
                    price.Text = result["price"].ToString();
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
                // Define Query for find username
                query = "UPDATE cars SET model=@model, category=@category, year=@year, price=@price WHERE id=@id";
                // Execute Sql Query
                cmd = new(query, conn);
                // Change variable
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@model", model.Text);
                cmd.Parameters.AddWithValue("@category", category.Text);
                cmd.Parameters.AddWithValue("@year", year.Text);
                cmd.Parameters.AddWithValue("@price", price.Text);
                cmd.ExecuteNonQuery();
                // Close Connection
                conn.Close();
                // Action After Submitted
                this.Close();
                MessageBox.Show("Car Updated Successfully!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
