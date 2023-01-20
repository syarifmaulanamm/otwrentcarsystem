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

namespace otwrentcarsystem.User
{
    public partial class FormUser : Form
    {
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected MySqlDataAdapter adp;
        protected DataTable dt;
        protected string query;
        protected string userId;
        public FormUser()
        {
            InitializeComponent();
            // Configure Database Connection
            conn = new Database().Connect();
            // Load Data
            loadFirstTime();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUser add = new();
            add.Show();
        }
        public void loadFirstTime()
        {
            // Define SQL Query
            query = "SELECT id, name, username FROM users";
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
                DGVUser.DataSource = dt;
                DGVUser.Columns["id"].ReadOnly = true;
                DGVUser.Columns["name"].ReadOnly = true;
                DGVUser.Columns["username"].ReadOnly = true;
                // Add Edit and Delete Button
                if (!DGVUser.Columns.Contains("Edit"))
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
            DataGridViewButtonColumn btnEdit = new();
            btnEdit.Name = "Edit";
            btnEdit.Text = "Edit";
            btnEdit.UseColumnTextForButtonValue = true;
            DGVUser.Columns.Add(btnEdit);
            DGVUser.Columns["Edit"].ReadOnly = false;

            // Add Delete Button
            DataGridViewButtonColumn btnDelete = new();
            btnDelete.Name = "Delete";
            btnDelete.Text = "Delete";
            btnDelete.UseColumnTextForButtonValue = true;
            DGVUser.Columns.Add(btnDelete);
            DGVUser.Columns["Delete"].ReadOnly = false;
        }

        private void DGVCustomer_CellClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVUser.Columns["Delete"].Index)
            {
                // Get Id from selected Row
                string id = DGVUser.Rows[e.RowIndex].Cells["id"].Value.ToString();
                // Confirmation Dialog
                DialogResult result = MessageBox.Show("Are you sure want to delete this customer?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Define SQL Query
                        string query = "DELETE FROM users WHERE id=@id";
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
                        MessageBox.Show("Data deleted successfully!");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
            }
            else if (e.ColumnIndex == DGVUser.Columns["Edit"].Index)
            {
                // Get Id from selected Row
                userId = DGVUser.Rows[e.RowIndex].Cells["id"].Value.ToString();

                EditUser edit = new(userId);
                edit.Show();
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
            query = "SELECT id, name, username FROM users WHERE name LIKE '%" + search.Text + "%'";
            // Fetch Data
            fetchData();
        }
    }
}
