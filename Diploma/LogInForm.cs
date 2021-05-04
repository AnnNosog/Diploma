using Diploma.Strategy;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Diploma
{
    public partial class LogInForm : Form
    {
        bool btn17 = false;
        public LogInForm()
        {
            InitializeComponent();
        }

        private void btn_logIn_Click(object sender, EventArgs e)
        {
           
            if (Authentications.AuthCheckLogIn(tb_userLogin.Text, tb_password.Text))
            {
                int userRoleId;
                int userID;
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"Select Role_id From Users Where Login = '{tb_userLogin.Text}'", connection);
                    userRoleId = Convert.ToInt32(command.ExecuteScalar());

                    command = new SqlCommand($"Select User_id From Users Where Login = '{tb_userLogin.Text}'", connection);
                    userID = Convert.ToInt32(command.ExecuteScalar());
                }

                if (userRoleId == 1)
                {
                    btn17 = true;
                    ChiefWorm chiefWorm = new ChiefWorm(userID);
                    chiefWorm.Show();                    
                    Close();
                }

                if (userRoleId == 2)
                {
                    btn17 = true;
                    WorkersForm worker1Form = new WorkersForm(userID, new FirstWorkerQuery());
                    worker1Form.Show();
                    Close();

                }
                if (userRoleId == 3)
                {
                    btn17 = true;
                    WorkersForm worker1Form = new WorkersForm(userID, new SecondWorkerQuery());
                    worker1Form.Show();
                    Close();
                }

            }
            else
            {
                MessageBox.Show("Неверное имя или пароль.", "Ошибка входа");
            }
        }

        private void LogInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btn17)
            {
                return;
            }
            Application.Exit();
        }
    }
}
