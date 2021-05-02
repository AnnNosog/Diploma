using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }        

        private void ReportForm_Load(object sender, EventArgs e)
        {
            int[,] array = new int[,] { { 1, 2, 3, 8, 6, 8, 7, 8, 7, 0, 8 }, { 1, 2, 3, 8, 6, 8, 7, 8, 7, 0, 8 }, { 1, 2, 3, 8, 6, 8, 7, 8, 7, 0, 8 } };

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Task_id From Tasks", connection);                                         

                using (SqlDataReader rdr = command.ExecuteReader())
                {

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            cmb_report.Items.Add(rdr.ToString());
                        }
                    }
                }
            }

            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.DataSource = GetDataTable(array);            
        }                

        private DataTable GetDataTable(int[,] array)
        {
            DataTable table = new DataTable();
            for (int i = 0; i < array.GetLength(1); i++)
            {
                table.Columns.Add();
                table.Columns[i].ColumnName = $"dsgs{i}";

                //(dt.TableName); // название таблицы
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                table.Rows.Add(table.NewRow());
                for (int j = 0; j < array.GetLength(1); j++)
                    table.Rows[i][j] = array[i, j];
            }

            return table;
        }

    }
}
