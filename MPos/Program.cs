using System;
using System.Windows.Forms;

namespace MPos
{
    static class Program
    {
        internal const string UpdateCheckUrl = "https://mpos.sourceforge.io/update.xml";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
