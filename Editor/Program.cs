using System;
using System.Diagnostics;
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
                string sep = "\r\n\r\n####################\r\n\r\n";
                string data = ex.Message + sep + ex.StackTrace;
                StreamWriter sw = new StreamWriter("ASLog.txt");
                sw.WriteLine(data);
                sw.Close();
                MessageBox.Show("The program encountered a problem and has to stop.\nERROR:" + ex.Message + "\nFor more information refer to the ASLog.txt file.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process p = new Process();
                p.StartInfo.FileName = "explorer.exe";
                p.StartInfo.Arguments = Path.Combine(Environment.CurrentDirectory, "ASLog.txt");
                p.Start();
            }
        }
    }
}
