﻿using System;
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
            //string s = "The program received: " + args.Length + " arguments.\n";
            //foreach (object ar in args) s += ar.GetType() + ": " + ar.ToString();
#if !DEBUG
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += unhadledex;
            Application.ThreadException += threadex;
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
            string data = "Want to help? Kindly email this file to heshammeneisi@gmail.com along with some details of what operation caused the error.\n Further more, you can check the code yourself on github.com/HeshamMeneisi/ASMSharp\n" + sep + type + sep + ex.Message + sep + ex.StackTrace;
            StreamWriter sw = new StreamWriter("ASLog.txt");
            sw.WriteLine(data);
            sw.Close();
            DialogResult res = MessageBox.Show("The program encountered a problem and has to restart.\nYou should find your last running code in \"" + Environment.CurrentDirectory + "\\SRCFILE\"\nERROR:" + ex.Message + "\nFor more information refer to the ASLog.txt file.\nRestart application?", "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            Process p = new Process();
            p.StartInfo.FileName = "explorer.exe";
            p.StartInfo.Arguments = Path.Combine(Environment.CurrentDirectory, "ASLog.txt");
            p.Start();
            if (res == DialogResult.Yes)
                Application.Restart();
        }
    }
}
