using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otwrentcarsystem.Order
{
    public partial class FormOrder : Form
    {
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected MySqlDataAdapter adp;
        protected DataTable dt;
        protected string query;
        protected string orderId;
        public FormOrder()
        {
            InitializeComponent();
            // Configure Database Connection
            conn = new Database().Connect();
            // Load Data
            loadFirstTime();
        }

        public void loadFirstTime()
        {
            // Define SQL Query
            query = "SELECT orders.*, customers.name as customer_name, customers.phone as customer_phone, cars.model as car_model, users.name as created_by " +
                "FROM orders " +
                "JOIN customers ON orders.customer_id = customers.id " +
                "JOIN cars ON orders.car_id = cars.id " +
                "JOIN users ON orders.user_id = users.id " +
                "ORDER BY orders.created_at DESC";
            // Fetch Data
            fetchData();
        }

        private void fetchData()
        {
            // Create New Data Table
            dt = new();

            try
            {
                // Open connection
                conn.Open();
                // Define query command
                cmd = new(query, conn);
                adp = new(cmd);
                // Execute Query
                cmd.ExecuteNonQuery();
                // Fill Data Table with result data
                adp.Fill(dt);
                // Set Data source
                DGVOrder.DataSource = dt;
                DGVOrder.Columns["id"].ReadOnly = true;
                DGVOrder.Columns["id"].HeaderText = "ID";
                DGVOrder.Columns["category"].ReadOnly = true;
                DGVOrder.Columns["category"].HeaderText = "Category";
                DGVOrder.Columns["customer_name"].ReadOnly = true;
                DGVOrder.Columns["customer_name"].HeaderText = "Customer Name";
                DGVOrder.Columns["customer_phone"].ReadOnly = true;
                DGVOrder.Columns["customer_phone"].HeaderText = "Customer Phone";
                DGVOrder.Columns["car_model"].ReadOnly = true;
                DGVOrder.Columns["car_model"].HeaderText = "Car";
                DGVOrder.Columns["price"].ReadOnly = true;
                DGVOrder.Columns["price"].HeaderText = "Price";
                DGVOrder.Columns["start_date"].ReadOnly = true;
                DGVOrder.Columns["start_date"].HeaderText = "Start";
                DGVOrder.Columns["end_date"].ReadOnly = true;
                DGVOrder.Columns["end_date"].HeaderText = "End";
                DGVOrder.Columns["number_of_days"].ReadOnly = true;
                DGVOrder.Columns["number_of_days"].HeaderText = "Number of Days";
                DGVOrder.Columns["routes"].ReadOnly = true;
                DGVOrder.Columns["routes"].HeaderText = "Routes";
                DGVOrder.Columns["amount"].ReadOnly = true;
                DGVOrder.Columns["amount"].HeaderText = "Amount";
                DGVOrder.Columns["status"].ReadOnly = true;
                DGVOrder.Columns["created_by"].ReadOnly = true;

                // Add Action Button
                if (!DGVOrder.Columns.Contains("Change Status"))
                {
                    addActionButtons();
                }

                // Modify Column
                List<string> columnsToShow = new List<string> { "id", "customer_name", "customer_phone", "car_model", "category", "start_date", "end_date", "number_of_days", "price", "amount", "status", "created_at", "created_by", "Change Status", "Void"};
                DGVOrder.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.Visible = columnsToShow.Contains(c.Name));

                // Ordering Column
                foreach (string columnName in columnsToShow)
                {
                    DataGridViewColumn column = DGVOrder.Columns[columnName];
                    if (column != null)
                    {
                        column.DisplayIndex = columnsToShow.IndexOf(columnName);
                    }
                }

                // Close Connection
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void addActionButtons()
        {
            // Add Change Status Button
            DataGridViewButtonColumn btnChangeStatus = new();
            btnChangeStatus.Name = "Change Status";
            btnChangeStatus.Text = "Change Status";
            btnChangeStatus.UseColumnTextForButtonValue = true;
            DGVOrder.Columns.Insert(12, btnChangeStatus);
            DGVOrder.Columns["Change Status"].ReadOnly = false;

            // Add Void Button
            DataGridViewButtonColumn btnVoid = new();
            btnVoid.Name = "Void";
            btnVoid.Text = "Void";
            btnVoid.UseColumnTextForButtonValue = true;
            DGVOrder.Columns.Insert(13, btnVoid);
            DGVOrder.Columns["Void"].ReadOnly = false;
        }

        private void DGVCar_CellClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVOrder.Columns["Void"].Index)
            {
                // Get Id from selected Row
                string id = DGVOrder.Rows[e.RowIndex].Cells["id"].Value.ToString();
                // Confirmation Dialog
                DialogResult result = MessageBox.Show("Are you sure want to cancel this order?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Define SQL Query
                        string query = "UPDATE orders SET status='Cancel' WHERE id=@id";
                        // Open Connection
                        conn.Open();
                        // Define SQL Command
                        cmd = new(query, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        // Execute Query
                        cmd.ExecuteNonQuery();
                        // Close Connection
                        conn.Close();
                        // Reload Data
                        loadFirstTime();
                        // Show Dialog
                        MessageBox.Show("Order Canceled Successfully!");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
            }
            else if (e.ColumnIndex == DGVOrder.Columns["Change Status"].Index)
            {
                // Get Id from selected Row
                orderId = DGVOrder.Rows[e.RowIndex].Cells["id"].Value.ToString();
                // Open Chase Status Form
                ChangeStatus change = new(orderId);
                change.Show();
  
            }
        }

        private void DGVOrder_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == DGVOrder.Columns["status"].Index)
            {
                if (e.Value != null)
                {
                    string value = e.Value.ToString();
                    if (value == "Completed")
                    {
                        e.CellStyle.BackColor = Color.Green;
                    }
                    else if (value == "In Progress")
                    {
                        e.CellStyle.BackColor = Color.Yellow;
                    }
                    else if (value == "Open")
                    {
                        e.CellStyle.BackColor = Color.AliceBlue;
                    }
                    else if (value == "Cancel")
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.White;
                    }
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            // Load Data
            loadFirstTime();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            // Define SQL Query
            query = "SELECT orders.*, customers.name as customer_name, customers.phone as customer_phone, cars.model as car_model, users.name as created_by " +
                "FROM orders " +
                "WHERE orders.id like '%"+ search.Text +"%' " +
                "JOIN customers ON orders.customer_id = customers.id " +
                "JOIN cars ON orders.car_id = cars.id " +
                "JOIN users ON orders.user_id = users.id " +
                "ORDER BY orders.created_at DESC";
            // Fetch Data
            fetchData();
        }

        private void status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status.Text != "All")
            {
                // Define SQL Query
                query = "SELECT orders.*, customers.name as customer_name, customers.phone as customer_phone, cars.model as car_model, users.name as created_by " +
                    "FROM orders " +
                    "JOIN customers ON orders.customer_id = customers.id " +
                    "JOIN cars ON orders.car_id = cars.id " +
                    "JOIN users ON orders.user_id = users.id " +
                    "WHERE orders.status='" + status.Text + "' " +
                    "ORDER BY orders.created_at DESC";
                // Fetch Data
                fetchData();
            }
            else
            {
                loadFirstTime();
            }
        }
    }
}
