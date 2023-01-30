using MySqlConnector;
using NPOI.HSSF.UserModel;
using System.Data;

namespace otwrentcarsystem
{
    internal class ExportToExcel
    {
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected MySqlDataAdapter adp;
        protected DataTable dt;
        protected FileStream file;
        protected HSSFWorkbook workbook;
        protected string query;

        public ExportToExcel()
        {
            // Configure Database Connection
            conn = new Database().Connect();
        }
        public void ExportDataOrder()
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xls)|*.xls",
                DefaultExt = "xls",
                AddExtension = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            };

            dialog.ShowDialog();


            file = new FileStream(dialog.FileName, FileMode.Create);
            workbook = new();
            var sheet = workbook.CreateSheet("Sheet 1");

            // Open Connection
            conn.Open();

            // Define SQL Query
            query = "SELECT orders.*, customers.name as customer_name, customers.phone as customer_phone, cars.model as car_model, users.name as created_by " +
                "FROM orders " +
                "JOIN customers ON orders.customer_id = customers.id " +
                "JOIN cars ON orders.car_id = cars.id " +
                "JOIN users ON orders.user_id = users.id " +
                "ORDER BY orders.created_at DESC";
            cmd = new(query, conn);
            adp = new(cmd);
            dt = new DataTable();
            adp.Fill(dt);

            var headerRow = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                headerRow.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var dataRow = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dataRow.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            workbook.Write(file);

            // Close Connection
            conn.Close();
        }
    }
}
