using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace otwrentcarsystem
{
    internal class Database
    {
        protected MySqlConnection conn;
        protected string server;
        protected string port;
        protected string database;
        protected string uid;
        protected string password;
        public Database()
        { 
            // Define Database Server Configuration
            server = "localhost";
            port = "3306";
            database = "otwrcs";
            uid = "root";
            password = "";
            // Create New Database Connection
            conn = new("server=" + server + ";port=" + port + ";database=" + database + ";uid=" + uid + ";password=" + password);
        }

        public MySqlConnection Connect()
        {
            return conn;
        }
    }
}
