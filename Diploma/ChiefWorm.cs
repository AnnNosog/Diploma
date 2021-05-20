using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Diploma
{
    public partial class ChiefWorm : Form
    {
        string _connectionString;
        List<string> _profilesString;
        Dictionary<string, int> _addTask;
        int _userID;
        bool status;

        public ChiefWorm(int userID)
        {
            InitializeComponent();
            _profilesString = new List<string>();
            _addTask = new Dictionary<string, int>();
            _userID = userID;
            status = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            lb_date_time.Text = DateTime.Now.ToShortDateString();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Select Count(Task_id) From Tasks", connection);
                int count = Convert.ToInt32(command.ExecuteScalar());

                lb_task.Text = $"Заявка №{count + 1}";

                command = new SqlCommand("Select Article From Profiles Order by Article", connection);

                using (SqlDataReader rdr = command.ExecuteReader())
                {

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            _profilesString.Add((rdr.GetValue(0).ToString()));
                        }
                    }
                }
            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_prifiles.Rows.Count; i++)
            {
                if (dgv_prifiles[0, i].Value == null)
                {
                    CreateApplication(_addTask);
                    _addTask.Clear();
                    MessageBox.Show("Заявка создана!", "Зявка создана");
                    ChiefWorm chiefworm = new ChiefWorm(_userID);
                    chiefworm.Show();
                    status = false;
                    this.Close();
                    return;
                }

                if (_addTask.ContainsKey(dgv_prifiles[0, i].Value.ToString()))
                {
                    var exists = Convert.ToInt32(_addTask[dgv_prifiles[0, i].Value.ToString()]);
                    _addTask[dgv_prifiles[0, i].Value.ToString()] = Convert.ToInt32(dgv_prifiles[1, i].Value) + exists;
                    continue;
                }

                _addTask.Add(dgv_prifiles[0, i].Value.ToString(), Convert.ToInt32(dgv_prifiles[1, i].Value));
            }
        }

        private void dgv_prifiles_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgv_prifiles.CurrentCell.ColumnIndex == 0)
            {
                return;
            }

            const string disallowed = @"^[1-9]\d*$";
            var newText = Regex.Replace(e.FormattedValue.ToString(), disallowed, string.Empty);
            dgv_prifiles.Rows[e.RowIndex].ErrorText = "";

            if (dgv_prifiles.Rows[e.RowIndex].IsNewRow)
            {
                return;
            }

            if (string.CompareOrdinal(e.FormattedValue.ToString(), newText) != 0)
            {
                return;
            }

            e.Cancel = true;
            dgv_prifiles.Rows[e.RowIndex].ErrorText = "Введите положительное число!";
        }

        private void CreateApplication(Dictionary<string, int> create)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand commandTasks = new SqlCommand("INSERT INTO Tasks (Date, User_id) VALUES (@date, @user_id)", connection);

                SqlCommand commandProcess = new SqlCommand("INSERT INTO Process (Task_id, Profile_id, Quantity) VALUES (@task_id, @profile_id, @quantity)", connection);

                commandTasks.Parameters.Add(new SqlParameter("@date", SqlDbType.Date)).Value = DateTime.Now.ToShortDateString();
                commandTasks.Parameters.Add(new SqlParameter("@user_id", _userID));

                commandTasks.ExecuteNonQuery();

                commandTasks = new SqlCommand("Select MAX(Task_id) from Tasks", connection);
                int numberTask = Convert.ToInt32(commandTasks.ExecuteScalar());
                commandProcess.Parameters.Add(new SqlParameter("@task_id", numberTask));

                SqlParameter profileParam = new SqlParameter("@profile_id", SqlDbType.Int);
                SqlParameter quantityeParam = new SqlParameter("@quantity", SqlDbType.Int);
                commandProcess.Parameters.Add(profileParam);
                commandProcess.Parameters.Add(quantityeParam);

                foreach (var item in create)
                {
                    SqlCommand commandProfile = new SqlCommand($"Select Profile_id From Profiles Where Article = '{item.Key}'", connection);
                    int numberProfile = Convert.ToInt32(commandProfile.ExecuteScalar());

                    profileParam.Value = numberProfile;
                    quantityeParam.Value = item.Value;

                    commandProcess.ExecuteNonQuery();
                }
            }
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void показатьЗаявкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
        }

        private void ChiefWorm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (status)
            {
                Application.Exit();
            }
        }

        private void dgv_prifiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_prifiles.CurrentCell.ColumnIndex == 1)
                {
                    return;
                }

                DataGridViewComboBoxCell dcombo = new DataGridViewComboBoxCell();
                DataGridTextBox tbx = new DataGridTextBox();

                for (int i = 0; i < _profilesString.Count; i++)
                {
                    dcombo.Items.Add(_profilesString[i]);
                }

                
                dgv_prifiles.Rows[dgv_prifiles.CurrentRow.Index].Cells[0] = dcombo;

                dcombo.ReadOnly = false;
                dgv_prifiles.Rows[dgv_prifiles.CurrentRow.Index].Cells[1].Value = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        private void просмотретьОтчётПоРабочемуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportWorkerForm reportWorkerForm = new ReportWorkerForm();
            reportWorkerForm.Show();
        }
    }
}
