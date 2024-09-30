using TransportOptimizer.src.utils;
using TransportOptimizer.src.model;
using TransportOptimizer.src.middleware;
using TransportOptimizer.src.view.components;

namespace TransportOptimizer.src.view
{
    public partial class Main : Form
    {
        private DGVData dgvd;
        private delegate void UpdateControlsDelegate();
        private dynamic Buffer;
        private bool MethodIsRunning;

        public Main()
        {
            InitializeComponent();

            dgvd = new DGVData(Const.DEFAULT_TABLE_ROWS, Const.DEFAULT_TABLE_COLUMNS, dataGridView1);

            CheckForIllegalCrossThreadCalls = true;
            MinimumSize = new Size(Width, 0);

            label3.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.SetVisualElements(Const.DEFAULT_TABLE_ROWS, Const.DEFAULT_TABLE_COLUMNS);

            SetTextBoxs([textBox1, textBox2, tbMinVal, tbMaxVal]);
            SetMSComboBox();
        }

        public void SetMSComboBox()
        {
            methods.Items.AddRange(Const.METHODS);
            methods.Sorted = false;
            methods.SelectedItem = methods.Items[0];
        }

        public void SetTextBoxs(TextBox[] tbs)
        {
            int tag = 0;

            foreach (var tb in tbs)
            {
                tb.Tag = tag;
                tag++;
                tb.Text = Const.TERMS[(int)tb.Tag];
                tb.ForeColor = Color.Silver;
                tb.GotFocus += RemoveText;
                tb.LostFocus += AddText;
            }
        }

        public void RemoveText(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;
            tb.ForeColor = Color.Black;

            if (tb.Text == Const.TERMS[(int)tb.Tag])
                tb.Text = string.Empty;
        }

        public void AddText(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.ForeColor = Color.Silver;
                tb.Text = Const.TERMS[(int)tb.Tag];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MethodIsRunning)
            {
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            if ((Const.TERMS.Contains(textBox1.Text) || Const.TERMS.Contains(textBox2.Text)) == false)
            {
                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
                {
                    if (dgvd.RowsCount != int.Parse(textBox1.Text) || dgvd.ColumnsCount != int.Parse(textBox2.Text))
                    {
                        int newRowsCount = int.Parse(textBox1.Text);
                        int newColumnsCount = int.Parse(textBox2.Text);

                        dgvd = new DGVData(newRowsCount, newColumnsCount, dataGridView1);
                        dataGridView1.SetVisualElements(newRowsCount, newColumnsCount);
                    }
                }

            }
            else
                System.Media.SystemSounds.Hand.Play();
        }

        private void textBoxRC_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (Const.TERMS.Contains(tb.Text) == false)
                tb.ValidateText();
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dgvd.CheckCellValueInserted();
        }

        private void btnExeRd_Click(object sender, EventArgs e)
        {
            if (MethodIsRunning)
            {
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            if ((Const.TERMS.Contains(tbMinVal.Text) || Const.TERMS.Contains(tbMaxVal.Text)) == false)
            {
                var min = int.Parse(tbMinVal.Text);
                var max = int.Parse(tbMaxVal.Text);

                if (min <= max)
                    dgvd.Randomize(min, max);
                else
                {
                    System.Media.SystemSounds.Hand.Play();

                    var a = tbMinVal.Text;
                    var b = tbMaxVal.Text;

                    var temp = a;
                    a = b;
                    b = temp;

                    tbMinVal.Text = a;
                    tbMaxVal.Text = b;
                }
            }
            else System.Media.SystemSounds.Hand.Play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MethodIsRunning)
            {
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            dgvd.Clear();
        }

        /// <summary>
        ///  Checks that a thread does not have access to a resource for which it is not the creator
        /// </summary>
        public void InvokeUpdateControls(Action action)
        {
            if (InvokeRequired)
                Invoke(new UpdateControlsDelegate(action));
            else
                action();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            if (MethodIsRunning)
            {
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            if (dgvd.IsFull() == false)
            {
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show(Const.ALL_CELLS_REQ_MSG);
            }
            else if (dgvd.DataIsConsistent() == false)
            {
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show(Const.INCONSISTENT_DATA_MSG);
            }
            else
            {
                MethodIsRunning = true;

                dataGridView1.ReadOnly = true;

                // In order to restore the actual state of the table once the method is done,
                // we need to create a backup, which is stored in this variable named "Buffer"
                Buffer = Tuple.Create(dgvd.RowsCount, dgvd.ColumnsCount, dgvd.GetData());

                string chosen_method = methods.SelectedItem.ToString();

                InvokeUpdateControls(() => MethodExecutor.Run(chosen_method, dgvd, dataGridView1, this));
            }
        }

        public void ResetDataGridView()
        {
            dataGridView1.Visible = true;

            try
            {
                int newRowsCount = Buffer.Item1;
                int newColumnsCount = Buffer.Item2;
                int[,] previousDataSet = Buffer.Item3;

                dgvd = new DGVData(newRowsCount, newColumnsCount, dataGridView1);
                dataGridView1.SetVisualElements(newRowsCount, newColumnsCount);
                dgvd.SetData(previousDataSet);

                dataGridView1.ReadOnly = false;
                MethodIsRunning = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(Const.LOST_DATA_MSG);
                Console.WriteLine(e);

                dgvd = new DGVData(Const.DEFAULT_TABLE_ROWS, Const.DEFAULT_TABLE_COLUMNS, dataGridView1);
                dataGridView1.SetVisualElements(Const.DEFAULT_TABLE_ROWS, Const.DEFAULT_TABLE_COLUMNS);
            }
            //Task.Run(ResetBuffer);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            label1.Select();
        }

        /// <summary>
        /// Clear all selected cells in the table
        /// </summary>
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs k)
        {
            if (MethodIsRunning)
            {
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            try
            {
                if (k.KeyChar == (char)Keys.Back)
                {
                    foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                        cell.Value = string.Empty;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // Import CSV button
        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
