using System;
using System.Windows.Forms;

namespace Diploma
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            LogInForm logInForm = new LogInForm();
            logInForm.Owner = this;
            logInForm.ShowDialog();
            this.Hide();
        }

        private void btn_regUser_Click(object sender, EventArgs e)
        {
            RegUserWorm regUserWorm = new RegUserWorm();
            regUserWorm.Owner = this;
            regUserWorm.ShowDialog();
        }
    }
}
