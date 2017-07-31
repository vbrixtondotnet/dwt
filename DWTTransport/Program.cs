using System;
using System.Windows.Forms;

namespace DWTTransport
{
    static class Program
    {
        public const string NAME = "GRABATUS";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}
