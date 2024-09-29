using TransportOptimizer.src.algorithm;
using TransportOptimizer.src.model;
using TransportOptimizer.src.utils;
using TransportOptimizer.src.view;

namespace TransportOptimizer.src.middleware
{
    /// <summary>
    /// This class provides a framework for executing various methods on a DataGridView, specifically 
    /// for processing data related to `DGVData`. It allows for the selection and invocation of 
    /// algorithms to manipulate or analyze data in the `DataGridView`. Tthe results are collected 
    /// and displayed in a summary dialog once processing is complete. 
    /// </summary>
    abstract class MethodExecutor
    {
        public delegate bool Runnable(ref DGVData input_data, ref List<SummaryData> output_data);

        public static bool Run(string? method_name, DGVData input_data, DataGridView dgv, Main mainform)
        {
            if (method_name == null || Const.METHODS.Contains(method_name) == false)
                method_name = Const.METHODS[0];

            List<SummaryData> output_data = new List<SummaryData>();

            // Form timer, its used to run the method every X milliseconds
            var UIT = new System.Windows.Forms.Timer();
            UIT.Interval = Const.MS_INTERVAL;

            // used to measure the method process time is seconds
            var timer = new System.Diagnostics.Stopwatch();

            // method_status = true => keep going
            // method_status = false => method process is over
            bool method_status = true;

            // Method iterations
            int iterations = 0;

            // this var "contains" the chosen method and can be called like a function
            Runnable method = GetMethod(method_name);

            UIT.Tick += delegate
            {
                iterations++;

                method_status = method(ref input_data, ref output_data);

                if (method_status == false)
                {
                    UIT.Stop();
                    timer.Stop();

                    var elapsed = timer.ElapsedMilliseconds / 1000.00f;

                    dgv.Visible = false;

                    new Summary(output_data.ToArray(), method_name.ToLower(), mainform, elapsed, iterations).ShowDialog();
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
