﻿using System;
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
        public delegate bool Runnable(ref List<SummaryData> output_data, ref Table table);

        public static bool Run(string? method_name, Table table, Main mainform)
        {
            if (method_name == null || Const.METHODS.Contains(method_name) == false)
                method_name = Const.FASTER_METHOD;

            var output_data = new List<SummaryData>();
            
            // Form timer, its used to run the method every X milliseconds
            var UIT = new System.Windows.Forms.Timer();
            UIT.Interval = Const.MS_INTERVAL;

            // used to measure the method process time is seconds
            var timer = new System.Diagnostics.Stopwatch();

            // true = keep going
            // false = method process is over
            bool method_status = true;

            // Method iterations
            int iterations = 0;

            // this var "contains" the chosen method and can be called like a function
            Runnable method = GetMethod(method_name);

            UIT.Tick += delegate
            {
                iterations++;

                method_status = method(ref output_data, ref table);

                if (method_status == false)
                {
                    UIT.Stop();
                    timer.Stop();
                    var elapsed = timer.ElapsedMilliseconds / 1000.00f;
                    new Summary(output_data.ToArray(), method_name.ToLower(), table, mainform, elapsed, iterations).ShowDialog();
                }
            };

            UIT.Start();
            timer.Start();

            return true;
        }

        private static Runnable GetMethod(string method_name)
        {
            Runnable method;

            if (method_name == Const.METHODS[0])
                method = NorthwestCorner.Run;

            else if (method_name == Const.METHODS[1])
                method = LeastCost.Run;

            else if (method_name == Const.METHODS[2])
                method = VogelApprox.Run;

            else
                method = RussellApprox.Run;

            return method;
        }
    }
}
