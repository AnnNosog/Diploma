
namespace Diploma
{
    partial class LogInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_userLogin = new System.Windows.Forms.TextBox();
            this.lb_login = new System.Windows.Forms.Label();
            this.lb_password = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.btn_logIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_userLogin
            // 
            this.tb_userLogin.Location = new System.Drawing.Point(55, 38);
            this.tb_userLogin.Name = "tb_userLogin";
            this.tb_userLogin.Size = new System.Drawing.Size(159, 20);
            this.tb_userLogin.TabIndex = 0;
            this.tb_userLogin.UseWaitCursor = true;
            // 
            // lb_login
            // 
            this.lb_login.AutoSize = true;
            this.lb_login.Location = new System.Drawing.Point(59, 20);
            this.lb_login.Name = "lb_login";
            this.lb_login.Size = new System.Drawing.Size(103, 13);
            this.lb_login.TabIndex = 1;
            this.lb_login.Text = "Имя пользователя";
            this.lb_login.UseWaitCursor = true;
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Location = new System.Drawing.Point(59, 73);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(45, 13);
            this.lb_password.TabIndex = 3;
            this.lb_password.Text = "Пароль";
            this.lb_password.UseWaitCursor = true;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(55, 91);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(159, 20);
            this.tb_password.TabIndex = 2;
            this.tb_password.UseWaitCursor = true;
            // 
            // btn_logIn
            // 
            this.btn_logIn.Location = new System.Drawing.Point(105, 136);
            this.btn_logIn.Name = "btn_logIn";
            this.btn_logIn.Size = new System.Drawing.Size(109, 27);
            this.btn_logIn.TabIndex = 4;
            this.btn_logIn.Text = "Вход";
            this.btn_logIn.UseVisualStyleBackColor = true;
            this.btn_logIn.UseWaitCursor = true;
            this.btn_logIn.Click += new System.EventHandler(this.btn_logIn_Click);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 193);
            this.Controls.Add(this.btn_logIn);
            this.Controls.Add(this.lb_password);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.lb_login);
            this.Controls.Add(this.tb_userLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LogInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход";
            this.UseWaitCursor = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogInForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_userLogin;
        private System.Windows.Forms.Label lb_login;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Button btn_logIn;
    }
}