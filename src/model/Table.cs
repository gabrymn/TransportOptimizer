using System;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using TransportOptimizer.src.utils;

namespace TransportOptimizer.src.model
{
    public sealed class Table
    {
        private int rowsCount, columnsCount;
        private readonly DataGridView view;
        private readonly static Random rd = new Random();

        public int RowsCount { get => rowsCount; }
        public int ColumnsCount { get => columnsCount; }
        public int CellsCount { get => rowsCount * columnsCount; }
        public bool Full { get => IsFull(); }
        public void Clear() => Iterate(string.Empty);
        public int RealHeight { get { int s = 0; view.Rows.Cast<DataGridViewRow>().ToList().ForEach(row => s += row.Height); s += view.ColumnHeadersHeight; return s; } }
        public int RealWidth { get { int s = 0; view.Columns.Cast<DataGridViewColumn>().ToList().ForEach(column => s += column.Width); s += view.ColumnHeadersHeight; return s; } }
        public DataGridView View { get => view; }
        public Cell Min { get => GetMin(); }

        public struct Cell
        {
            public int Value;
            public int R;
            public int C;
        }

        public Table(int rowsCount, int columnsCount, DataGridView view, bool enable = false)
        {
            this.rowsCount = rowsCount;
            this.columnsCount = columnsCount;
            this.view = view;
            view.Font = new Font(Const.FONT.Cells, Const.FONT.CellsSize, Const.FONT.StdForm);
            if (enable) Enable();
        }

        public Table(int rowsCount, int columnsCount, DataGridView view, int[,] data, bool enable = false)
        {
            this.rowsCount = rowsCount;
            this.columnsCount = columnsCount;
            this.view = view;
            view.Font = new Font(Const.FONT.Cells, Const.FONT.CellsSize, Const.FONT.StdForm);
            if (enable) Enable();
            SetData(data);
        }

        public void Enable()
        {
            SetDataGridViewProperties();
            SetVisualElements();
            //setStdData();
        }

        public void setStdData()
        {
            int[,] m = new int[,]
            {
                { 10, 12, 80, 30, 50, 200 },
                { 15, 30, 40, 45, 60, 150 },
                { 20, 35, 30, 20, 50, 160 },
                { 100, 120, 90, 50, 150, 510 }
            };

            for (int i = 0; i < rowsCount + 1; i++)
                for (int j = 0; j < columnsCount + 1; j++)
                    SetAt(i, j, m[i, j]);
        }

        public bool RemoveRowAt(int index)
        {
            try
            {
                bool state = false;
                if (index < rowsCount)
                {
                    view.Rows.RemoveAt(index);
                    state = true;
                    rowsCount--;
                    //SetBackground();
                }
                return state;
            }
            catch (Exception e) { Console.WriteLine(e); return false; }

        }

        public void RemoveLastColumn()
        {
            try { view.Columns.RemoveAt(--columnsCount); } catch (ArgumentOutOfRangeException e) { Console.WriteLine(e); }
        }

        public void RemoveLastRow()
        {
            try { view.Rows.RemoveAt(--rowsCount); } catch (ArgumentOutOfRangeException e) { Console.WriteLine(e); }
        }

        public bool RemoveColumnAt(int index)
        {
            try
            {
                bool state = false;
                if (index < columnsCount)
                {
                    view.Columns.RemoveAt(index);
                    state = true;
                    columnsCount--;
                    //SetBackground();
                }
                return state;
            }
            catch (Exception e) { Console.WriteLine(e); return false; }
        }

        private void SetBackground()
        {
            view.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => { r.Cells[columnsCount].Style.ForeColor = Color.Aqua; });
            view.Rows[rowsCount].Cells.Cast<DataGridViewCell>().ToList().ForEach(c => { c.Style.ForeColor = Color.Aqua; });
        }

        private void SetVisualElements()
        {
            SetStructTable();
            SetHeaders("UP", "D", "TOTALI");
            Iterate(value: string.Empty);
            SetBackground();
            SetSize(140, 60);
            //view.BorderStyle = BorderStyle.None;
        }

