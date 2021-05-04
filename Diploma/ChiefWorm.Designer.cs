
namespace Diploma
{
    partial class ChiefWorm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_task = new System.Windows.Forms.Label();
            this.lb_date = new System.Windows.Forms.Label();
            this.lb_date_time = new System.Windows.Forms.Label();
            this.btn_create = new System.Windows.Forms.Button();
            this.dgv_prifiles = new System.Windows.Forms.DataGridView();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuMain = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьЗаявкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prifiles)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_task
            // 
            this.lb_task.AutoSize = true;
            this.lb_task.Location = new System.Drawing.Point(24, 36);
            this.lb_task.Name = "lb_task";
            this.lb_task.Size = new System.Drawing.Size(58, 13);
            this.lb_task.TabIndex = 0;
            this.lb_task.Text = "Заявка №";
            // 
            // lb_date
            // 
            this.lb_date.AutoSize = true;
            this.lb_date.Location = new System.Drawing.Point(107, 36);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(39, 13);
            this.lb_date.TabIndex = 2;
            this.lb_date.Text = "Дата: ";
            // 
            // lb_date_time
            // 
            this.lb_date_time.AutoSize = true;
            this.lb_date_time.Location = new System.Drawing.Point(152, 36);
            this.lb_date_time.Name = "lb_date_time";
            this.lb_date_time.Size = new System.Drawing.Size(0, 13);
            this.lb_date_time.TabIndex = 3;
            // 
            // btn_create
            // 
            this.btn_create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_create.Location = new System.Drawing.Point(137, 420);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(134, 45);
            this.btn_create.TabIndex = 14;
            this.btn_create.Text = "Создать заявку";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // dgv_prifiles
            // 
            this.dgv_prifiles.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_prifiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_prifiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col1,
            this.Column2});
            this.dgv_prifiles.Location = new System.Drawing.Point(27, 70);
            this.dgv_prifiles.Name = "dgv_prifiles";
            this.dgv_prifiles.Size = new System.Drawing.Size(244, 319);
            this.dgv_prifiles.TabIndex = 15;
            this.dgv_prifiles.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_prifiles_CellValidating);
            this.dgv_prifiles.DoubleClick += new System.EventHandler(this.dgv_prifiles_DoubleClick);
            // 
            // col1
            // 
            this.col1.HeaderText = "Профиль";
            this.col1.Name = "col1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Количество";
            this.Column2.Name = "Column2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuMain});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(309, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuMain
            // 
            this.MenuMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показатьЗаявкуToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Size = new System.Drawing.Size(53, 20);
            this.MenuMain.Text = "Меню";
            // 
            // показатьЗаявкуToolStripMenuItem
            // 
            this.показатьЗаявкуToolStripMenuItem.Name = "показатьЗаявкуToolStripMenuItem";
            this.показатьЗаявкуToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.показатьЗаявкуToolStripMenuItem.Text = "Посмотреть заявку";
            this.показатьЗаявкуToolStripMenuItem.Click += new System.EventHandler(this.показатьЗаявкуToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // ChiefWorm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 506);
            this.Controls.Add(this.dgv_prifiles);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.lb_date_time);
            this.Controls.Add(this.lb_date);
            this.Controls.Add(this.lb_task);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ChiefWorm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChiefWorm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prifiles)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_task;
        private System.Windows.Forms.Label lb_date;
        private System.Windows.Forms.Label lb_date_time;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.DataGridView dgv_prifiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuMain;
        private System.Windows.Forms.ToolStripMenuItem показатьЗаявкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
    }
}

