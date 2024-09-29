
namespace TransportOptimizer.src.view
{
    partial class Loading
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
            label3 = new Label();
            label1 = new Label();
            progressBar = new Panel();
            label2 = new Label();
            panel1 = new Panel();
            label4 = new Label();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Cyan;
            label3.Location = new Point(103, 304);
            label3.Name = "label3";
            label3.Size = new Size(0, 31);
            label3.TabIndex = 6;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Light", 43.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(135, 163);
            label1.Name = "label1";
            label1.Size = new Size(875, 128);
            label1.TabIndex = 9;
            label1.Text = "Transport Optimizer";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            progressBar.BackColor = Color.GreenYellow;
            progressBar.Location = new Point(-10, 546);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(1138, 10);
            progressBar.TabIndex = 15;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Light", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LightSteelBlue;
            label2.Location = new Point(630, 335);
            label2.Name = "label2";
            label2.Size = new Size(215, 93);
            label2.TabIndex = 16;
            label2.Text = "Developed by";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Location = new Point(135, 313);
            panel1.Name = "panel1";
            panel1.Size = new Size(875, 1);
            panel1.TabIndex = 17;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.LightSteelBlue;
            label4.Location = new Point(834, 335);
            label4.Name = "label4";
            label4.Size = new Size(179, 93);
            label4.TabIndex = 18;
            label4.Text = "gabrymn";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Loading
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(1127, 551);
            Controls.Add(label4);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(progressBar);
            Controls.Add(label1);
            Controls.Add(label3);
            Font = new Font("Trebuchet MS", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Loading";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loading";
            Load += Loading_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel progressBar;
        private Label label2;
        private Panel panel1;
        private Label label4;
    }
}