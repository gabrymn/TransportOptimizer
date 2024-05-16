
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
            label7 = new Label();
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
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Light", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(11, 22);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.MinimumSize = new Size(888, 60);
            label7.Name = "label7";
            label7.Size = new Size(1082, 60);
            label7.TabIndex = 9;
            label7.Text = "Transport Optimizer Tool";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(214, 62);
            textBox1.Margin = new Padding(4);
            textBox1.MaxLength = 2;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(78, 29);
            textBox1.TabIndex = 1;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBoxRC_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(214, 99);
            textBox2.Margin = new Padding(4);
            textBox2.MaxLength = 2;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(78, 29);
            textBox2.TabIndex = 2;
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBoxRC_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(74, 108);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 21);
            label2.TabIndex = 17;
            label2.Text = "Destinations";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Cyan;
            label1.Location = new Point(101, 17);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(137, 25);
            label1.TabIndex = 21;
            label1.Text = "Table Structure";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(36, 70);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(126, 21);
            label4.TabIndex = 18;
            label4.Text = "Production Units";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(34, 31, 46);
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(52, 159);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(242, 34);
            button1.TabIndex = 3;
            button1.Text = "Set";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackColor = Color.FromArgb(34, 31, 46);
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 11.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(55, 159);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(242, 34);
            button3.TabIndex = 34;
            button3.Text = "Run";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click_2;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(34, 31, 46);
            panel4.Controls.Add(button1);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(textBox2);
            panel4.Controls.Add(textBox1);
            panel4.Location = new Point(25, 98);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.MinimumSize = new Size(346, 219);
            panel4.Name = "panel4";
            panel4.Size = new Size(346, 219);
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
            dataGridView1.BackgroundColor = Color.FromArgb(34, 31, 46);
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
            dataGridView1.Location = new Point(25, 347);
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
            dataGridView1.Size = new Size(1053, 426);
            dataGridView1.TabIndex = 37;
            dataGridView1.CellValidated += dataGridView1_CellValidated;
            dataGridView1.KeyPress += dataGridView1_KeyPress;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Cyan;
            label5.Location = new Point(126, 17);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(100, 25);
            label5.TabIndex = 24;
            label5.Text = "Resolution";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(34, 31, 46);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(methods);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(button3);
            panel2.Location = new Point(732, 98);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.MinimumSize = new Size(346, 219);
            panel2.Name = "panel2";
            panel2.Size = new Size(346, 219);
            panel2.TabIndex = 39;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(81, 62);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(121, 21);
            label6.TabIndex = 43;
            label6.Text = "Select a method";
            // 
            // methods
            // 
            methods.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            methods.BackColor = Color.White;
            methods.DropDownStyle = ComboBoxStyle.DropDownList;
            methods.FlatStyle = FlatStyle.Flat;
            methods.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            methods.ForeColor = Color.Black;
            methods.FormattingEnabled = true;
            methods.IntegralHeight = false;
            methods.ItemHeight = 21;
            methods.Location = new Point(55, 100);
            methods.Margin = new Padding(3, 2, 3, 2);
            methods.Name = "methods";
            methods.Size = new Size(242, 29);
            methods.TabIndex = 42;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top;
            button4.BackColor = Color.FromArgb(34, 31, 46);
            button4.Cursor = Cursors.Hand;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 11.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(32, 159);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(280, 34);
            button4.TabIndex = 15;
            button4.Text = "Clear";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // tbMaxVal
            // 
            tbMaxVal.Anchor = AnchorStyles.Top;
            tbMaxVal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbMaxVal.Location = new Point(174, 62);
            tbMaxVal.Margin = new Padding(4);
            tbMaxVal.MaxLength = 5;
            tbMaxVal.Name = "tbMaxVal";
            tbMaxVal.Size = new Size(140, 29);
            tbMaxVal.TabIndex = 7;
            tbMaxVal.TextAlign = HorizontalAlignment.Center;
            tbMaxVal.TextChanged += textBoxRC_TextChanged;
            // 
            // btnExeRd
            // 
            btnExeRd.Anchor = AnchorStyles.Top;
            btnExeRd.BackColor = Color.FromArgb(34, 31, 46);
            btnExeRd.Cursor = Cursors.Hand;
            btnExeRd.FlatStyle = FlatStyle.Flat;
            btnExeRd.Font = new Font("Segoe UI", 11.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExeRd.ForeColor = Color.White;
            btnExeRd.Location = new Point(32, 100);
            btnExeRd.Margin = new Padding(4);
            btnExeRd.Name = "btnExeRd";
            btnExeRd.Size = new Size(280, 35);
            btnExeRd.TabIndex = 11;
            btnExeRd.Text = "Generate";
            btnExeRd.UseVisualStyleBackColor = false;
            btnExeRd.Click += btnExeRd_Click;
            // 
            // tbMinVal
            // 
            tbMinVal.Anchor = AnchorStyles.Top;
            tbMinVal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbMinVal.Location = new Point(32, 62);
            tbMinVal.Margin = new Padding(4);
            tbMinVal.MaxLength = 5;
            tbMinVal.Name = "tbMinVal";
            tbMinVal.Size = new Size(140, 29);
            tbMinVal.TabIndex = 6;
            tbMinVal.TextAlign = HorizontalAlignment.Center;
            tbMinVal.TextChanged += textBoxRC_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Cyan;
            label3.Location = new Point(95, 17);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(158, 25);
            label3.TabIndex = 23;
            label3.Text = "Data Managment";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(34, 31, 46);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(tbMinVal);
            panel1.Controls.Add(btnExeRd);
            panel1.Controls.Add(tbMaxVal);
            panel1.Controls.Add(button4);
            panel1.Location = new Point(377, 98);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.MinimumSize = new Size(350, 219);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 219);
            panel1.TabIndex = 38;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(54, 51, 66);
            ClientSize = new Size(1103, 702);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(panel4);
            Controls.Add(label7);
            Margin = new Padding(4);
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

        private System.Windows.Forms.Label label7;
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
    }
}

