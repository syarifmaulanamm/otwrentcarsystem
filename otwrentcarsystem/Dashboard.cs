using otwrentcarsystem.Car;
using otwrentcarsystem.Customer;
using otwrentcarsystem.Order;
using otwrentcarsystem.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace otwrentcarsystem
{
    public partial class Dashboard : Form
    {
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected MySqlDataReader result;
        protected string query;
        protected string userId;
        public Dashboard(string userId)
        {
            InitializeComponent();
            // Configure Database Connection
            conn = new Database().Connect();
            this.userId = userId;
            // Greeting
            Greeting();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            FormReservation reservation = new(userId);
            reservation.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            FormOrder order = new();
            order.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FormCustomer customer = new();
            customer.Show();
        }

        private void btnCar_Click(object sender, EventArgs e)
        {
            FormCar car = new();
            car.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            FormUser user = new();
            user.Show();
        }

        private void Greeting()
        {
            try
            {
                // Open Connection
                conn.Open();
                // Define Query for find username
                query = "SELECT * FROM users where id=@userid";
                // Execute Sql Query
                cmd = new(query, conn);
                // Change variable with Text Field username value
                cmd.Parameters.AddWithValue("@userid", userId);
                // Get result 
                result = cmd.ExecuteReader();

                if (result.Read())
                {
                    greeting.Text = "Hello, " + result["name"].ToString() + "!";
                }
                // Close Connection
                conn.Close();
                } catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormLogin login = new();
            login.Show();
            this.Hide();
        }
    }
}
