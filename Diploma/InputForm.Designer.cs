
namespace Diploma
{
    partial class InputForm
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
            this.btn_LogIn = new System.Windows.Forms.Button();
            this.btn_regUser = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_LogIn
            // 
            this.btn_LogIn.Location = new System.Drawing.Point(35, 35);
            this.btn_LogIn.Name = "btn_LogIn";
            this.btn_LogIn.Size = new System.Drawing.Size(175, 35);
            this.btn_LogIn.TabIndex = 0;
            this.btn_LogIn.Text = "Войти под своей учётной записью ";
            this.btn_LogIn.UseVisualStyleBackColor = true;
            this.btn_LogIn.Click += new System.EventHandler(this.btn_LogIn_Click);
            // 
            // btn_regUser
            // 
            this.btn_regUser.Location = new System.Drawing.Point(35, 93);
            this.btn_regUser.Name = "btn_regUser";
            this.btn_regUser.Size = new System.Drawing.Size(175, 35);
            this.btn_regUser.TabIndex = 1;
            this.btn_regUser.Text = "Регистрация нового пользователя";
            this.btn_regUser.UseVisualStyleBackColor = true;
            this.btn_regUser.Click += new System.EventHandler(this.btn_regUser_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(104, 152);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(106, 25);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.Text = "Выход";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 201);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_regUser);
            this.Controls.Add(this.btn_LogIn);
            this.Name = "InputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_LogIn;
        private System.Windows.Forms.Button btn_regUser;
        private System.Windows.Forms.Button btn_exit;
    }
}