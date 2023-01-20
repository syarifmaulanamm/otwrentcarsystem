using MySqlConnector;
using otwrentcarsystem.Order;
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

namespace otwrentcarsystem.Customer
{
    public partial class SelectCustomer : Form
    {
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected MySqlDataAdapter adp;
        protected DataTable dt;
        protected string query;
        protected string id;
        protected string name;
        protected FormReservation reservation;
        public SelectCustomer(FormReservation reservation)
        {
            InitializeComponent();
            this.reservation = reservation;
            // Configure Database Connection
            conn = new Database().Connect();
            // Load Data
            loadFirstTime();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCustomer add = new();
            add.Show();
        }
        public void loadFirstTime()
        {
            // Define SQL Query
            query = "SELECT * FROM customers";
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
                DGVCustomer.DataSource = dt;
                DGVCustomer.Columns["id"].ReadOnly = true;
                DGVCustomer.Columns["name"].ReadOnly = true;
                DGVCustomer.Columns["phone"].ReadOnly = true;
                DGVCustomer.Columns["address"].ReadOnly = true;
                // Add Edit and Delete Button
                if (!DGVCustomer.Columns.Contains("Edit"))
                {
                    addActionButtons();
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
            // Add Edit Button
            DataGridViewButtonColumn btn = new();
            btn.Name = "Select";
            btn.Text = "Select";
            btn.UseColumnTextForButtonValue = true;
            DGVCustomer.Columns.Add(btn);
            DGVCustomer.Columns["Select"].ReadOnly = false;
        }

        private void DGVCustomer_CellClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVCustomer.Columns["Select"].Index)
            {
                // Get Id & Name from selected Row
                id = DGVCustomer.Rows[e.RowIndex].Cells["id"].Value.ToString();
                name = DGVCustomer.Rows[e.RowIndex].Cells["name"].Value.ToString();

                reservation.SetCustomer(id, name);
                this.Close();
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
            query = "SELECT * FROM customers WHERE name LIKE '%" + search.Text + "%' OR phone LIKE '%" + search.Text + "%'";
            // Fetch Data
            fetchData();
        }
    }
}
