using MySqlConnector;

namespace otwrentcarsystem
{
    public partial class FormLogin : Form
    {
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected MySqlDataReader result;
        protected string query;
        protected string userId;
        protected string hashFromDB;

        public FormLogin()
        {
            InitializeComponent();
            // Configure Database Connection
            conn = new Database().Connect();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Set Progress Bar to 10%
            progressBar1.Value = 10;

            try
            {
                // Open Connection
                conn.Open();
                // Define Query for find username
                query = "SELECT * FROM users where username=@username";
                // Execute Sql Query
                cmd = new(query, conn);
                // Change variable with Text Field username value
                cmd.Parameters.AddWithValue("@username", username.Text);
                // Get result 
                result = cmd.ExecuteReader();
                // Set Progress Bar to 30%
                progressBar1.Value = 30;

                if (result.Read())
                {
                    // Set Progress Bar to 50%
                    progressBar1.Value = 50;

                    // Get password hash from database
                    hashFromDB = result["password"].ToString();

                    // Verify password
                    if (BCrypt.Net.BCrypt.Verify(password.Text, hashFromDB))
                    {
                        // Set Progress Bar to 100%
                        progressBar1.Value = 100;

                        // Save user Id & Name
                        userId = result["id"].ToString();

                        // Open Dashboard and close Login Window
                        Dashboard dashboard = new(userId);
                        this.Hide();
                        dashboard.Show();
                    }
                    else
                    {
                        // Show error dialog
                        MessageBox.Show("Username or Password Invalid!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Set Progress Bar to 100%
                    progressBar1.Value = 100;
                    // Show error dialog
                    MessageBox.Show("User Not Found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Close connection
                conn.Close();
            } catch(Exception err)
            {
                // Set Progress Bar to 100%
                progressBar1.Value = 100;
                // Show error dialog
                MessageBox.Show(err.Message);
            }

        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}