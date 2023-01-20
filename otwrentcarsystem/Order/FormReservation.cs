using MySqlConnector;
using otwrentcarsystem.Car;
using otwrentcarsystem.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otwrentcarsystem.Order
{
    public partial class FormReservation : Form
    {
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected string query;
        protected string userId;
        protected string customerId;
        protected string carId;
        public FormReservation(string userId)
        {
            InitializeComponent();
            this.userId = userId;
            // Configure Database Connection
            conn = new Database().Connect();
        }

        public void SetCustomer(string id, string name)
        {
            customerId = id;
            customerName.Text = name;
        }

        public void SetCar(string id, string model, string price)
        {
            carId = id;
            carModel.Text = model;
            this.price.Text = price;
            GetAmount();
        }

        private void GetAmount()
        {
            int nod = (endDate.Value - startDate.Value).Days + 1;

            if (int.Parse(price.Text) > 0)
            {
                int total = int.Parse(price.Text) * nod;
                numberOfDays.Text = nod.ToString();
                amount.Text = total.ToString();
            }
        }

        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            SelectCustomer select = new(this);
            select.Show();
        }

        private void btnSelectCar_Click(object sender, EventArgs e)
        {
            SelectCar select = new(this);
            select.Show();
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            GetAmount();
        }

        private void endDate_ValueChanged(object sender, EventArgs e)
        {
            GetAmount();
        }

        private void price_TextChanged(object sender, EventArgs e)
        {
            GetAmount();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Open Connection
                conn.Open();
                // Define SQL Query
                query = "INSERT INTO orders (user_id, customer_id, car_id, category, start_date, end_date, number_of_days, routes, price, amount, status) " +
                    "VALUES(@user_id, @customer_id, @car_id, @category, @start_date, @end_date, @number_of_days, @routes, @price, @amount, @status)";
                // Mysql Command
                cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@customer_id", customerId);
                cmd.Parameters.AddWithValue("@car_id", carId);
                cmd.Parameters.AddWithValue("@category", category.Text);
                cmd.Parameters.AddWithValue("@start_date", startDate.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@end_date", endDate.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@number_of_days", numberOfDays.Text);
                cmd.Parameters.AddWithValue("@routes", routes.Text);
                cmd.Parameters.AddWithValue("@price", price.Text);
                cmd.Parameters.AddWithValue("@amount", amount.Text);
                cmd.Parameters.AddWithValue("@status", "Open");
                cmd.ExecuteNonQuery();
                // Show Dialog
                MessageBox.Show("Reservation Added Successfully!");
                // Reset Form
                customerId = "";
                carId = "";
                customerName.Text = "";
                carModel.Text = "";
                routes.Text = "";
                price.Text = "0";
                amount.Text = "0";
            } catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            // Close Connection
            conn.Close();
        }
    }
}
