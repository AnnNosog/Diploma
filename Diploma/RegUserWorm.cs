using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Diploma
{
    public partial class RegUserWorm : Form
    {
        public RegUserWorm()
        {
            InitializeComponent();
        }

        private void RegUserWorm_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Select Name From Roles", connection);

                using (SqlDataReader rdr = command.ExecuteReader())
                {

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            cmb_role.Items.Add(rdr.GetValue(0).ToString());
                        }
                    }
                }
            }
        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            if (Authentications.CheckPasswordRegex(tb_passwordReg.Text) == false)
            {
                MessageBox.Show("Пароль должен состоять от 6 символов с использованием цифр, спец. символов (!@#$%^&*), латиницы, наличием строчных и прописных символов.", "Ошибка");
            }
            else if (Authentications.CheckUserRegex(tb_userNameReg.Text) == false || Authentications.CheckUserRegex(tb_loginReg.Text) == false)
            {
                MessageBox.Show("Имя должно быть на латинице.", "Ошибка");
            }
            else if (Authentications.CheckPasswordRegex(tb_passwordReg.Text) && Authentications.CheckUserRegex(tb_userNameReg.Text))
            {
                if (!Authentications.AuthCheckUser(tb_userNameReg.Text))
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        SqlCommand commandRole = new SqlCommand($"Select Role_id From Roles Where Roles.Name = '{cmb_role.SelectedItem}'", connection);
                        int role = Convert.ToInt32(commandRole.ExecuteScalar());

                        SqlCommand commandTasks = new SqlCommand("INSERT INTO Users (Name, Login, Password, Role_id) VALUES (@name, @login, @pass, @role_id)", connection);

                        commandTasks.Parameters.Add(new SqlParameter("@name", tb_userNameReg.Text));
                        commandTasks.Parameters.Add(new SqlParameter("@login", tb_loginReg.Text));
                        commandTasks.Parameters.Add(new SqlParameter("@pass", tb_passwordReg.Text));
                        commandTasks.Parameters.Add(new SqlParameter("@role_id", role));

                        commandTasks.ExecuteNonQuery();
                    }

                    MessageBox.Show("Регистарция завершена!\nМожете заходить под своей учётной записью.", "Успех");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Такой пользователь уже есть.");
                }
            }
        }
    }
}
