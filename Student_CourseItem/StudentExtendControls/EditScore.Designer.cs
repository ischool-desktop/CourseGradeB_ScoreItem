namespace BasicInformation.Student_CourseItem.StudentExtendControls
{
    partial class EditScore
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Midtern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Final = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_save = new DevComponents.DotNetBar.ButtonX();
            this.btn_quit = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Name,
            this.Col_Midtern,
            this.Col_Final});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 24;
            this.dataGridViewX1.Size = new System.Drawing.Size(447, 208);
            this.dataGridViewX1.TabIndex = 0;
            // 
            // Col_Name
            // 
            this.Col_Name.HeaderText = "課程名稱";
            this.Col_Name.Name = "Col_Name";
            this.Col_Name.Width = 204;
            // 
            // Col_Midtern
            // 
            this.Col_Midtern.HeaderText = "Midtern";
            this.Col_Midtern.Name = "Col_Midtern";
            // 
            // Col_Final
            // 
            this.Col_Final.HeaderText = "Final";
            this.Col_Final.Name = "Col_Final";
            // 
            // btn_save
            // 
            this.btn_save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_save.BackColor = System.Drawing.Color.Transparent;
            this.btn_save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_save.Location = new System.Drawing.Point(303, 226);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "儲存";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_quit
            // 
            this.btn_quit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_quit.BackColor = System.Drawing.Color.Transparent;
            this.btn_quit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_quit.Location = new System.Drawing.Point(384, 226);
            this.btn_quit.Name = "btn_quit";
            this.btn_quit.Size = new System.Drawing.Size(75, 23);
            this.btn_quit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_quit.TabIndex = 2;
            this.btn_quit.Text = "離開";
            this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click);
            // 
            // EditScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 261);
            this.Controls.Add(this.btn_quit);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.dataGridViewX1);
            this.DoubleBuffered = true;
            this.Name = "EditScore";
            this.Text = "編輯課程評量成績";
            this.Load += new System.EventHandler(this.EditScore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX btn_save;
        private DevComponents.DotNetBar.ButtonX btn_quit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Midtern;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Final;
    }
}