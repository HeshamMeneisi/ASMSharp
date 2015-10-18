using System;
using System.IO;
using System.Windows.Forms;

namespace ASMSharp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mainFrm(args));
            }catch (Exception ex)
            {
                string sep = "\n\n####################\\n\n";
                string data = ex.Message + sep + ex.InnerException + sep + ex.StackTrace;
                StreamWriter sw = new StreamWriter("ASLog.txt");
                sw.WriteLine(data);
                sw.Close();
            }
        }
    }
}
