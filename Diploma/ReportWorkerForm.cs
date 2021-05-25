using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Diploma
{
    public partial class ReportWorkerForm : Form
    {
        public ReportWorkerForm()
        {
            InitializeComponent();
        }

        private void ReportWorkerForm_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(@"SELECT Users.Name
                                                        From Users
                                                        Join Roles
                                                        ON Users.Role_id = Roles.Role_id
                                                        Where Roles.Name <> 'Chief'", connection);

                using (SqlDataReader rdr = command.ExecuteReader())
                {
                    cmb_report.Items.Add("");

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            cmb_report.Items.Add(rdr.GetValue(0).ToString());
                        }
                    }
                }

                SqlCommand commandDate = new SqlCommand("SELECT Date From Process_worker Group by Date", connection);

                using (SqlDataReader rdr = commandDate.ExecuteReader())
                {
                    cmb_date.Items.Add("");

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            cmb_date.Items.Add(Convert.ToDateTime(rdr.GetValue(0)).ToShortDateString());
                        }
                    }
                }

                crt_reportWorker.AlignDataPointsByAxisLabel();
            }

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Номер заявки";
            column1.Width = 70;
            column1.ReadOnly = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var columnDate = new DataGridViewColumn();
            columnDate.HeaderText = "Дата";
            columnDate.Width = 80;
            columnDate.ReadOnly = true;
            columnDate.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Профиль";
            column2.Width = 100;
            column2.ReadOnly = true;
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Общее количество";
            column3.Width = 70;
            column3.ReadOnly = true;
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Рабочий";
            column4.Width = 120;
            column4.ReadOnly = true;
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Сделано";
            column5.Width = 70;
            column5.ReadOnly = true;
            column5.CellTemplate = new DataGridViewTextBoxCell();

            dgw_report.Columns.Add(column1);
            dgw_report.Columns.Add(columnDate);
            dgw_report.Columns.Add(column2);
            dgw_report.Columns.Add(column3);
            dgw_report.Columns.Add(column4);
            dgw_report.Columns.Add(column5);

            dgw_report.AllowUserToAddRows = false;
        }

        private void btn_reportShow_Click(object sender, EventArgs e)
        {
            string nameWorker = "";
            dgw_report.Rows.Clear();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string commandFirst = "\0";

                int maxY = 0;

                if (cmb_report.SelectedItem == null && cmb_date.SelectedItem == null || cmb_report.SelectedItem.ToString() == "" && cmb_date.SelectedItem.ToString() == "")
                {
                    commandFirst = $@"Select Tasks.Task_id, Profiles.Article, SUM(Process_worker.Quantity), Users.Name, Process_worker.Date, Process.Quantity
                                        From Process Join Profiles
                                        On Process.Profile_id = Profiles.Profile_id
                                        Join Process_worker
                                        On Process.Process_id=Process_worker.Process_id
                                        Join Users
                                        On Process_worker.User_id = Users.User_id
										Join Roles
										ON Users.Role_id = Roles.Role_id
                                        Join Tasks
                                        On Tasks.Task_id = Process.Task_id
										Where Roles.Name <> 'Chief'
                                        Group by Users.Name, Profiles.Article, Tasks.Task_id, Process_worker.Date, Process.Quantity
										Order by Process_worker.Date";

                    SqlDataAdapter adapter2 = new SqlDataAdapter(commandFirst, connection);
                    DataSet worker2 = new DataSet();
                    adapter2.Fill(worker2);

                    crt_reportWorker.Series.Clear();

                    foreach (DataTable table in worker2.Tables)
                    {
                        foreach (DataRow column in table.Rows)
                        {
                            if (Convert.ToInt32(column[5]) > maxY)
                            {
                                maxY = Convert.ToInt32(column[5]);
                            }

                            dgw_report.Rows.Add(column[0], Convert.ToDateTime(column[4]).ToShortDateString(), column[1], column[5], column[3], column[2]);

                            if (crt_reportWorker.Series.IsUniqueName(column[3].ToString()))
                            {
                                crt_reportWorker.Series.Add(column[3].ToString());
                            }

                            crt_reportWorker.Series[column[3].ToString()].Points.AddXY(column[4], column[2]);
                        }
                    }

                    crt_reportWorker.ChartAreas[0].AxisY.Maximum = maxY;

                    return;
                }
                else if (cmb_date.SelectedItem == null || cmb_date.SelectedItem.ToString() == "")
                {
                    nameWorker = cmb_report.SelectedItem.ToString();
                    commandFirst = $@"Select Tasks.Task_id, Profiles.Article, SUM(Process_worker.Quantity), Process_worker.Date, Process.Quantity
                                        From Process Join Profiles
                                        On Process.Profile_id = Profiles.Profile_id
                                        Join Process_worker
                                        On Process.Process_id=Process_worker.Process_id
                                        Join Users
                                        On Process_worker.User_id = Users.User_id
                                        Join Tasks
                                        On Tasks.Task_id = Process.Task_id
                                        Where Users.Name = '{nameWorker}'
                                        Group by Profiles.Article, Tasks.Task_id, Process_worker.Date, Process.Quantity
										Order by Process_worker.Date";
                }
                else if (cmb_report.SelectedItem == null || cmb_report.SelectedItem.ToString() == "")
                {
                    commandFirst = $@"Select Tasks.Task_id, Profiles.Article, SUM(Process_worker.Quantity), Users.Name, Process_worker.Date, Process.Quantity
                                        From Process Join Profiles
                                        On Process.Profile_id = Profiles.Profile_id
                                        Join Process_worker
                                        On Process.Process_id=Process_worker.Process_id
                                        Join Users
                                        On Process_worker.User_id = Users.User_id
                                        Join Tasks
                                        On Tasks.Task_id = Process.Task_id
                                        Where Process_worker.Date = '{Convert.ToDateTime(cmb_date.SelectedItem).ToShortDateString()}'
                                        Group by Users.Name, Profiles.Article, Tasks.Task_id, Process_worker.Date, Process.Quantity
										Order by Process_worker.Date";


                    SqlDataAdapter adapter1 = new SqlDataAdapter(commandFirst, connection);
                    DataSet worker1 = new DataSet();
                    adapter1.Fill(worker1);

                    crt_reportWorker.Series.Clear();

                    foreach (DataTable table in worker1.Tables)
                    {
                        foreach (DataRow column in table.Rows)
                        {
                            dgw_report.Rows.Add(column[0], Convert.ToDateTime(column[4]).ToShortDateString(), column[1], column[5], column[3], column[2]);

                            if (Convert.ToInt32(column[5]) > maxY)
                            {
                                maxY = Convert.ToInt32(column[5]);
                            }

                            if (crt_reportWorker.Series.IsUniqueName(column[3].ToString()))
                            {
                                crt_reportWorker.Series.Add(column[3].ToString());
                            }

                            crt_reportWorker.Series[column[3].ToString()].Points.AddXY(column[1] + $" ({Convert.ToDateTime(column[4]).ToShortDateString()})", column[2]);
                        }
                    }

                    crt_reportWorker.ChartAreas[0].AxisY.Maximum = maxY;

                    return;
                }
                else
                {
                    nameWorker = cmb_report.SelectedItem.ToString();

                    commandFirst = $@"Select Tasks.Task_id, Profiles.Article, SUM(Process_worker.Quantity), Process_worker.Date, Process.Quantity
                                        From Process Join Profiles
                                        On Process.Profile_id = Profiles.Profile_id
                                        Join Process_worker
                                        On Process.Process_id=Process_worker.Process_id
                                        Join Users
                                        On Process_worker.User_id = Users.User_id
                                        Join Tasks
                                        On Tasks.Task_id = Process.Task_id
                                        Where Users.Name = '{nameWorker}' AND Process_worker.Date = '{Convert.ToDateTime(cmb_date.SelectedItem).ToShortDateString()}'
                                        Group by Profiles.Article, Tasks.Task_id, Process_worker.Date,                          Process.Quantity
										Order by Process_worker.Date";
                }

                SqlDataAdapter adapter = new SqlDataAdapter(commandFirst, connection);
                DataSet worker = new DataSet();
                adapter.Fill(worker);

                crt_reportWorker.Series.Clear();
                crt_reportWorker.Series.Add(nameWorker);

                foreach (DataTable table in worker.Tables)
                {
                    foreach (DataRow column in table.Rows)
                    {
                        if (Convert.ToInt32(column[4]) > maxY)
                        {
                            maxY = Convert.ToInt32(column[4]);
                        }

                        dgw_report.Rows.Add(column[0], Convert.ToDateTime(column[3]).ToShortDateString(), column[1], column[4], nameWorker, column[2]);

                        crt_reportWorker.Series[nameWorker].Points.AddXY(column[1] + $" ({Convert.ToDateTime(column[3]).ToShortDateString()})", column[2]);
                    }
                }

                crt_reportWorker.ChartAreas[0].AxisY.Maximum = maxY;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "(*.xlsx)|*.xlsx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            Excel.Application excelapp = new Excel.Application();
            Excel.Workbook workbook = excelapp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    for (int i = 1; i < dgw_report.RowCount + 1; i++)
                    {
                        for (int j = 1; j < dgw_report.ColumnCount + 1; j++)
                        {
                            worksheet.Rows[1].Columns[j] = dgw_report.Columns[j - 1].HeaderText;

                            worksheet.Rows[i + 1].Columns[j] = dgw_report.Rows[i - 1].Cells[j - 1].Value;
                        }
                    }
                }

                workbook.SaveAs(saveFileDialog1.FileName, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                excelapp.Quit();

                MessageBox.Show("Отчёт сохранён.", "Успех");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
