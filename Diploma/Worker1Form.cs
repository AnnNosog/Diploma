using Diploma.Strategy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Diploma
{
    public partial class Worker1Form : Form
    {
        Dictionary<int, int> _addTask;
        int _userID;
        int _userRole;
        bool status;
        IWorkerQuery _workerQuery;

        public Worker1Form(int userID, int userRole, IWorkerQuery workerQuery)
        {
            InitializeComponent();
            _addTask = new Dictionary<int, int>();
            _userID = userID;
            _userRole = userRole;
            _workerQuery = workerQuery;
            var a = _workerQuery.LoadQuery;
        }

        private void Worker1Form_Load(object sender, EventArgs e)
        {

            status = true;
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Номер заявки";
            column1.Width = 70;
            column1.ReadOnly = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Номер позиции";
            column2.Width = 70;
            column2.ReadOnly = true;
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Профиль";
            column3.ReadOnly = true;
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Количество";
            column4.Width = 80;
            column4.ReadOnly = true;
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Сделано";
            column5.Width = 55;
            column5.CellTemplate = new DataGridViewTextBoxCell();

            dgv_worker1.Columns.Add(column1);
            dgv_worker1.Columns.Add(column2);
            dgv_worker1.Columns.Add(column3);
            dgv_worker1.Columns.Add(column4);
            dgv_worker1.Columns.Add(column5);

            dgv_worker1.AllowUserToAddRows = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = _workerQuery.LoadQuery;

                SqlDataAdapter adapter = new SqlDataAdapter(command, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int quantity = 0;

                        if (_userRole == 2)
                        {
                            _addTask[Convert.ToInt32(row[3].ToString())] = 0;

                            SqlCommand commandQuantity = new SqlCommand($@"Select Process_worker.Quantity
                                                From Process_worker Join Process
                                                ON Process_worker.Process_id = Process.Process_id
                                                Where Process_worker.Process_id = '{row[2]}'", connection);

                            using (SqlDataReader rdrQuantity = commandQuantity.ExecuteReader())
                            {
                                while (rdrQuantity.Read())
                                {
                                    quantity += Convert.ToInt32(rdrQuantity.GetValue(0).ToString());
                                }
                            }

                            if (Convert.ToInt32(row[3]) - quantity <= 0)
                            {
                                continue;
                            }
                        }                     

                        dgv_worker1.Rows.Add(row[0], row[2], row[1], Convert.ToInt32(row[3]) - quantity, 0);
                    }
                }
            }
        }

        private void btn_done_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_worker1.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgv_worker1[4, i].Value) == 0)
                {
                    continue;
                }


                if (Convert.ToInt32(dgv_worker1[4, i].Value) > Convert.ToInt32(dgv_worker1[3, i].Value))
                {
                    dgv_worker1.Rows[i].ErrorText = "Количество не может быть больше основного количества.";
                    return;
                }

                _addTask[Convert.ToInt32(dgv_worker1[1, i].Value)] = Convert.ToInt32(dgv_worker1[4, i].Value);
            }

            CreateApplication(_addTask);
            MessageBox.Show("Данные обновлены!", "Обновление данных");
            _addTask.Clear();

            Worker1Form worker1Form = new Worker1Form(_userID, _userRole, _workerQuery);
            worker1Form.Show();
            status = false;
            this.Close();
        }

        private void CreateApplication(Dictionary<int, int> create)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand commandProc = new SqlCommand("INSERT INTO Process_worker (Process_id, User_id, Quantity) VALUES (@proc_id, @user_id, @quantity)", connection);

                commandProc.Parameters.Add(new SqlParameter("@user_id", _userID));
                SqlParameter procIDParam = new SqlParameter("@proc_id", SqlDbType.Int);
                SqlParameter quantityeParam = new SqlParameter("@quantity", SqlDbType.Int);
                commandProc.Parameters.Add(procIDParam);
                commandProc.Parameters.Add(quantityeParam);

                

                foreach (var item in create)
                {
                    if (item.Value == 0)
                    {
                        continue;
                    }
                    procIDParam.Value = item.Key;
                    quantityeParam.Value = item.Value;

                    commandProc.ExecuteNonQuery();
                }
            }
        }

        private void Worker1Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (status)
            {
                Application.Exit();
            }
        }

        private void dgv_worker1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgv_worker1.CurrentCell.ColumnIndex == 4)
            {
                const string disallowed = @"^[0-9]\d*$";
                var newText = Regex.Replace(e.FormattedValue.ToString(), disallowed, string.Empty);
                dgv_worker1.Rows[e.RowIndex].ErrorText = "";

                if (dgv_worker1.Rows[e.RowIndex].IsNewRow)
                {
                    return;
                }

                if (string.CompareOrdinal(e.FormattedValue.ToString(), newText) != 0)
                {
                    return;
                }

                e.Cancel = true;
                dgv_worker1.Rows[e.RowIndex].ErrorText = "Введите положительное число!";
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
