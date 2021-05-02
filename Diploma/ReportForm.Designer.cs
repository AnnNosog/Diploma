
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lb_report = new System.Windows.Forms.Label();
            this.cmb_report = new System.Windows.Forms.ComboBox();
            this.btn_reportShow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(433, 164);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(254, 208);
            this.dataGridView1.TabIndex = 0;
            // 
            // lb_report
            // 
            this.lb_report.AutoSize = true;
            this.lb_report.Location = new System.Drawing.Point(49, 18);
            this.lb_report.Name = "lb_report";
            this.lb_report.Size = new System.Drawing.Size(95, 13);
            this.lb_report.TabIndex = 1;
            this.lb_report.Text = "Выберите заявку";
            // 
            // cmb_report
            // 
            this.cmb_report.FormattingEnabled = true;
            this.cmb_report.Location = new System.Drawing.Point(52, 45);
            this.cmb_report.Name = "cmb_report";
            this.cmb_report.Size = new System.Drawing.Size(88, 21);
            this.cmb_report.TabIndex = 2;
            // 
            // btn_reportShow
            // 
            this.btn_reportShow.Location = new System.Drawing.Point(52, 94);
            this.btn_reportShow.Name = "btn_reportShow";
            this.btn_reportShow.Size = new System.Drawing.Size(87, 25);
            this.btn_reportShow.TabIndex = 3;
            this.btn_reportShow.Text = "Показать";
            this.btn_reportShow.UseVisualStyleBackColor = true;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 518);
            this.Controls.Add(this.btn_reportShow);
            this.Controls.Add(this.cmb_report);
            this.Controls.Add(this.lb_report);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lb_report;
        private System.Windows.Forms.ComboBox cmb_report;
        private System.Windows.Forms.Button btn_reportShow;
    }
}