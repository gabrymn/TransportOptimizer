using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportOptimizer.src.model;
using TransportOptimizer.src.utils;

namespace TransportOptimizer.src.algo
{
    /// <summary>
    /// Northwest Corner Method
    /// </summary>
    internal static class NorthwestCorner
    {
        public static bool Run(ref List<SummaryData> list, ref Table table)
        {
            SummaryData obj = new SummaryData();

            if (table.RowsCount > 0 || table.ColumnsCount > 0)
            {
                if (table.RowsCount > 1 || table.ColumnsCount > 1)
                {
                    bool removeColumn = false;
                    int rv = table.GetAt(table.RowsCount, 0);
                    int cv = table.GetAt(0, table.ColumnsCount);

                    if (cv > rv)
                    {
                        obj.Quantity = rv;
                        obj.Price = obj.Quantity * table.GetAt(0, 0);
                        removeColumn = true;
                        table.SetAt(0, table.ColumnsCount, cv - rv);
                        table.SetLastXY(table.YLineSummary(table.ColumnsCount));
                    }
                    else
                    {
                        obj.Quantity = cv;
                        obj.Price = obj.Quantity * table.GetAt(0, 0);
                        table.SetAt(table.RowsCount, 0, rv - cv);
                        table.SetLastXY(table.XLineSummary(table.RowsCount));
                    }
                    obj.FromTo = table.GetHeaderRowAt(0) + " - " + table.GetHeaderColumnAt(0);

                    if (removeColumn) table.RemoveColumnAt(0);
                    else table.RemoveRowAt(0);

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
                    SummaryData sum = new SummaryData(Const.ATTR_TOTAL_NAME, SummaryData.Sum(list.ToArray(), Const.ATTR_QNT_NAME), null, SummaryData.Sum(list.ToArray(), Const.ATTR_PRICE_NAME));
                    list.Add(sum);
                    table.VisibleStatus(false);

                    return false;
                }

                return true;
            }
            return false;
        }
    }
}
