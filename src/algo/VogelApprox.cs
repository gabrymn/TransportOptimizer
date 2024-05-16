using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportOptimizer.src.model;
using TransportOptimizer.src.utils;

namespace TransportOptimizer.src.algo
{
    internal class VogelApprox
    {
        public static bool Run(ref List<SummaryData> list, ref Table table)
        {
            SummaryData obj = new SummaryData();

            if (table.RowsCount > 0 || table.ColumnsCount > 0)
            {
                if (table.RowsCount > 1 || table.ColumnsCount > 1)
                {
                    int[] xline = new int[table.ColumnsCount]; // ORIZZONTALE
                    int[] yline = new int[table.RowsCount];    // VERTICALE

                    for (int i = 0; i < table.RowsCount; i++)
                        yline[i] = table.DeltaM("ROW", i);

                    for (int i = 0; i < table.ColumnsCount; i++)
                        xline[i] = table.DeltaM("COLUMN", i);

                    int maxR = xline[0];
                    for (int i = 1; i < xline.Length; i++)
                        if (xline[i] > maxR)
                            maxR = xline[i];

                    int maxC = yline[0];
                    for (int i = 1; i < yline.Length; i++)
                        if (yline[i] > maxC)
                            maxC = yline[i];

                    int r = -1, c = -1, q = 0;
                    if (maxC > maxR)
                    {
                        var tlist = Utils.CountVal(yline, maxC);
                        int mindex = tlist[0];
                        if (tlist.Count > 1)
                        {
                            mindex = table.XLineMin(tlist[0]);
                            for (int i = 1; i < tlist.Count; i++)
                            {
                                var t = table.XLineMin(tlist[i]);
                                if (t < mindex) { mindex = t; q = i; }
                            }
                            r = tlist[q];
                            c = table.XLineIndex(r, mindex);
                        }
                        r = tlist[0];
                        c = table.XLineIndex(r, table.XLineMin(r));
                    }
                    else
                    {
                        var tlist = Utils.CountVal(xline, maxR);
                        int mindex = tlist[0];
                        if (tlist.Count > 1)
                        {
                            mindex = table.YLineMin(tlist[0]);
                            for (int i = 1; i < tlist.Count; i++)
                            {
                                var t = table.YLineMin(tlist[i]);
                                if (t < mindex) { mindex = t; q = i; }
                            }
                            r = tlist[q];
                            c = table.YLineIndex(r, mindex);
                        }
                        c = tlist[0];
                        r = table.YLineIndex(c, table.YLineMin(c));
                    }

                    int val_r = table.GetAt(r, table.ColumnsCount);
                    int val_c = table.GetAt(table.RowsCount, c);
                    bool removeColumn = false;

                    if (val_c < val_r)
                    {
                        obj.Quantity = val_c;
                        obj.Price = obj.Quantity * table.GetAt(r, c);
                        removeColumn = true;
                        table.SetAt(r, table.ColumnsCount, val_r - val_c);
                        table.SetLastXY(table.YLineSummary(table.ColumnsCount));
                    }
                    else
                    {
                        obj.Quantity = val_r;
                        obj.Price = obj.Quantity * table.GetAt(r, c);
                        table.SetAt(table.RowsCount, c, val_c - val_r);
                        table.SetLastXY(table.XLineSummary(table.RowsCount));
                    }

                    obj.FromTo = table.GetHeaderRowAt(r) + " - " + table.GetHeaderColumnAt(c);
                    if (removeColumn) table.RemoveColumnAt(c);
                    else table.RemoveRowAt(r);
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
