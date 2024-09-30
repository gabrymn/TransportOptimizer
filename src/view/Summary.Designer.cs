
namespace TransportOptimizer.src.view
{
    partial class Summary
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dgv1 = new DataGridView();
            Column4 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            exit0 = new Button();
            save0 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv1).BeginInit();
            SuspendLayout();
            // 
            // dgv1
            // 
            dgv1.AllowUserToAddRows = false;
            dgv1.AllowUserToDeleteRows = false;
            dgv1.AllowUserToResizeColumns = false;
            dgv1.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(44, 48, 52);
            dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgv1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv1.BackgroundColor = Color.FromArgb(64, 64, 64);
            dgv1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(15, 16, 18);
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(63, 63, 65);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgv1.ColumnHeadersHeight = 50;
            dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv1.Columns.AddRange(new DataGridViewColumn[] { Column4, Column1, Column2, Column3 });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(114, 117, 119);
            dataGridViewCellStyle6.SelectionForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgv1.DefaultCellStyle = dataGridViewCellStyle6;
            dgv1.EnableHeadersVisualStyles = false;
            dgv1.GridColor = Color.FromArgb(50, 56, 62);
            dgv1.Location = new Point(30, 27);
            dgv1.Margin = new Padding(2, 3, 2, 3);
            dgv1.Name = "dgv1";
            dgv1.ReadOnly = true;
            dgv1.RowHeadersVisible = false;
            dgv1.RowHeadersWidth = 51;
            dgv1.RowTemplate.Height = 50;
            dgv1.RowTemplate.ReadOnly = true;
            dgv1.ScrollBars = ScrollBars.Vertical;
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.Size = new Size(858, 507);
            dgv1.TabIndex = 3;
            // 
            // Column4
            // 
            Column4.HeaderText = "ID";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.HeaderText = "Quantity";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Movement";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Cost";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // exit0
            // 
            exit0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            exit0.BackColor = Color.FromArgb(20, 20, 20);
            exit0.Cursor = Cursors.Hand;
            exit0.FlatStyle = FlatStyle.Flat;
            exit0.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exit0.ForeColor = Color.White;
            exit0.Location = new Point(344, 553);
            exit0.Margin = new Padding(2, 3, 2, 3);
            exit0.Name = "exit0";
            exit0.Size = new Size(232, 71);
            exit0.TabIndex = 4;
            exit0.Text = "Exit";
            exit0.UseVisualStyleBackColor = false;
            exit0.Click += exit0_Click;
            // 
            // save0
            // 
            save0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            save0.BackColor = Color.FromArgb(20, 20, 20);
            save0.Cursor = Cursors.Hand;
            save0.FlatStyle = FlatStyle.Flat;
            save0.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            save0.ForeColor = Color.White;
            save0.Location = new Point(582, 553);
            save0.Margin = new Padding(2, 3, 2, 3);
            save0.Name = "save0";
            save0.Size = new Size(306, 71);
            save0.TabIndex = 5;
            save0.Text = "Save (JSON)";
            save0.UseVisualStyleBackColor = false;
            save0.Click += save0_Click;
            // 
            // Summary
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(919, 655);
            Controls.Add(save0);
            Controls.Add(exit0);
            Controls.Add(dgv1);
            Margin = new Padding(2, 3, 2, 3);
            MinimumSize = new Size(921, 363);
            Name = "Summary";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Summary";
            FormClosing += Summary_FormClosing;
            Load += Final_Load;
            ((System.ComponentModel.ISupportInitialize)dgv1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button exit0;
        private System.Windows.Forms.Button save0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}