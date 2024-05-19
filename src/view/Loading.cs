using System;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TransportOptimizer.src.utils;

namespace TransportOptimizer.src.view
{
    public partial class Loading : Form
    {
        private delegate void CloseDelegate();
        readonly System.Windows.Forms.Timer timer;

        public Loading()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = Const.MS_INTERVAL;
            progressBar.Width = 0;
        }

        public void InvokeControls(Action action)
        {
            if (InvokeRequired)
                Invoke(new CloseDelegate(action));
            else
                action();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            Run(delay: Const.MS_INTERVAL);
        }

        private void Run(int delay)
        {
            timer.Tick += delegate
            {
                InvokeControls(() => progressBar.Width += 3);

                if (progressBar.Width == 981)
                {
                    Thread.Sleep(delay);
                    timer.Stop();
                    InvokeControls(Hide);

                    try
                    {
                        new Main().ShowDialog();

                    }
                    catch (ThreadStateException e)
                    {
                        Console.WriteLine(e);
                    }

                    InvokeControls(Close);
                }
            };

            timer.Start();
        }
    }
}
