using System;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using TransportOptimizer.src.model;
using TransportOptimizer.src.utils;

namespace TransportOptimizer.src.view
{
    public partial class Summary : Form
    {
        private readonly SummaryData[] array;
        private readonly string method;
        public Table table;
        private SaveFileDialog sfd;
        private Main mainform;

        public Summary(SummaryData[] array, string method, Table table, Main mainform, float elapsed)
        {
            InitializeComponent();
            this.table = table;
            this.method = method;
            this.mainform = mainform;
            SetSFD();
            this.array = array;
            Table.AddRows(dgv1, array.Length);
            dgv1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(column => { column.SortMode = DataGridViewColumnSortMode.NotSortable; });
            dgv1.Rows[dgv1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Aqua;
            dgv1.Rows[dgv1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
            dgv1.Rows[dgv1.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.Black;
            dgv1.Rows[dgv1.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.Aqua;
            dgv1.BorderStyle = BorderStyle.None;
            dgv1.Font = new Font(Const.FONT.Cells, Const.FONT.CellsSize, Const.FONT.StdForm);
            this.Text += " (" + elapsed.ToString() + " secondi)";
        }

        private void SetSFD()
        {
            sfd = new SaveFileDialog();
            sfd.Filter = "JSON file|*.json";
            sfd.DefaultExt = "json";
            sfd.AddExtension = true;
            sfd.FileName = method + "_" + DateTime.UtcNow.GetHashCode().ToString().Replace("-", "");
            sfd.FileOk += CheckIfFileHasCorrectExtension;
        }

        void CheckIfFileHasCorrectExtension(object sender, CancelEventArgs e)
        {
            SaveFileDialog sfd = (sender as SaveFileDialog);
            if (Path.GetExtension(sfd.FileName).ToLower() != ".json")
            {
                e.Cancel = true;
                Const.ESound();
                Const.ShowMsg("Ammessi solo file JSON, omettere l'estensione per continuare");
                return;
            }
        }

        private void Final_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv1.Rows.Count; i++) dgv1.Rows[i].Height += 15;
            LoadData();
            dgv1.FirstDisplayedScrollingRowIndex = dgv1.RowCount - 1;
        }

        private void LoadData()
        {
            int i;
            for (i = 0; i < array.Length; i++)
            {
                dgv1.Rows[i].Cells[0].Value = array[i].ID;
                dgv1.Rows[i].Cells[1].Value = array[i].Quantity;
                dgv1.Rows[i].Cells[2].Value = array[i].FromTo;
                dgv1.Rows[i].Cells[3].Value = SummaryData.PriceFormat(array[i].Price);
            }
        }

        private void exit0_Click(object sender, EventArgs e)
        {
            mainform.CallReset();
            Close();
        }

        private void save0_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SummaryData.SaveArrayToJSON(path: sfd.FileName, array: array);
                mainform.CallReset();
                Close();
            }
        }

        private void Summary_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainform.CallReset();
        }
    }
}
