using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Diploma
{
    sealed class Authentications
    {
        public static bool AuthCheckUser(string login)
        {
            bool log_user = false;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string command = $"Select User_id from Users Where Login = '{login}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand comLog = new SqlCommand(command, connection);
                    connection.Open();

                    using (SqlDataReader reader = comLog.ExecuteReader())
                    {
                        log_user = reader.Read();
                    }
                }
                catch (SqlException)
                {
                    log_user = false;
                }
            }
            return log_user;
        }

        public static bool AuthCheckLogIn(string login, string password)
        {
            bool log_user = false;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string command = $"Select User_id from Users Where Login = '{login}' And Password = '{password}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand comLog = new SqlCommand(command, connection);
                    connection.Open();

                    using (SqlDataReader reader = comLog.ExecuteReader())
                    {
                        log_user = reader.Read();
                    }
                }
                catch (SqlException)
                {
                    log_user = false;
                }
            }
            return log_user;
        }

        public static bool CheckUserRegex(string user)
        {
            string patternUser = @"[a-z A-Z]\d*$";

            if (Regex.IsMatch(user, patternUser))
            {
                return true;
            }
            
            return false;
        }

        public static bool CheckPasswordRegex(string pass)
        {
            string patternPass = @"(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*]{6,}";

            if (Regex.IsMatch(pass, patternPass))
            {
                return true;
            }

            return false;
        }
    }
}
