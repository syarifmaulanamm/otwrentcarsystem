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

namespace otwrentcarsystem.Order
{
    public partial class ChangeStatus : Form
    {
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected MySqlDataReader result;
        protected string query;
        protected string id;

        public ChangeStatus(string orderId)
        {
            InitializeComponent();
            // Configure Database Connection
            conn = new Database().Connect();
            // Set Order Id
            id = orderId;
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
                query = "SELECT status FROM orders WHERE id=" + id;
                // Define Mysql Command
                cmd = new(query, conn);
                // Get Result
                result = cmd.ExecuteReader();
                if (result.Read())
                {
                    // Passing value
                    status.Text = result["status"].ToString();
                }
                // Close Connection
                conn.Close();
            }catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void ChangeStatus_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Open Connection
                conn.Open();
                // Define SQL Query
                query = "UPDATE orders SET status=@status WHERE id=" + id;
                // Define Mysql Command
                cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@status", status.Text);
                // Execute Query
                cmd.ExecuteNonQuery();
                // Show Dialog
                MessageBox.Show("Order Status Updated Successfully");
                // Close Window
                this.Close();
                // Close Connection
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
