using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransportOptimizer.src.model;
using TransportOptimizer.src.utils;
using TransportOptimizer.src.view;

namespace TransportOptimizer.src.algo
{
    /// <summary>
    /// Russell's Approximation Method (RAM)
    /// </summary>
    internal static class RussellApprox
    {
        public static bool Run(ref List<SummaryData> list, ref Table table)
        {
            SummaryData obj = new SummaryData();

            int[,] vm;
            int[] maxrs, maxcs;

            if (table.RowsCount > 0 || table.ColumnsCount > 0)
            {
                if (table.RowsCount > 1 || table.ColumnsCount > 1)
                {
                    vm = new int[table.RowsCount, table.ColumnsCount];

                    maxrs = new int[table.RowsCount];
                    maxcs = new int[table.ColumnsCount];

                    for (int i = 0; i < table.RowsCount; i++) 
                        maxrs[i] = table.XLineMax(i);

                    for (int i = 0; i < table.ColumnsCount; i++) 
                        maxcs[i] = table.YLineMax(i);

                    for (int i = 0; i < vm.GetLength(0); i++) 
                        for (int j = 0; j < vm.GetLength(1); j++) 
                            vm[i, j] = table.GetAt(i, j) - maxcs[j];

                    for (int i = 0; i < vm.GetLength(1); i++) 
                        for (int j = 0; j < vm.GetLength(0); j++) 
                            vm[j, i] -= maxrs[j];

                    var min = Table.GetMin(vm);
                    int val_r = table.GetAt(min.R, table.ColumnsCount);
                    int val_c = table.GetAt(table.RowsCount, min.C);

                    bool remove_column = false;

                    if (val_c < val_r)
                    {
                        obj.Quantity = val_c;
                        obj.Price = obj.Quantity * table.GetAt(min.R, min.C);
                        remove_column = true;
                        table.SetAt(min.R, table.ColumnsCount, val_r - val_c);
                        table.SetLastXY(table.YLineSummary(table.ColumnsCount));
                    }
                    else
                    {
                        obj.Quantity = val_r;
                        obj.Price = obj.Quantity * table.GetAt(min.R, min.C);
                        table.SetAt(table.RowsCount, min.C, val_c - val_r);
                        table.SetLastXY(table.XLineSummary(table.RowsCount));
                    }

                    obj.FromTo = table.GetHeaderRowAt(min.R) + " - " + table.GetHeaderColumnAt(min.C);

                    if (remove_column) 
                        table.RemoveColumnAt(min.C);
                    else 
                        table.RemoveRowAt(min.R);
                    
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
                        SummaryData.Sum(list.ToArray(), Const.ATTR_QNT_NAME), 
                        null, 
                        SummaryData.Sum(list.ToArray(), Const.ATTR_PRICE_NAME)
                    );

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
