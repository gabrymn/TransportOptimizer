using System.Data;
using TransportOptimizer.src.utils;

namespace TransportOptimizer.src.model
{
    public class DGVData
    {
        public struct Cell
        {
            public int Value;
            public int RowIndex;
            public int ColumnIndex;
        }

        private int rowsCount, columnsCount;
        private readonly DataGridView dgv;
        private readonly static Random rd = new Random();

        public int RowsCount { get => rowsCount; }
        public int ColumnsCount { get => columnsCount; }
        public int CellsCount { get => rowsCount * columnsCount; }

        public void Clear() => FillWith(string.Empty);

        public DGVData(int rowsCount, int columnsCount, DataGridView dgv)
        {
            this.rowsCount = rowsCount;
            this.columnsCount = columnsCount;
            this.dgv = dgv;
        }

        public string GetHeaderRowAt(int index)
        {
            return (string)dgv.Rows[index].HeaderCell.Value;
        }

        public string GetHeaderColumnAt(int index)
        {
            return dgv.Columns[index].HeaderText;
        }

        public bool RemoveRowAt(int index)
        {
            try
            {
                bool state = false;

                if (index < rowsCount)
                {
                    dgv.Rows.RemoveAt(index);
                    state = true;
                    rowsCount--;
                }
                return state;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool RemoveColumnAt(int index)
        {
            try
            {
                bool state = false;

                if (index < columnsCount)
                {
                    dgv.Columns.RemoveAt(index);
                    state = true;
                    columnsCount--;
                    //SetBackground();
                }
                return state;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static void AddRows(DataGridView dgv, int n)
        {
            for (int i = 0; i < n; i++)
                dgv.Rows.Add(new DataGridViewRow());
        }

        /// <summary>
        /// returns the min value of the table and its <X,Y> coordinates from the current data
        /// </summary>
        public Cell GetMin()
        {
            try
            {
                Cell min;
                min.Value = Convert.ToInt32(dgv.Rows[0].Cells[0].Value);
                min.RowIndex = 0;
                min.ColumnIndex = 0;

                for (int i = 0; i < rowsCount; i++)
                    for (int j = 0; j < columnsCount; j++)
                        if (Convert.ToInt32(dgv.Rows[i].Cells[j].Value) < min.Value)
                        {
                            min.Value = Convert.ToInt32(dgv.Rows[i].Cells[j].Value);
                            min.RowIndex = i;
                            min.ColumnIndex = j;
                        }

                return min;
            }
            catch (Exception e) { Console.WriteLine(e); return default; }
        }

        /// <summary>
        /// returns the min value of the table and its <X,Y> coordinates from the table passed as argument
        /// </summary>
        public static Cell GetMin(int[,] m)
        {
            try
            {
                Cell min;
                min.Value = m[0, 0];
                min.RowIndex = 0;
                min.ColumnIndex = 0;

                for (int i = 0; i < m.GetLength(0); i++)
                    for (int j = 0; j < m.GetLength(1); j++)
                        if (m[i, j] < min.Value)
                        {
                            min.Value = m[i, j];
                            min.RowIndex = i;
                            min.ColumnIndex = j;
                        }

                return min;
            }
            catch (Exception e) { Console.WriteLine(e); return default; }
        }

        public void Randomize(int min, int max)
        {
            int multiplier = 0;

            try
            {
                // Fill the table with random values that belong to the range [min, max]
                dgv.Rows.Cast<DataGridViewRow>().ToList().ForEach(r =>
                {
                    r.Cells.Cast<DataGridViewCell>().ToList().ForEach(c =>
                    {
                        c.Value = rd.Next(min, max + 1);
                    });
                });

                // Fill the bottom row with 0
                for (int i = 0; i < columnsCount; i++)
                    dgv.Rows[rowsCount].Cells[i].Value = 0;

                // Fill the last right column with 0
                for (int i = 0; i < rowsCount; i++)
                    dgv.Rows[i].Cells[columnsCount].Value = 0;

                // gen of total_val
                if (Math.Max(RowsCount, ColumnsCount) >= 10)
                    multiplier = 10;
                else
                    multiplier = 1;

                int total_val = 0;
                total_val += Math.Max(RowsCount, ColumnsCount) * 100;
                total_val += rd.Next(1, 10) * (10 * multiplier);

                int[] last_row = new int[ColumnsCount];
                int[] last_column = new int[RowsCount];

                last_row.Randomize(total_val);
                last_column.Randomize(total_val);

                for (int i = 0; i < last_column.Length; i++)
                    SetAt(i, ColumnsCount, last_column[i]);

                for (int i = 0; i < last_row.Length; i++)
                    SetAt(rowsCount, i, last_row[i]);

                SetLastXY(total_val);
            }
            catch (ArgumentOutOfRangeException e) { Console.WriteLine(e); }
        }

        /// <summary>
        /// Validates the cell value inserted in the DataGridView.
        /// </summary>
        /// <remarks>
        /// This method checks if the cell value is a valid integer, 
        /// is not less than 1, and does not start with a zero. 
        /// If any of these conditions are not met, it clears the cell value 
        /// and plays an error sound. If the cell value has leading or 
        /// trailing whitespace, it trims the value before saving it back.
        /// </remarks>
        public void CheckCellValueInserted()
        {
            try
            {
                string c = dgv.CurrentCell.Value.ToString();

                if ((c != string.Empty && c.IsInteger() == false) || c.LessThan1() || c.StartsWith("0"))
                {
                    System.Media.SystemSounds.Hand.Play();
                    dgv.CurrentCell.Value = string.Empty;
                }
                else
                {
                    if (c.StartsWith(" ") || c.EndsWith(" "))
                        dgv.CurrentCell.Value = c.Trim();
                }

            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        private void FillWith<T>(T value)
        {
            try
            {
                dgv.Rows.Cast<DataGridViewRow>().ToList().ForEach(row =>
                    row.Cells.Cast<DataGridViewCell>().ToList().ForEach(cell =>
                        cell.Value = value
                    )
                );
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public int GetAt(int indexRow, int indexColumn)
        {
            try
            {
                var value = dgv[indexColumn, indexRow].Value.ToString();
                bool ret = int.TryParse(value, out _);

                return ret ? int.Parse(value) : -1;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.ToString());
                return default;
            }
        }

        public void SetAt(int indexRow, int indexColumn, int value)
        {
            try
            {
                dgv[indexColumn, indexRow].Value = value;
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

        public int XLineSummary(int index)
        {
            try
            {
                int x1 = 0;
                int x2 = GetLastXY();

                for (int i = 0; i < dgv.Columns.Count; i++)
                    x1 += Convert.ToInt32(dgv.Rows[index].Cells[i].Value);

                return x1 - x2;
            }
            catch (Exception e) { Console.WriteLine(e); return -1; }
        }

        public int XLineMax(int rowIndex)
        {
            int tmax = Convert.ToInt32(dgv.Rows[rowIndex].Cells[0].Value);

            for (int i = 1; i < dgv.Columns.Count - 1; i++)
            {
                int v = Convert.ToInt32(dgv.Rows[rowIndex].Cells[i].Value);
                if (v > tmax) tmax = v;
            }

            return tmax;
        }

        public int XLineMin(int rowIndex)
        {
            int tmin = Convert.ToInt32(dgv.Rows[rowIndex].Cells[0].Value);

            for (int i = 1; i < dgv.Columns.Count - 1; i++)
            {
                int v = Convert.ToInt32(dgv.Rows[rowIndex].Cells[i].Value);

                if (v < tmin)
                    tmin = v;
            }

            return tmin;
        }

        public int YLineMax(int columnIndex)
        {
            int tmax = Convert.ToInt32(dgv.Rows[0].Cells[columnIndex].Value);

            for (int i = 1; i < dgv.Rows.Count - 1; i++)
            {
                int v = Convert.ToInt32(dgv.Rows[i].Cells[columnIndex].Value);

                if (v > tmax)
                    tmax = v;
            }

            return tmax;
        }

        public int YLineMin(int columnIndex)
        {
            int tmin = Convert.ToInt32(dgv.Rows[0].Cells[columnIndex].Value);

            for (int i = 1; i < dgv.Rows.Count - 1; i++)
            {
                int v = Convert.ToInt32(dgv.Rows[i].Cells[columnIndex].Value);

                if (v < tmin)
                    tmin = v;
            }
            return tmin;
        }

        public int XLineIndexOf(int rowIndex, int value)
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                int v = Convert.ToInt32(dgv.Rows[rowIndex].Cells[i].Value);

                if (v == value)
                    return i;
            }

            return -1;
        }

        public int YLineIndexOf(int columnIndex, int value)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                int v = Convert.ToInt32(dgv.Rows[i].Cells[columnIndex].Value);

                if (v == value)
                    return i;
            }

            return -1;
        }

        public int YLineSummary(int columnIndex)
        {
            try
            {
                int y1 = 0;
                int y2 = GetLastXY();

                for (int i = 0; i < dgv.Rows.Count; i++)
                    y1 += Convert.ToInt32(dgv.Rows[i].Cells[columnIndex].Value);

                return y1 - y2;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        public int[,] GetData()
        {
            try
            {
                int[,] m = new int[rowsCount + 1, columnsCount + 1];

                for (int i = 0; i <= rowsCount; i++)
                    for (int j = 0; j <= columnsCount; j++)
                        m[i, j] = Convert.ToInt32(dgv.Rows[i].Cells[j].Value);

                return m;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default;
            }
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

        public bool IsFull()
        {
            try
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                    for (int j = 0; j < dgv.Columns.Count; j++)
                        if (dgv.Rows[i].Cells[j].Value.ToString().Length == 0)
                            return false;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DataIsConsistent()
        {
            bool eq1 = XLineSummary(rowsCount) == YLineSummary(columnsCount);
            bool eq2 = YLineSummary(columnsCount) == GetLastXY();

            return eq1 && eq2;
        }

        /// <summary>
        /// Calculate the absolute difference between the two mins of a specific row or column
        /// </summary>
        public int DeltaMin(bool row, int target_index)
        {
            int temp;

            if (row)
            {
                // Get first min of the row [target_index]

                int min1_index = 0;
                int min1_value;

                for (int i = 1; i < ColumnsCount; i++)
                {
                    temp = Convert.ToInt32(dgv.Rows[target_index].Cells[i].Value);
                    min1_value = Convert.ToInt32(dgv.Rows[target_index].Cells[min1_index].Value);

                    if (temp < min1_value)
                        min1_index = i;
                }

                // Get second min of the row [target_index]

                int min2_index = min1_index == 0 ? 1 : 0;
                int min2_value;

                for (int i = 0; i < ColumnsCount; i++)
                {
                    temp = Convert.ToInt32(dgv.Rows[target_index].Cells[i].Value);
                    min2_value = Convert.ToInt32(dgv.Rows[target_index].Cells[min2_index].Value);

                    if (temp < min2_value && i != min1_index)
                        min2_index = i;
                }

                return Math.Abs(
                    Convert.ToInt32(dgv.Rows[target_index].Cells[min1_index].Value)
                    -
                    Convert.ToInt32(dgv.Rows[target_index].Cells[min2_index].Value)
                );
            }

            else
            {
                // Get first min of the column [target_index]

                int min1_index = 0;
                int min1_value;

                for (int i = 1; i < RowsCount; i++)
                {
                    temp = Convert.ToInt32(dgv.Rows[i].Cells[target_index].Value);
                    min1_value = Convert.ToInt32(dgv.Rows[min1_index].Cells[target_index].Value);

                    if (temp < min1_value)
                        min1_index = i;
                }

                // Get second min of the column [target_index]

                int min2_index = min1_index == 0 ? 1 : 0;
                int min2_value;

                for (int i = 0; i < RowsCount; i++)
                {
                    temp = Convert.ToInt32(dgv.Rows[i].Cells[target_index].Value);
                    min2_value = Convert.ToInt32(dgv.Rows[min2_index].Cells[target_index].Value);

                    if (temp < min2_value && i != min1_index)
                        min2_index = i;
                }

                return Math.Abs(
                    Convert.ToInt32(dgv.Rows[min1_index].Cells[target_index].Value)
                    -
                    Convert.ToInt32(dgv.Rows[min2_index].Cells[target_index].Value)
                );
            }
        }
    }
}
