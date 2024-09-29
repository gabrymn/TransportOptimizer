using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportOptimizer.src.utils;

namespace TransportOptimizer.src.view.components
{
    /// <summary>
    /// Provides extension methods for customizing the appearance and structure of a <see cref="DataGridView"/>.
    /// </summary>
    /// <remarks>
    /// This class allows for setting various visual elements and properties of a <see cref="DataGridView"/>,
    /// such as font styles, cell sizes, and header styles. It includes methods to initialize the grid with
    /// a specified number of rows and columns, apply custom styling, and manage user interactions.
    /// </remarks>
    public static class DGVExtensions
    {
        public static void SetVisualElements(this DataGridView dgv, int rowsCount, int columnsCount)
        {
            dgv.Font = new Font(Const.CELLS_FONT_NAME, Const.CELLS_FONT_SIZE, Const.FONT_STYLE_STD);
            dgv.SetCustomProps();
            dgv.SetStruct(rowsCount, columnsCount);
            dgv.SetHeadersStyle(Const.ATTR_UNIT_PROD, Const.ATTR_DEST, Const.ATTR_TOTAL_NAME);
            dgv.SetBackgroundStyle();
            dgv.SetCellsSize(Const.CELLS_WIDTH, Const.CELLS_HEIGHT);
        }

        private static void SetCustomProps(this DataGridView dgv)
        {
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
        }

        private static void SetStruct(this DataGridView dgv, int rowsCount, int columnsCount)
        {
            try
            {
                DataTable dt = new DataTable();

                for (int i = 0; i <= columnsCount; i++)
                    dt.Columns.Add(new DataColumn());

                for (int i = 0; i <= rowsCount; i++)
                    dt.Rows.Add(dt.NewRow());

                DataView dv = new DataView(dt);
                dgv.DataSource = null;
                dgv.DataSource = dv;

            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        private static void SetBackgroundStyle(this DataGridView dgv)
        {
            dgv.Rows.Cast<DataGridViewRow>().ToList().ForEach(r =>
                { r.Cells[dgv.ColumnCount-1].Style.ForeColor = Color.GreenYellow; }
            );

            dgv.Rows[dgv.RowCount-1].Cells.Cast<DataGridViewCell>().ToList().ForEach(c =>
                { c.Style.ForeColor = Color.GreenYellow; }
            );
        }

        private static void SetCellsSize(this DataGridView dgv, int cellsWidth, int cellsHeight)
        {
            try
            {
                dgv.ColumnHeadersHeight = cellsHeight;

                for (int i = 0; i < dgv.RowCount; i++)
                    dgv.Rows[i].Height = cellsHeight;

                dgv.RowHeadersWidth = cellsWidth;

                for (int i = 0; i < dgv.ColumnCount; i++)
                    dgv.Columns[i].Width = cellsWidth;
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        private static void SetHeadersStyle(this DataGridView dgv, string keyRow, string keyColumn, string keyLast)
        {
            dgv.Rows.Cast<DataGridViewRow>().ToList().ForEach(row =>
                row.HeaderCell.Value = keyRow + (row.Index + 1)
            );

            dgv.Columns.Cast<DataGridViewColumn>().ToList().ForEach(column =>
            {
                column.HeaderText = keyColumn + (column.Index + 1);
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.BackColor = Color.FromArgb(15, 16, 18);
            });

            dgv.Rows[dgv.RowCount-1].HeaderCell.Value = keyLast;
            dgv.Rows[dgv.RowCount-1].HeaderCell.Style.ForeColor = Color.GreenYellow;
            dgv.Rows[dgv.RowCount-1].HeaderCell.Style.Font = new Font(Const.CELLS_FONT_NAME, Const.CELLS_FONT_SIZE, Const.FONT_STYLE_LAST);

            dgv.Columns[dgv.ColumnCount-1].HeaderText = keyLast;
            dgv.Columns[dgv.ColumnCount-1].HeaderCell.Style.ForeColor = Color.GreenYellow;
            dgv.Columns[dgv.ColumnCount-1].HeaderCell.Style.Font = new Font(Const.CELLS_FONT_NAME, Const.CELLS_FONT_SIZE, Const.FONT_STYLE_LAST);

            dgv.Rows[dgv.RowCount-1].HeaderCell.Style.BackColor = Color.Black;
            dgv.Columns[dgv.ColumnCount-1].HeaderCell.Style.BackColor = Color.Black;
        }

        public static void AddRows(this DataGridView dgv, int n)
        {
            for (int i = 0; i < n; i++)
                dgv.Rows.Add(new DataGridViewRow());
        }
    }
}
