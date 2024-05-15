﻿using System;
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
            methods.Items.AddRange(Const.MS);
            methods.Sorted = false;
            methods.SelectedItem = methods.Items[0];
        }

        public void SetTextBoxs(System.Windows.Forms.TextBox[] tbs)
        {
            int tag = 0;

            foreach (var tb in tbs)
            {
                tb.Tag = tag; tag++;
                tb.Text = Const.Terms[(int)tb.Tag];
                tb.ForeColor = Color.Silver;
                tb.GotFocus += RemoveText;
                tb.LostFocus += AddText;
            }
        }

        public void RemoveText(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;
            tb.ForeColor = Color.Black;

            if (tb.Text == Const.Terms[(int)tb.Tag])
                tb.Text = string.Empty;
        }

        public void AddText(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;

            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.ForeColor = Color.Silver;
                tb.Text = Const.Terms[(int)tb.Tag];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Running)
            {
                Const.ESound();
                return;
            }

            if (!(Utils.SkipCheck(textBox1.Text, textBox2.Text, Const.Terms)))
            {
                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
                    if (table.RowsCount != int.Parse(textBox1.Text) || table.ColumnsCount != int.Parse(textBox2.Text))
                        table = new Table(int.Parse(textBox1.Text), int.Parse(textBox2.Text), dataGridView1, true);
            }
            else Const.ESound();
        }

        private void textBoxRC_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;

            if (!Const.Terms.Contains(tb.Text))
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
                Const.ESound();
                return;
            }

            if (!Utils.SkipCheck(tbMinVal.Text, tbMaxVal.Text, Const.Terms))
            {
                var min = int.Parse(tbMinVal.Text);
                var max = int.Parse(tbMaxVal.Text);
                if (min <= max)
                    table.Randomize(min, max);
                else
                {
                    Const.ESound();
                    var a = tbMinVal.Text;
                    var b = tbMaxVal.Text;
                    Const.Swap<string>(ref a, ref b);
                    tbMinVal.Text = a;
                    tbMaxVal.Text = b;
                }
            }
            else Const.ESound();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Running)
            {
                Const.ESound();
                return;
            }
            table.Clear();
        }

        public void InvokeUpdateControls(Action action)
        {
            // Controlla che un thread non abbia accesso a una risorsa di cui non è il creatore

            if (InvokeRequired)
                Invoke(new UpdateControlsDelegate(action));
            else
                action();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            if (Running)
            {
                Const.ESound();
                return;
            }

            if (table.Full == false)
            {
                Const.ESound();
                Const.ShowMsg("L'esecuzione di questa funzione richiede che\ntutte le celle della tabella siano compilate");
            }
            else if (table.ControlStart() == false)
            {
                Const.ESound();
                Const.ShowMsg("Controllare dati ultima riga e ultima colonna");
            }
            else
            {
                Running = true;
                table.ReadOnly(true);
                Buffer = Tuple.Create(table.RowsCount, table.ColumnsCount, table.GetData());
                string method = methods.SelectedItem.ToString();
                InvokeUpdateControls(() => ORS.Execute(method, table, this));
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
                Const.ShowMsg("A causa di un errore i tuoi dati sono stati persi :(");
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
                Const.ESound();
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
