using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportOptimizer.src.model;
using TransportOptimizer.src.utils;

namespace TransportOptimizer.src.algorithm
{
    /// <summary>
    /// Least Cost Method
    /// </summary>
    internal class LeastCost
    {
        public static bool Run(ref DGVData table, ref List<SummaryData> list)
        {
            var obj = new SummaryData();

            if (table.RowsCount > 0 || table.ColumnsCount > 0)
            {
                if (table.RowsCount > 1 || table.ColumnsCount > 1)
                {
                    bool remove_column = false;
                    var minCell = table.GetMin();
                    int val_r = table.GetAt(minCell.RowIndex, table.ColumnsCount);
                    int val_c = table.GetAt(table.RowsCount, minCell.ColumnIndex);

                    if (val_c < val_r)
                    {
                        obj.Quantity = val_c;
                        obj.Price = obj.Quantity * minCell.Value;
                        remove_column = true;
                        table.SetAt(minCell.RowIndex, table.ColumnsCount, val_r - val_c);
                        table.SetLastXY(table.YLineSummary(table.ColumnsCount));
                    }
                    else
                    {
                        obj.Quantity = val_r;
                        obj.Price = obj.Quantity * minCell.Value;
                        table.SetAt(table.RowsCount, minCell.ColumnIndex, val_c - val_r);
                        table.SetLastXY(table.XLineSummary(table.RowsCount));
                    }

                    obj.FromTo = table.GetHeaderRowAt(minCell.RowIndex) + " - " + table.GetHeaderColumnAt(minCell.ColumnIndex);

                    if (remove_column) 
                       table.RemoveColumnAt(minCell.ColumnIndex);
                    else 
                        table.RemoveRowAt(minCell.RowIndex);

                    obj.ID = (list.Count + 1).ToString();
                    list.Add(obj);
                }

                if (table.RowsCount == 1 && table.ColumnsCount == 1)
                {
                    obj = new SummaryData();
                    obj.Quantity = table.GetAt(0, 1);
                    obj.Price = obj.Quantity * table.GetAt(0, 0);
                    obj.FromTo = table.GetHeaderRowAt(0) + " - " + table.GetHeaderColumnAt(0);
                    obj.ID = (list.Count + 1).ToString();

                    list.Add(obj);

                    var sum = new SummaryData
                    (
                        Const.ATTR_TOTAL_NAME, 
                        SummaryData.SumOf(list.ToArray(), Const.ATTR_QNT_NAME), 
                        null, 
                        SummaryData.SumOf(list.ToArray(), Const.ATTR_PRICE_NAME)
                    );
                    
                    list.Add(sum);

                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
