using System.Collections.Generic;
using System.Windows.Forms;

using TransportOptimizer.src.utils;
using TransportOptimizer.src.model;


namespace TransportOptimizer
{
    public class Temp
    {
        private static int msTimeout = Const.MedMsTimeout;

        public static int MsTimeout
        {
            get => msTimeout;
            set { msTimeout = value < Const.MinMsTimeout ? Const.MinMsTimeout : value > Const.MaxMsTimeout ? Const.MaxMsTimeout : value; }
        }

        public void ResetTimeout() => msTimeout = Const.MedMsTimeout;

        public static bool Execute(string method, Table table, Main mainform)
        {
            // No switch  case->con variabili  per versione .NET attuale
            if (method == Const.MS[0]) NordOvest(table, mainform);
            else if (method == Const.MS[1]) MinimiCosti(table, mainform);
            else if (method == Const.MS[2]) Vogel(table, mainform);
            else if (method == Const.MS[3]) Russell(table, mainform);
            else return false;

            return true;
        }

        private static void NordOvest(Table table, Main mainform)
        {
            List<SummaryData> data = new List<SummaryData>();
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = MsTimeout;

            var stopWatch = new System.Diagnostics.Stopwatch();
            timer.Tick += delegate
            {
                if (!method(data))
                {
                    timer.Stop();
                    stopWatch.Stop();
                    var elapsed = stopWatch.ElapsedMilliseconds / 1000.00f;
                    new Summary(data.ToArray(), "nord_ovest", table, mainform, elapsed).ShowDialog();
                }
            };
            timer.Start();
            stopWatch.Start();

            bool method(List<SummaryData> list)
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

        private static void Russell(Table table, Main mainform)
        {
            List<SummaryData> data = new List<SummaryData>();
            Timer timer = new Timer();
            timer.Interval = MsTimeout;

            var stopWatch = new System.Diagnostics.Stopwatch();
            timer.Tick += delegate
            {
                if (!method(data))
                {
                    timer.Stop();
                    stopWatch.Stop();
                    var elapsed = stopWatch.ElapsedMilliseconds / 1000.00f;
                    new Summary(data.ToArray(), "russell", table, mainform, elapsed).ShowDialog();
                }
            };
            timer.Start();
            stopWatch.Start();

            bool method(List<SummaryData> list)
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
                        for (int i = 0; i < table.RowsCount; i++) maxrs[i] = table.XLineMax(i);
                        for (int i = 0; i < table.ColumnsCount; i++) maxcs[i] = table.YLineMax(i);
                        for (int i = 0; i < vm.GetLength(0); i++) for (int j = 0; j < vm.GetLength(1); j++) vm[i, j] = table.GetAt(i, j) - maxcs[j];
                        for (int i = 0; i < vm.GetLength(1); i++) for (int j = 0; j < vm.GetLength(0); j++) vm[j, i] -= maxrs[j];
                        var min = Table.GetMin(vm);
                        int val_r = table.GetAt(min.R, table.ColumnsCount);
                        int val_c = table.GetAt(table.RowsCount, min.C);
                        bool removeColumn = false;

                        if (val_c < val_r)
                        {
                            obj.Quantity = val_c;
                            obj.Price = obj.Quantity * table.GetAt(min.R, min.C);
                            removeColumn = true;
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
                        if (removeColumn) table.RemoveColumnAt(min.C);
                        else table.RemoveRowAt(min.R);
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

        private static void Vogel(Table table, Main mainform)
        {
            List<SummaryData> data = new List<SummaryData>();
            Timer timer = new Timer();
            timer.Interval = MsTimeout;

            var stopWatch = new System.Diagnostics.Stopwatch();
            timer.Tick += delegate
            {
                if (!method(data))
                {
                    timer.Stop();
                    stopWatch.Stop();
                    var elapsed = stopWatch.ElapsedMilliseconds / 1000.00f;
                    new Summary(data.ToArray(), "vogel", table, mainform, elapsed).ShowDialog();
                }
            };
            timer.Start();
            stopWatch.Start();

            bool method(List<SummaryData> list)
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
                            var tlist = Const.CountVal(yline, maxC);
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
                            var tlist = Const.CountVal(xline, maxR);
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

        private static void MinimiCosti(Table table, Main mainform)
        {
            List<SummaryData> data = new List<SummaryData>();
            Timer timer = new Timer();
            timer.Interval = MsTimeout;

            var stopWatch = new System.Diagnostics.Stopwatch();
            timer.Tick += delegate
            {
                if (!method(data))
                {
                    timer.Stop();
                    stopWatch.Stop();
                    var elapsed = stopWatch.ElapsedMilliseconds / 1000.0f;
                    new Summary(data.ToArray(), "minimi_costi", table, mainform, elapsed).ShowDialog();
                }
            };
            timer.Start();
            stopWatch.Start();

            bool method(List<SummaryData> list)
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
}

