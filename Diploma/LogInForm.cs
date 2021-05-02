using Diploma.Strategy;
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
    public partial class LogInForm : Form
    {
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
                    ChiefWorm chiefWorm = new ChiefWorm(userID);
                    chiefWorm.Show();
                    Close();
                }

                if (userRoleId == 2 )
                {
                    Worker1Form worker1Form = new Worker1Form(userID, userRoleId, new FirstWorkerQuery());
                    worker1Form.Show();
                    Close();
                }
                if (userRoleId == 3)
                {
                    Worker1Form worker1Form = new Worker1Form(userID, userRoleId, new SecondWorkerQuery());
                    worker1Form.Show();
                    Close();
                }

            }
            else
            {
                MessageBox.Show("Неверное имя или пароль.", "Ошибка входа");
            }
        }
    }
}
