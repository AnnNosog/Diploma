
namespace Diploma
{
    partial class RegUserWorm
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
            this.tb_userNameReg = new System.Windows.Forms.TextBox();
            this.lb_UserNameReg = new System.Windows.Forms.Label();
            this.lb_PasswordReg = new System.Windows.Forms.Label();
            this.tb_passwordReg = new System.Windows.Forms.TextBox();
            this.btn_reg = new System.Windows.Forms.Button();
            this.cmb_role = new System.Windows.Forms.ComboBox();
            this.lb_role = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_loginReg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_userNameReg
            // 
            this.tb_userNameReg.Location = new System.Drawing.Point(42, 43);
            this.tb_userNameReg.Name = "tb_userNameReg";
            this.tb_userNameReg.Size = new System.Drawing.Size(149, 20);
            this.tb_userNameReg.TabIndex = 0;
            // 
            // lb_UserNameReg
            // 
            this.lb_UserNameReg.AutoSize = true;
            this.lb_UserNameReg.Location = new System.Drawing.Point(39, 27);
            this.lb_UserNameReg.Name = "lb_UserNameReg";
            this.lb_UserNameReg.Size = new System.Drawing.Size(72, 13);
            this.lb_UserNameReg.TabIndex = 1;
            this.lb_UserNameReg.Text = "Введите имя";
            // 
            // lb_PasswordReg
            // 
            this.lb_PasswordReg.AutoSize = true;
            this.lb_PasswordReg.Location = new System.Drawing.Point(39, 125);
            this.lb_PasswordReg.Name = "lb_PasswordReg";
            this.lb_PasswordReg.Size = new System.Drawing.Size(108, 13);
            this.lb_PasswordReg.TabIndex = 3;
            this.lb_PasswordReg.Text = "Придумайте пароль";
            // 
            // tb_passwordReg
            // 
            this.tb_passwordReg.Location = new System.Drawing.Point(42, 141);
            this.tb_passwordReg.Name = "tb_passwordReg";
            this.tb_passwordReg.Size = new System.Drawing.Size(149, 20);
            this.tb_passwordReg.TabIndex = 2;
            // 
            // btn_reg
            // 
            this.btn_reg.Location = new System.Drawing.Point(81, 245);
            this.btn_reg.Name = "btn_reg";
            this.btn_reg.Size = new System.Drawing.Size(108, 26);
            this.btn_reg.TabIndex = 4;
            this.btn_reg.Text = "Регистрация";
            this.btn_reg.UseVisualStyleBackColor = true;
            this.btn_reg.Click += new System.EventHandler(this.btn_reg_Click);
            // 
            // cmb_role
            // 
            this.cmb_role.FormattingEnabled = true;
            this.cmb_role.Location = new System.Drawing.Point(42, 191);
            this.cmb_role.Name = "cmb_role";
            this.cmb_role.Size = new System.Drawing.Size(147, 21);
            this.cmb_role.TabIndex = 3;
            // 
            // lb_role
            // 
            this.lb_role.AutoSize = true;
            this.lb_role.Location = new System.Drawing.Point(46, 175);
            this.lb_role.Name = "lb_role";
            this.lb_role.Size = new System.Drawing.Size(84, 13);
            this.lb_role.TabIndex = 6;
            this.lb_role.Text = "Выберите роль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Введите логин";
            // 
            // tb_loginReg
            // 
            this.tb_loginReg.Location = new System.Drawing.Point(42, 92);
            this.tb_loginReg.Name = "tb_loginReg";
            this.tb_loginReg.Size = new System.Drawing.Size(149, 20);
            this.tb_loginReg.TabIndex = 1;
            // 
            // RegUserWorm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 308);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_loginReg);
            this.Controls.Add(this.lb_role);
            this.Controls.Add(this.cmb_role);
            this.Controls.Add(this.btn_reg);
            this.Controls.Add(this.lb_PasswordReg);
            this.Controls.Add(this.tb_passwordReg);
            this.Controls.Add(this.lb_UserNameReg);
            this.Controls.Add(this.tb_userNameReg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RegUserWorm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.RegUserWorm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_userNameReg;
        private System.Windows.Forms.Label lb_UserNameReg;
        private System.Windows.Forms.Label lb_PasswordReg;
        private System.Windows.Forms.TextBox tb_passwordReg;
        private System.Windows.Forms.Button btn_reg;
        private System.Windows.Forms.ComboBox cmb_role;
        private System.Windows.Forms.Label lb_role;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_loginReg;
    }
}