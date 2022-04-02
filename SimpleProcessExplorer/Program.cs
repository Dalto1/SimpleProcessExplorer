using System;
using System.Windows.Forms;

namespace ProcessExplorer
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 2 && args[0] == "-k")
                Tools.KillProcess(args[1]);
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ProcessExplorer());
            }
        }
    }
}
