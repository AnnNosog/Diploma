
namespace Diploma
{
    partial class ReportWorkerForm
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
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_reportShow = new System.Windows.Forms.Button();
            this.cmb_report = new System.Windows.Forms.ComboBox();
            this.lb_report = new System.Windows.Forms.Label();
            this.dgw_report = new System.Windows.Forms.DataGridView();
            this.cmb_date = new System.Windows.Forms.ComboBox();
            this.lb_date = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_report)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(12, 349);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(127, 29);
            this.btn_save.TabIndex = 11;
            this.btn_save.Text = "Сохранить";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_reportShow
            // 
            this.btn_reportShow.Location = new System.Drawing.Point(357, 25);
            this.btn_reportShow.Name = "btn_reportShow";
            this.btn_reportShow.Size = new System.Drawing.Size(119, 30);
            this.btn_reportShow.TabIndex = 9;
            this.btn_reportShow.Text = "Показать";
            this.btn_reportShow.UseVisualStyleBackColor = true;
            this.btn_reportShow.Click += new System.EventHandler(this.btn_reportShow_Click);
            // 
            // cmb_report
            // 
            this.cmb_report.FormattingEnabled = true;
            this.cmb_report.Location = new System.Drawing.Point(15, 31);
            this.cmb_report.Name = "cmb_report";
            this.cmb_report.Size = new System.Drawing.Size(103, 21);
            this.cmb_report.TabIndex = 8;
            // 
            // lb_report
            // 
            this.lb_report.AutoSize = true;
            this.lb_report.Location = new System.Drawing.Point(12, 9);
            this.lb_report.Name = "lb_report";
            this.lb_report.Size = new System.Drawing.Size(106, 13);
            this.lb_report.TabIndex = 7;
            this.lb_report.Text = "Выберите рабочего";
            // 
            // dgw_report
            // 
            this.dgw_report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_report.Location = new System.Drawing.Point(12, 93);
            this.dgw_report.Name = "dgw_report";
            this.dgw_report.Size = new System.Drawing.Size(530, 230);
            this.dgw_report.TabIndex = 6;
            // 
            // cmb_date
            // 
            this.cmb_date.FormattingEnabled = true;
            this.cmb_date.Location = new System.Drawing.Point(188, 31);
            this.cmb_date.Name = "cmb_date";
            this.cmb_date.Size = new System.Drawing.Size(103, 21);
            this.cmb_date.TabIndex = 13;
            // 
            // lb_date
            // 
            this.lb_date.AutoSize = true;
            this.lb_date.Location = new System.Drawing.Point(185, 9);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(82, 13);
            this.lb_date.TabIndex = 12;
            this.lb_date.Text = "Выберите дату";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ReportWorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 401);
            this.Controls.Add(this.cmb_date);
            this.Controls.Add(this.lb_date);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_reportShow);
            this.Controls.Add(this.cmb_report);
            this.Controls.Add(this.lb_report);
            this.Controls.Add(this.dgw_report);
            this.Name = "ReportWorkerForm";
            this.Text = "Отчёт по рабочим";
            this.Load += new System.EventHandler(this.ReportWorkerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_report)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_reportShow;
        private System.Windows.Forms.ComboBox cmb_report;
        private System.Windows.Forms.Label lb_report;
        private System.Windows.Forms.DataGridView dgw_report;
        private System.Windows.Forms.ComboBox cmb_date;
        private System.Windows.Forms.Label lb_date;
        private System.Windows.Forms.Button button1;
    }
}