        private void SetSize(int widthCells, int heightCells)
        {
            try
            {
                view.ColumnHeadersHeight = heightCells;
                for (int i = 0; i <= rowsCount; i++)
                    view.Rows[i].Height = heightCells;

                view.RowHeadersWidth = widthCells;
                for (int i = 0; i <= columnsCount; i++)
                    view.Columns[i].Width = widthCells;
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        private void SetDataGridViewProperties()
        {
            view.AllowUserToResizeRows = false;
            view.AllowUserToResizeColumns = false;
            view.AllowUserToAddRows = false;
            view.AllowUserToDeleteRows = false;
        }

        private void SetHeaders(string keyRow, string keyColumn, string keyLast)
        {
            view.Rows.Cast<DataGridViewRow>().ToList().ForEach(row => row.HeaderCell.Value = keyRow + (row.Index + 1));
            view.Columns.Cast<DataGridViewColumn>().ToList().ForEach(column => { column.HeaderText = keyColumn + (column.Index + 1); column.SortMode = DataGridViewColumnSortMode.NotSortable; column.HeaderCell.Style.BackColor = Color.FromArgb(15, 16, 18); });

            view.Rows[rowsCount].HeaderCell.Value = keyLast;
            view.Rows[rowsCount].HeaderCell.Style.ForeColor = Color.Aqua;
            view.Rows[rowsCount].HeaderCell.Style.Font = new Font(Const.FONT.Cells, Const.FONT.CellsSize, Const.FONT.LastForm);

            view.Columns[columnsCount].HeaderText = keyLast;
            view.Columns[columnsCount].HeaderCell.Style.ForeColor = Color.Aqua;
            view.Columns[columnsCount].HeaderCell.Style.Font = new Font(Const.FONT.Cells, Const.FONT.CellsSize, Const.FONT.LastForm);

            view.Rows[rowsCount].HeaderCell.Style.BackColor = Color.Black;
            view.Columns[columnsCount].HeaderCell.Style.BackColor = Color.Black;
        }

        private void SetStructTable()
        {
            try
            {
                DataTable dt = new DataTable();
                for (int i = 0; i <= columnsCount; i++)
                    dt.Columns.Add(new DataColumn());
                for (int i = 0; i <= rowsCount; i++)
                    dt.Rows.Add(dt.NewRow());
                DataView dv = new DataView(dt);
                view.DataSource = null;
                view.DataSource = dv;

            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void Randomize(int min, int max)
        {
            try
            {

                max++;
                view.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Cells.Cast<DataGridViewCell>().ToList().ForEach(c => c.Value = rd.Next(min, max)));
                for (int i = 0; i < columnsCount; i++) view.Rows[rowsCount].Cells[i].Value = 0;
                for (int i = 0; i < rowsCount; i++) view.Rows[i].Cells[columnsCount].Value = 0;

                int x = Math.Max(RowsCount, ColumnsCount) > 9 ? 10 : 1;
                GenerateTotalsRand(new int[ColumnsCount], new int[RowsCount], Math.Max(RowsCount, ColumnsCount) * 100 + (rd.Next(1, 10) * (10 * x)));

            }
            catch (ArgumentOutOfRangeException e) { Console.WriteLine(e); }
        }

        public void ControlCurrentCellValue()
        {
            try
            {
                string t = view.CurrentCell.Value.ToString();

                if ((t != string.Empty && !Utils.IsN(t)) || Utils.LessT1(t) || t.StartsWith("0"))
                {
                    Const.ESound();
                    view.CurrentCell.Value = string.Empty;
                }
                else
                if (t.StartsWith(" ") || t.EndsWith(" "))
                    view.CurrentCell.Value = t.Trim();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        private void Iterate<T>(T value)
        {
            try
            {
                view.Rows.Cast<DataGridViewRow>().ToList().ForEach(row => row.Cells.Cast<DataGridViewCell>().ToList().ForEach(cell => cell.Value = value));
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public int GetAt(int indexRow, int indexColumn)
        {
            try
            {
                var value = view[indexColumn, indexRow].Value.ToString();
                bool ret = int.TryParse(value, out _);

                return ret ? int.Parse(value) : -1;
            }
            catch (IndexOutOfRangeException e) { Console.WriteLine(e.ToString()); return default; }
        }

        public void SetAt(int indexRow, int indexColumn, int value)
        {
            try
            {
                view[indexColumn, indexRow].Value = value;
            }
            catch (ArgumentOutOfRangeException e) { Console.WriteLine(e); }
        }

        public int GetLastXY()
        {
            return GetAt(rowsCount, ColumnsCount);
        }

        public void SetLastXY(int value)
        {
            SetAt(rowsCount, ColumnsCount, value);
        }

        public string GetHeaderRowAt(int index)
        {
            return (string)view.Rows[index].HeaderCell.Value;
        }

        public string GetHeaderColumnAt(int index)
        {
            return view.Columns[index].HeaderText;
        }

        private void GenerateTotalsRand(int[] lastRowLine, int[] lastColumnLine, int value)
        {
            try
            {
                local(lastRowLine, value);
                local(lastColumnLine, value);

                for (int i = 0; i < lastColumnLine.Length; i++)
                    SetAt(i, ColumnsCount, lastColumnLine[i]);

                for (int i = 0; i < lastRowLine.Length; i++)
                    SetAt(rowsCount, i, lastRowLine[i]);

                SetLastXY(value);

                void local(int[] array, int last)
                {

                    int med = last / array.Length;
                    int[] m = Enumerable.Repeat(med, array.Length).ToArray();

                    while (m.Sum() < last) m[m.Length - 1]++;

                    int k = -1;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (i == (array.Length - 1))
                        {
                            array[i] = 0;
                            array[i] = last - array.Sum();
                        }
                        else
                        {
                            if (i % 2 == 0)
                            {
                                k = rd.Next((int)(0.30 * m[i]), (int)((0.70 * m[i]) + 1));
                                array[i] = m[i] + k;
                            }
                            else
                                array[i] = m[i] - k;
                        }
                    }

                    Const.Shuffle(array);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public int XLineSummary(int index)
        {
            try
            {
                int x1 = 0;
                int x2 = GetLastXY();
                for (int i = 0; i < view.Columns.Count; i++)
                    x1 += Convert.ToInt32(view.Rows[index].Cells[i].Value);
                return x1 - x2;
            }
            catch (Exception e) { Console.WriteLine(e); return -1; }
        }

        public int XLineMax(int rowIndex)
        {
            int tmax = Convert.ToInt32(view.Rows[rowIndex].Cells[0].Value);
            for (int i = 1; i < view.Columns.Count - 1; i++)
            {
                int v = Convert.ToInt32(view.Rows[rowIndex].Cells[i].Value);
                if (v > tmax) tmax = v;
            }
            return tmax;
        }

        public int XLineMin(int rowIndex)
        {
            int tmin = Convert.ToInt32(view.Rows[rowIndex].Cells[0].Value);
            for (int i = 1; i < view.Columns.Count - 1; i++)
            {
                int v = Convert.ToInt32(view.Rows[rowIndex].Cells[i].Value);
                if (v < tmin) tmin = v;
            }
            return tmin;
        }

        public int YLineMax(int columnIndex)
        {
            int tmax = Convert.ToInt32(view.Rows[0].Cells[columnIndex].Value);
            for (int i = 1; i < view.Rows.Count - 1; i++)
            {
                int v = Convert.ToInt32(view.Rows[i].Cells[columnIndex].Value);
                if (v > tmax) tmax = v;
            }
            return tmax;
        }

        public int YLineMin(int columnIndex)
        {
            int tmin = Convert.ToInt32(view.Rows[0].Cells[columnIndex].Value);
            for (int i = 1; i < view.Rows.Count - 1; i++)
            {
                int v = Convert.ToInt32(view.Rows[i].Cells[columnIndex].Value);
                if (v < tmin) tmin = v;
            }
            return tmin;
        }

        public int XLineIndex(int rowIndex, int value)
        {
            for (int i = 0; i < view.Columns.Count; i++)
            {
                int v = Convert.ToInt32(view.Rows[rowIndex].Cells[i].Value);
                if (v == value) return i;
            }
            return -1;
        }

        public int YLineIndex(int columnIndex, int value)
        {
            for (int i = 0; i < view.Rows.Count; i++)
            {
                int v = Convert.ToInt32(view.Rows[i].Cells[columnIndex].Value);
                if (v == value) return i;
            }
            return -1;
        }

        public int YLineSummary(int index)
        {
            try
            {
                int y1 = 0;
                int y2 = GetLastXY();
                for (int i = 0; i < view.Rows.Count; i++)
                    y1 += Convert.ToInt32(view.Rows[i].Cells[index].Value);
                return y1 - y2;
            }
            catch (Exception e) { Console.WriteLine(e); return -1; }
        }

        public int[,] GetData()
        {
            try
            {
                int[,] m = new int[rowsCount + 1, columnsCount + 1];
                for (int i = 0; i <= rowsCount; i++)
                    for (int j = 0; j <= columnsCount; j++)
                        m[i, j] = Convert.ToInt32(view.Rows[i].Cells[j].Value);
                return m;
            }
            catch (Exception e) { Console.WriteLine(e); return default; }
        }

        public void SetData(int[,] m)
        {
            try
            {
                for (int i = 0; i <= rowsCount; i++)
                    for (int j = 0; j <= columnsCount; j++)
                        SetAt(i, j, m[i, j]);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public static void AddRows(DataGridView dgv, int n)
        {
            while (n-- > 0) dgv.Rows.Add(new DataGridViewRow());
        }

        public static void AddColumns(DataGridView dgv, int n)
        {
            while (n-- > 0) dgv.Columns.Add(new DataGridViewColumn());
        }

        private bool IsFull()
        {
            try
            {
                for (int i = 0; i < view.Rows.Count; i++)
                    for (int j = 0; j < view.Columns.Count; j++)
                        if (view.Rows[i].Cells[j].Value.ToString().Length == 0) return false;
                return true;
            }
            catch (Exception e) { Console.WriteLine(e); return false; }
        }

        private Cell GetMin()
        {
            try
            {
                Cell min;
                min.Value = Convert.ToInt32(view.Rows[0].Cells[0].Value);
                min.R = 0;
                min.C = 0;

                for (int i = 0; i < rowsCount; i++)
                    for (int j = 0; j < columnsCount; j++)
                        if (Convert.ToInt32(view.Rows[i].Cells[j].Value) < min.Value)
                        {
                            min.Value = Convert.ToInt32(view.Rows[i].Cells[j].Value);
                            min.R = i;
                            min.C = j;
                        }
                return min;
            }
            catch (Exception e) { Console.WriteLine(e); return default; }
        }

        public static Cell GetMin(int[,] m)
        {
            try
            {
                Cell min;
                min.Value = m[0, 0];
                min.R = 0;
                min.C = 0;

                for (int i = 0; i < m.GetLength(0); i++)
                    for (int j = 0; j < m.GetLength(1); j++)
                        if (m[i, j] < min.Value)
                        {
                            min.Value = m[i, j];
                            min.R = i;
                            min.C = j;
                        }
                return min;
            }
            catch (Exception e) { Console.WriteLine(e); return default; }
        }

        public void VisibleStatus(bool status)
        {
            view.Visible = status;
        }

        public bool ControlStart()
        {
            return XLineSummary(rowsCount) == YLineSummary(columnsCount) && YLineSummary(columnsCount) == GetLastXY();
        }

        public int DeltaM(string rc, int index)
        {
            rc = rc.ToLower();

            if (rc == "row")
            {
                int min1 = 0;
                for (int i = 1; i < ColumnsCount; i++)
                {
                    int v = Convert.ToInt32(view.Rows[index].Cells[i].Value);
                    int min1V = Convert.ToInt32(view.Rows[index].Cells[min1].Value);
                    if (v < min1V) min1 = i;
                }
                int min2 = min1 == 0 ? 1 : 0;
                for (int i = 0; i < ColumnsCount; i++)
                {
                    int v = Convert.ToInt32(view.Rows[index].Cells[i].Value);
                    int min2V = Convert.ToInt32(view.Rows[index].Cells[min2].Value);
                    if (v < min2V && i != min1) min2 = i;
                }
                return Math.Abs(
                    Convert.ToInt32(view.Rows[index].Cells[min1].Value)
                    -
                    Convert.ToInt32(view.Rows[index].Cells[min2].Value)
                );
            }

            if (rc == "column")
            {
                int min1 = 0;
                for (int i = 1; i < RowsCount; i++)
                {
                    int v = Convert.ToInt32(view.Rows[i].Cells[index].Value);
                    int min1V = Convert.ToInt32(view.Rows[min1].Cells[index].Value);
                    if (v < min1V) min1 = i;
                }
                int min2 = min1 == 0 ? 1 : 0;
                for (int i = 0; i < RowsCount; i++)
                {
                    int v = Convert.ToInt32(view.Rows[i].Cells[index].Value);
                    int min2V = Convert.ToInt32(view.Rows[min2].Cells[index].Value);
                    if (v < min2V && i != min1) min2 = i;
                }
                return Math.Abs(
                    Convert.ToInt32(view.Rows[min1].Cells[index].Value)
                    -
                    Convert.ToInt32(view.Rows[min2].Cells[index].Value)
                );
            }

            return -1;
        }

        public void ReadOnly(bool status)
        {
            view.ReadOnly = status;
        }
    }
}
