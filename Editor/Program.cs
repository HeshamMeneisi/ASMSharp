using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
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
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += unhadledex;
            Application.ThreadException += threadex;
#if !DEBUG
            try
            {
#endif
                Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mainFrm(args));
#if !DEBUG
        }
            catch (Exception ex)
            {
                HandleFailure("Regular Exception", ex);
            }
#endif
        }

        private static void threadex(object sender, ThreadExceptionEventArgs e)
        {
            HandleFailure("Unhandled UI Exception", e.Exception);
        }

        private static void unhadledex(object sender, UnhandledExceptionEventArgs e)
        {
            HandleFailure("Unhadled Exception", (Exception)e.ExceptionObject);
        }

        private static void HandleFailure(string type, Exception ex)
        {
#if DEBUG
            throw (ex);
#endif
            string sep = "\r\n\r\n####################\r\n\r\n";
            string data = type + sep + ex.Message + sep + ex.StackTrace;
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
