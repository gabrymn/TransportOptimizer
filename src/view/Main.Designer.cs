
namespace TransportOptimizer.src.view
{
    partial class Main
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            button1 = new Button();
            button3 = new Button();
            panel4 = new Panel();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            panel2 = new Panel();
            label6 = new Label();
            methods = new ComboBox();
            button4 = new Button();
            tbMaxVal = new TextBox();
            btnExeRd = new Button();
            tbMinVal = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            button2 = new Button();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(245, 82);
            textBox1.Margin = new Padding(5, 6, 5, 6);
            textBox1.MaxLength = 2;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(89, 34);
            textBox1.TabIndex = 1;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBoxRC_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(245, 132);
            textBox2.Margin = new Padding(5, 6, 5, 6);
            textBox2.MaxLength = 2;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(89, 34);
            textBox2.TabIndex = 2;
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBoxRC_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(93, 138);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(125, 28);
            label2.TabIndex = 17;
            label2.Text = "Destinations";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.GreenYellow;
            label1.Location = new Point(115, 22);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(170, 31);
            label1.TabIndex = 21;
            label1.Text = "Table Structure";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(53, 88);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(165, 28);
            label4.TabIndex = 18;
            label4.Text = "Production Units";
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(59, 212);
            button1.Margin = new Padding(5, 6, 5, 6);
            button1.Name = "button1";
            button1.Size = new Size(277, 46);
            button1.TabIndex = 3;
            button1.Text = "Set";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackColor = Color.Black;
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(62, 212);
            button3.Margin = new Padding(5, 6, 5, 6);
            button3.Name = "button3";
            button3.Size = new Size(277, 46);
            button3.TabIndex = 34;
            button3.Text = "Run";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click_2;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(20, 20, 20);
            panel4.Controls.Add(button1);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(textBox2);
            panel4.Controls.Add(textBox1);
            panel4.Location = new Point(29, 36);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.MinimumSize = new Size(395, 292);
            panel4.Name = "panel4";
            panel4.Size = new Size(395, 292);
            panel4.TabIndex = 19;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(44, 48, 52);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Yu Gothic UI", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Silver;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(63, 63, 65);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.Font = new Font("Yu Gothic UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(50, 56, 62);
            dataGridView1.Location = new Point(29, 350);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(15, 16, 18);
            dataGridViewCellStyle4.Font = new Font("Yu Gothic UI", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Silver;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(63, 63, 65);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.RowHeadersWidth = 80;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(1203, 444);
            dataGridView1.TabIndex = 37;
            dataGridView1.CellValidated += dataGridView1_CellValidated;
            dataGridView1.KeyPress += dataGridView1_KeyPress;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.GreenYellow;
            label5.Location = new Point(144, 22);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(123, 31);
            label5.TabIndex = 24;
            label5.Text = "Resolution";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(20, 20, 20);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(methods);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(button3);
            panel2.Location = new Point(837, 36);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.MinimumSize = new Size(395, 292);
            panel2.Name = "panel2";
            panel2.Size = new Size(395, 292);
            panel2.TabIndex = 39;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(63, 94);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(160, 28);
            label6.TabIndex = 43;
            label6.Text = "Select a method";
            // 
            // methods
            // 
            methods.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            methods.BackColor = Color.White;
            methods.DropDownStyle = ComboBoxStyle.DropDownList;
            methods.FlatStyle = FlatStyle.Flat;
            methods.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            methods.ForeColor = Color.Black;
            methods.FormattingEnabled = true;
            methods.IntegralHeight = false;
            methods.ItemHeight = 28;
            methods.Location = new Point(63, 134);
            methods.Margin = new Padding(3, 2, 3, 2);
            methods.Name = "methods";
            methods.Size = new Size(276, 36);
            methods.TabIndex = 42;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top;
            button4.BackColor = Color.Black;
            button4.Cursor = Cursors.Hand;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(230, 212);
            button4.Margin = new Padding(5, 6, 5, 6);
            button4.Name = "button4";
            button4.Size = new Size(128, 46);
            button4.TabIndex = 15;
            button4.Text = "Clear";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // tbMaxVal
            // 
            tbMaxVal.Anchor = AnchorStyles.Top;
            tbMaxVal.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbMaxVal.Location = new Point(199, 82);
            tbMaxVal.Margin = new Padding(5, 6, 5, 6);
            tbMaxVal.MaxLength = 5;
            tbMaxVal.Name = "tbMaxVal";
            tbMaxVal.Size = new Size(157, 34);
            tbMaxVal.TabIndex = 7;
            tbMaxVal.TextAlign = HorizontalAlignment.Center;
            tbMaxVal.TextChanged += textBoxRC_TextChanged;
            // 
            // btnExeRd
            // 
            btnExeRd.Anchor = AnchorStyles.Top;
            btnExeRd.BackColor = Color.Black;
            btnExeRd.Cursor = Cursors.Hand;
            btnExeRd.FlatStyle = FlatStyle.Flat;
            btnExeRd.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExeRd.ForeColor = Color.White;
            btnExeRd.Location = new Point(37, 134);
            btnExeRd.Margin = new Padding(5, 6, 5, 6);
            btnExeRd.Name = "btnExeRd";
            btnExeRd.Size = new Size(320, 46);
            btnExeRd.TabIndex = 11;
            btnExeRd.Text = "Generate";
            btnExeRd.UseVisualStyleBackColor = false;
            btnExeRd.Click += btnExeRd_Click;
            // 
            // tbMinVal
            // 
            tbMinVal.Anchor = AnchorStyles.Top;
            tbMinVal.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbMinVal.Location = new Point(37, 82);
            tbMinVal.Margin = new Padding(5, 6, 5, 6);
            tbMinVal.MaxLength = 5;
            tbMinVal.Name = "tbMinVal";
            tbMinVal.Size = new Size(159, 34);
            tbMinVal.TabIndex = 6;
            tbMinVal.TextAlign = HorizontalAlignment.Center;
            tbMinVal.TextChanged += textBoxRC_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.GreenYellow;
            label3.Location = new Point(109, 22);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(194, 31);
            label3.TabIndex = 23;
            label3.Text = "Data Managment";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(20, 20, 20);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(tbMinVal);
            panel1.Controls.Add(btnExeRd);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(tbMaxVal);
            panel1.Location = new Point(431, 36);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.MinimumSize = new Size(400, 292);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 292);
            panel1.TabIndex = 38;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.BackColor = Color.Black;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(37, 212);
            button2.Margin = new Padding(5, 6, 5, 6);
            button2.Name = "button2";
            button2.Size = new Size(188, 46);
            button2.TabIndex = 24;
            button2.Text = "Import (CSV)";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1261, 840);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(panel4);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Main";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            Click += Form1_Click;
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox methods;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tbMaxVal;
        private System.Windows.Forms.Button btnExeRd;
        private System.Windows.Forms.TextBox tbMinVal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private Button button2;
    }
}

