using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransportOptimizer.src.algo;
using TransportOptimizer.src.model;
using TransportOptimizer.src.utils;
using TransportOptimizer.src.view;

namespace TransportOptimizer.src.middleware
{
    internal class Method
    {
        public static bool Run(string? method, Table table, Main mainform)
        {
            if (method == null || Const.METHODS.Contains(method) == false)
                method = Const.FASTER_METHOD;

            var data = new List<SummaryData>();
            
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = Const.MS_INTERVAL;

            // used to measure the method time is seconds
            var stopWatch = new System.Diagnostics.Stopwatch();

            // true = keep going
            // false = method process is over
            bool method_status = true;

            timer.Tick += delegate
            {
                if (method == Const.METHODS[0]) 
                    method_status = NorthwestCorner.Run(ref data, ref table);

                else if (method == Const.METHODS[1])
                    method_status = LeastCost.Run(ref data, ref table);

                else if (method == Const.METHODS[2])
                    method_status = VogelApprox.Run(ref data, ref table);

                else
                    method_status = RussellApprox.Run(ref data, ref table);

                if (method_status == false)
                {
                    timer.Stop();
                    stopWatch.Stop();
                    var elapsed = stopWatch.ElapsedMilliseconds / 1000.00f;
                    new Summary(data.ToArray(), method.ToLower(), table, mainform, elapsed).ShowDialog();
                }
            };

            timer.Start();
            stopWatch.Start();

            return true;
        }
    }
}
