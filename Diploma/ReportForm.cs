using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;

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
                            cmb_report.Items.Add(rdr.GetValue(0).ToString());
                        }
                    }
                }
            }

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Номер заявки";
            column1.Width = 70;
            column1.ReadOnly = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Профиль";
            column2.Width = 100;
            column2.ReadOnly = true;
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Количество";
            column3.Width = 100;
            column3.ReadOnly = true;
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Нарезано";
            column4.ReadOnly = true;
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Рабочий";
            column5.Width = 80;
            column5.ReadOnly = true;
            column5.CellTemplate = new DataGridViewTextBoxCell();

            var column6 = new DataGridViewColumn();
            column6.HeaderText = "Упаковано";
            column6.ReadOnly = true;
            column6.CellTemplate = new DataGridViewTextBoxCell();

            var column7 = new DataGridViewColumn();
            column7.HeaderText = "Рабочий";
            column7.Width = 80;
            column7.ReadOnly = true;
            column7.CellTemplate = new DataGridViewTextBoxCell();

            dgw_report.Columns.Add(column1);
            dgw_report.Columns.Add(column2);
            dgw_report.Columns.Add(column3);
            dgw_report.Columns.Add(column4);
            dgw_report.Columns.Add(column5);
            dgw_report.Columns.Add(column6);
            dgw_report.Columns.Add(column7);

            dgw_report.AllowUserToAddRows = false;
        }

        private void btn_reportShow_Click(object sender, EventArgs e)
        {
            int numberTask = Convert.ToInt32(cmb_report.SelectedItem);
            dgw_report.Rows.Clear();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string commandFirst = $@"Select Profiles.Article, SUM(Process_worker.Quantity), Users.Name
                                        From Process Join Profiles
                                        On Process.Profile_id = Profiles.Profile_id
                                        Join Process_worker
                                        On Process.Process_id=Process_worker.Process_id
                                        Join Users
                                        On Process_worker.User_id = Users.User_id
                                        Join Tasks
                                        On Tasks.Task_id = Process.Task_id
                                        Where Users.Role_id = 2 AND Tasks.Task_id = {numberTask}
                                        Group by Users.Name, Profiles.Article";

                SqlDataAdapter adapterFirst = new SqlDataAdapter(commandFirst, connection);
                DataSet firstWorkers = new DataSet();
                adapterFirst.Fill(firstWorkers);

                string commandSecond = $@"Select Profiles.Article, SUM(Process_worker.Quantity), Users.Name
                                        From Process Join Profiles
                                        On Process.Profile_id = Profiles.Profile_id
                                        Join Process_worker
                                        On Process.Process_id=Process_worker.Process_id
                                        Join Users
                                        On Process_worker.User_id = Users.User_id
                                        Join Tasks
                                        On Tasks.Task_id = Process.Task_id
                                        Where Users.Role_id = 3 AND Tasks.Task_id = {numberTask}
                                        Group by Users.Name, Profiles.Article";

                SqlDataAdapter adapterSecond = new SqlDataAdapter(commandSecond, connection);
                DataSet secondWorkers = new DataSet();
                adapterSecond.Fill(secondWorkers);

                string commandTasks = $@"Select Profiles.Article, Process.Quantity
                                        From Process JOIn Profiles
                                        ON Process.Profile_id = Profiles.Profile_id
                                        Join Tasks
                                        ON Process.Task_id = {numberTask}
                                        Group by Profiles.Article, Process.Quantity
                                        ";

                SqlDataAdapter adapterTasks = new SqlDataAdapter(commandTasks, connection);
                DataSet tasks = new DataSet();
                adapterTasks.Fill(tasks);


                foreach (DataTable tasksTable in tasks.Tables)
                {
                    foreach (DataRow tasksRow in tasksTable.Rows)
                    {
                        dgw_report.Rows.Add(numberTask, tasksRow[0], tasksRow[1]);
                    }
                }

                for (int i = 0; i < dgw_report.Rows.Count; i++)
                {
                    foreach (DataTable firstWorkerTable in firstWorkers.Tables)
                    {
                        foreach (DataRow firstWorkerRow in firstWorkerTable.Rows)
                        {
                            if (firstWorkerRow[0].ToString() == dgw_report.Rows[i].Cells[1].Value.ToString())
                            {
                                dgw_report.Rows[i].Cells[3].Value = firstWorkerRow[1];
                                dgw_report.Rows[i].Cells[4].Value = firstWorkerRow[2];
                            }
                        }
                    }

                    foreach (DataTable secondWorkersTable in secondWorkers.Tables)
                    {
                        foreach (DataRow secondWorkersRow in secondWorkersTable.Rows)
                        {
                            if (secondWorkersRow[0].ToString() == dgw_report.Rows[i].Cells[1].Value.ToString())
                            {
                                dgw_report.Rows[i].Cells[5].Value = secondWorkersRow[1];
                                dgw_report.Rows[i].Cells[6].Value = secondWorkersRow[2];
                            }
                        }
                    }
                }
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Excel.Application excelapp = new Excel.Application();
            Excel.Workbook workbook = excelapp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            for (int i = 1; i < dgw_report.RowCount + 1; i++)
            {
                for (int j = 1; j < dgw_report.ColumnCount + 1; j++)
                {
                    worksheet.Rows[1].Columns[j] = dgw_report.Columns[j - 1].HeaderText;

                    worksheet.Rows[i + 1].Columns[j] = dgw_report.Rows[i - 1].Cells[j - 1].Value;
                }
            }

            excelapp.AlertBeforeOverwriting = false;
            string date = DateTime.Now.ToShortDateString();
            workbook.SaveAs($"C:\\Users\\Anna\\Desktop\\Report_{date}_{Convert.ToInt32(cmb_report.SelectedItem)}.xlsx");
            excelapp.Quit();

            MessageBox.Show("Отчёт сохранён.", "Успех");
        }
    }
}
