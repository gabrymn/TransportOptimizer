
namespace RicercaOperativa
{
    static class Program
    {
        [System.STAThread]

        static void Main()
        {
            if (System.Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Loading());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        
        private static extern bool SetProcessDPIAware();
    }
}
