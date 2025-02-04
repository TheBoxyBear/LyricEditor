using System;
using System.Windows.Forms;

namespace LyricEditor
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(args.Length > 0 ? new frmEditor(args[0]) : new frmEditor());
        }
    }
}
