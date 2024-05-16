using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportOptimizer.src.model;

namespace TransportOptimizer.src.algo
{
    internal class LeastCost
    {
        public static bool Run(ref List<SummaryData> list, ref Table table)
        {
            SummaryData obj = new SummaryData();

            if (table.RowsCount > 0 || table.ColumnsCount > 0)
            {
                if (table.RowsCount > 1 || table.ColumnsCount > 1)
                {
                    bool removeColumn = false;
                    var m = table.Min;
                    int val_r = table.GetAt(m.R, table.ColumnsCount);
                    int val_c = table.GetAt(table.RowsCount, m.C);

                    if (val_c < val_r)
                    {
                        obj.Quantity = val_c;
                        obj.Price = obj.Quantity * m.Value;
                        removeColumn = true;
                        table.SetAt(m.R, table.ColumnsCount, val_r - val_c);
                        table.SetLastXY(table.YLineSummary(table.ColumnsCount));
                    }
                    else
                    {
                        obj.Quantity = val_r;
                        obj.Price = obj.Quantity * m.Value;
                        table.SetAt(table.RowsCount, m.C, val_c - val_r);
                        table.SetLastXY(table.XLineSummary(table.RowsCount));
                    }

                    obj.FromTo = table.GetHeaderRowAt(m.R) + " - " + table.GetHeaderColumnAt(m.C);

                    if (removeColumn) table.RemoveColumnAt(m.C);
                    else table.RemoveRowAt(m.R);

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
                    SummaryData sum = new SummaryData("TOTALE", SummaryData.Sum(list.ToArray(), "quantity"), null, SummaryData.Sum(list.ToArray(), "price"));
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
