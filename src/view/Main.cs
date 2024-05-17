using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using TransportOptimizer.src.utils;
using TransportOptimizer.src.model;

namespace TransportOptimizer.src.view
{
    public partial class Main : Form
    {
        private Table table;
        private delegate void UpdateControlsDelegate();
        private dynamic Buffer;
        private bool Running;

        public Main()
        {
            InitializeComponent();
            table = new Table(15, 15, dataGridView1);
            CheckForIllegalCrossThreadCalls = true;
            MinimumSize = new Size(Width, 0);
            label7.Select();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table.Enable();
            SetTextBoxs(new System.Windows.Forms.TextBox[] { textBox1, textBox2, tbMinVal, tbMaxVal });
            SetMSComboBox();
        }

        public void SetMSComboBox()
        {
            methods.Items.AddRange(Const.METHODS);
            methods.Sorted = false;
            methods.SelectedItem = methods.Items[0];
        }

        public void SetTextBoxs(System.Windows.Forms.TextBox[] tbs)
        {
            int tag = 0;

            foreach (var tb in tbs)
            {
                tb.Tag = tag; tag++;
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
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;

            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.ForeColor = Color.Silver;
                tb.Text = Const.TERMS[(int)tb.Tag];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Running)
            {
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            if (!(Utils.SkipCheck(textBox1.Text, textBox2.Text, Const.TERMS)))
            {
                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
                    if (table.RowsCount != int.Parse(textBox1.Text) || table.ColumnsCount != int.Parse(textBox2.Text))
                        table = new Table(int.Parse(textBox1.Text), int.Parse(textBox2.Text), dataGridView1, true);
            }
            else 
                System.Media.SystemSounds.Hand.Play();
        }

        private void textBoxRC_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;

            if (!Const.TERMS.Contains(tb.Text))
                Utils.ValidateTextBox(tb);
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            table.ControlCurrentCellValue();
        }

        private void btnExeRd_Click(object sender, EventArgs e)
        {
            if (Running)
            {
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            if (!Utils.SkipCheck(tbMinVal.Text, tbMaxVal.Text, Const.TERMS))
            {
                var min = int.Parse(tbMinVal.Text);
                var max = int.Parse(tbMaxVal.Text);

                if (min <= max)
                    table.Randomize(min, max);
                else
                {
                    System.Media.SystemSounds.Hand.Play();
                    var a = tbMinVal.Text;
                    var b = tbMaxVal.Text;
                    Utils.Swap<string>(ref a, ref b);
                    tbMinVal.Text = a;
                    tbMaxVal.Text = b;
                }
            }
            else System.Media.SystemSounds.Hand.Play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Running)
            {
                System.Media.SystemSounds.Hand.Play();
                return;
            }
            table.Clear();
        }

        /// <summary>
        ///  Controlla che un thread non abbia accesso a una risorsa di cui non è il creatore
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
            if (Running)
            {
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            if (table.Full == false)
            {
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show(Const.ALL_CELLS_REQ_MSG);
            }
            else if (table.ControlStart() == false)
            {
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show(Const.CHECK_LAST_ROW_COLUMN_DATA_MSG);
            }
            else
            {
                Running = true;
                table.ReadOnly(true);
                Buffer = Tuple.Create(table.RowsCount, table.ColumnsCount, table.GetData());
                string method = methods.SelectedItem.ToString();

                InvokeUpdateControls(() => middleware.Method.Run(method, table, this));
            }
        }

        public void CallReset()
        {
            table.VisibleStatus(true);

            try
            {
                table = new Table(Buffer.Item1, Buffer.Item2, dataGridView1, Buffer.Item3, true);
                table.ReadOnly(false);
                Running = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(Const.LOST_DATA_MSG);
                Console.WriteLine(e);
                table = new Table(15, 15, dataGridView1, true);
            }
            //Task.Run(ResetBuffer);
        }

        private void ResetBuffer()
        {
            Task.Delay(200);
            Buffer = null;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            label1.Select();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs k)
        {
            if (Running)
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
    }
}
