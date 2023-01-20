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

namespace otwrentcarsystem.Car
{
    public partial class SelectCar : Form
    {
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected MySqlDataAdapter adp;
        protected DataTable dt;
        protected string query;
        protected string id;
        protected string model;
        protected string price;
        protected FormReservation reservation;
        public SelectCar(FormReservation reservation)
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
            AddCar add = new();
            add.Show();
        }
        public void loadFirstTime()
        {
            // Define SQL Query
            query = "SELECT * FROM cars";
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
                DGVCar.DataSource = dt;
                DGVCar.Columns["id"].ReadOnly = true;
                DGVCar.Columns["model"].ReadOnly = true;
                DGVCar.Columns["category"].ReadOnly = true;
                DGVCar.Columns["year"].ReadOnly = true;
                DGVCar.Columns["price"].ReadOnly = true;
                // Add Edit and Delete Button
                if (!DGVCar.Columns.Contains("Edit"))
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
            DGVCar.Columns.Add(btn);
            DGVCar.Columns["Select"].ReadOnly = false;
        }

        private void DGVCar_CellClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVCar.Columns["Select"].Index)
            {
                // Get Id & Model from selected Row
                id = DGVCar.Rows[e.RowIndex].Cells["id"].Value.ToString();
                model = DGVCar.Rows[e.RowIndex].Cells["model"].Value.ToString();
                price = DGVCar.Rows[e.RowIndex].Cells["price"].Value.ToString();

                reservation.SetCar(id, model, price);
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
            query = "SELECT * FROM cars WHERE model LIKE '%" + search.Text + "%' OR phone LIKE '%" + search.Text + "%'";
            // Fetch Data
            fetchData();
        }
    }
}
