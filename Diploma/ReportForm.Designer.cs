
namespace Diploma
{
    partial class ReportForm
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
            this.dgw_report = new System.Windows.Forms.DataGridView();
            this.lb_report = new System.Windows.Forms.Label();
            this.cmb_report = new System.Windows.Forms.ComboBox();
            this.btn_reportShow = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_report)).BeginInit();
            this.SuspendLayout();
            // 
            // dgw_report
            // 
            this.dgw_report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_report.Location = new System.Drawing.Point(12, 103);
            this.dgw_report.Name = "dgw_report";
            this.dgw_report.Size = new System.Drawing.Size(675, 230);
            this.dgw_report.TabIndex = 0;
            // 
            // lb_report
            // 
            this.lb_report.AutoSize = true;
            this.lb_report.Location = new System.Drawing.Point(29, 45);
            this.lb_report.Name = "lb_report";
            this.lb_report.Size = new System.Drawing.Size(95, 13);
            this.lb_report.TabIndex = 1;
            this.lb_report.Text = "Выберите заявку";
            // 
            // cmb_report
            // 
            this.cmb_report.FormattingEnabled = true;
            this.cmb_report.Location = new System.Drawing.Point(146, 42);
            this.cmb_report.Name = "cmb_report";
            this.cmb_report.Size = new System.Drawing.Size(88, 21);
            this.cmb_report.TabIndex = 2;
            // 
            // btn_reportShow
            // 
            this.btn_reportShow.Location = new System.Drawing.Point(283, 36);
            this.btn_reportShow.Name = "btn_reportShow";
            this.btn_reportShow.Size = new System.Drawing.Size(119, 30);
            this.btn_reportShow.TabIndex = 3;
            this.btn_reportShow.Text = "Показать";
            this.btn_reportShow.UseVisualStyleBackColor = true;
            this.btn_reportShow.Click += new System.EventHandler(this.btn_reportShow_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(559, 359);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(127, 29);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(12, 359);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(127, 29);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "Сохранить";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 410);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_reportShow);
            this.Controls.Add(this.cmb_report);
            this.Controls.Add(this.lb_report);
            this.Controls.Add(this.dgw_report);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчёт";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_report)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgw_report;
        private System.Windows.Forms.Label lb_report;
        private System.Windows.Forms.ComboBox cmb_report;
        private System.Windows.Forms.Button btn_reportShow;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_save;
    }
}