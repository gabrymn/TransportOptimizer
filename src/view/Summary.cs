using System.ComponentModel;
using TransportOptimizer.src.model;
using TransportOptimizer.src.utils;
using TransportOptimizer.src.view.components;

namespace TransportOptimizer.src.view
{
    public partial class Summary : Form
    {
        private readonly SummaryData[] output_data;
        private readonly string method;
        private SaveFileDialog sfd;
        private Main mainform;

        public Summary(SummaryData[] output_data, string method, Main mainform, float elapsed, int iterations)
        {
            InitializeComponent();
            
            this.method = method;
            this.mainform = mainform;
            this.output_data = output_data;

            InitSaveFileDialog();
            InitDGVFormatAndStyle();

            this.Text += " (" + elapsed.ToString() + " seconds; ";
            this.Text += iterations.ToString() + " iterations)";
        }

        private void InitDGVFormatAndStyle()
        {
            dgv1.AddRows(output_data.Length);

            dgv1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(column => {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            });

            dgv1.Rows[dgv1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.GreenYellow;
            dgv1.Rows[dgv1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
            dgv1.Rows[dgv1.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.Black;
            dgv1.Rows[dgv1.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.GreenYellow;
            dgv1.BorderStyle = BorderStyle.None;

            dgv1.Font = new Font(Const.CELLS_FONT_NAME, Const.CELLS_FONT_SIZE, Const.FONT_STYLE_STD);
        }

        private void InitSaveFileDialog()
        {
            sfd = new SaveFileDialog();
            sfd.Filter = Const.OUTPUT_FILE_EXT_FILTER;
            sfd.DefaultExt = Const.OUTPUT_FILE_EXT;
            sfd.AddExtension = true;
            sfd.FileName = method + "_" + DateTime.UtcNow.GetHashCode().ToString().Replace("-", "");
            sfd.FileOk += CheckIfFileHasCorrectExtension;
        }

        void CheckIfFileHasCorrectExtension(object sender, CancelEventArgs e)
        {
            SaveFileDialog sfd = (sender as SaveFileDialog);

            if (Path.GetExtension(sfd.FileName).ToLower() != ("." + Const.OUTPUT_FILE_EXT))
            {
                e.Cancel = true;
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show(Const.WRONG_EXT_ERROR_MSG);
                return;
            }
        }

        private void Final_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv1.Rows.Count; i++) 
                dgv1.Rows[i].Height += 15;

            LoadData();
            dgv1.FirstDisplayedScrollingRowIndex = dgv1.RowCount - 1;
        }

        private void LoadData()
        {
            int i;

            for (i = 0; i < output_data.Length; i++)
            {
                dgv1.Rows[i].Cells[0].Value = output_data[i].ID;
                dgv1.Rows[i].Cells[1].Value = output_data[i].Quantity;
                dgv1.Rows[i].Cells[2].Value = output_data[i].FromTo;
                dgv1.Rows[i].Cells[3].Value = output_data[i].PriceToString();
            }
        }

        private void exit0_Click(object sender, EventArgs e)
        {
            mainform.ResetDataGridView();
            Close();
        }

        private void save0_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SummaryData.ToJsonFile(output_data, sfd.FileName);

                mainform.ResetDataGridView();
                Close();
            }
        }

        private void Summary_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainform.ResetDataGridView();
        }
    }
}
