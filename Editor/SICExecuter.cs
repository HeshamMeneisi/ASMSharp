using ASMSharp.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ASMSharp
{
    internal class SICExecuter : Executer
    {
        string[] DefReq = new string[] { "DEV00", "DEVF1", "DEVF3", "Rename.bat", "SICXEASM.exe", "SICSIM.exe" };
        Process simproc = null;
        Process current = null;
        bool terminated = true;

        public override bool IsRunning { get { return !terminated; } } // Accurate for now

        public override void Start(string code, Form owner, params object[] other)
        {
            terminated = false;
            // This is for the default sim
            foreach (string s in DefReq)
            {
                if (!File.Exists(s))
                {
                    var str = File.Create(s);
                    var t = typeof(Resources);
                    var data = (byte[])Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(s), Resources.Culture);
                    str.Write(data, 0, data.Length);
                    str.Close();
                }
            }
            StreamWriter sw = new StreamWriter("SRCFILE");
            sw.Write(code);
            sw.Close();
            /////////////////////////////////////////        
            Task assemble = new Task(() =>
            {
                Process p = new Process();
                p.StartInfo.FileName = Settings.Default.ASMExe;
                p.StartInfo.Arguments = Settings.Default.ASMArgs;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                if (terminated) return;
                current = p;
                p.Start();
                // Check every 100ms
                while (!p.HasExited)
                {
                    string l = p.StandardOutput.ReadLine();
                    if (OutputLine != null)
                        OutputLine(l);
                }
                // If stdout was not flushed in the proc
                string ol = null;
                while ((ol = p.StandardOutput.ReadLine()) != null)
                    if (OutputLine != null)
                        OutputLine(ol);
                // For Default Sim
                if (File.Exists("LISFILE"))
                {
                    var sr = File.OpenText("LISFILE");
                    bool flag = false; int c = -1; // Header is 2 lines
                    string content = sr.ReadToEnd();
                    sr.Close();
                    foreach (string line in content.Split('\n'))
                    {
                        var matches = Regex.Matches(line, "[*]{4}.+");
                        foreach (Match m in matches)
                            if (OutputError != null)
                                OutputError(c, m.Value);
                        if (matches.Count > 0)
                            flag = true;
                        else if (line.Length > 1 && line[1] != ' ')
                            c++;
                    }
                    owner.Invoke(new MethodInvoker(() =>
                    {
                        if (flag && MessageBox.Show(owner, "Errors found. Continue anyway?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                        {
                            terminated = true;
                            if (!p.HasExited)
                                p.Kill();
                        }
                    }));
                }
            });
            Task script = new Task(() =>
            {
                Process p = new Process();
                p.StartInfo.FileName = Settings.Default.ASMScript;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                if (terminated) return;
                current = p;
                p.Start();
                while (!p.HasExited)
                {
                    string l = p.StandardOutput.ReadLine();
                    if (OutputLine != null)
                        OutputLine(l);
                }
                // If stdout was not flushed in the proc
                string ol = null;
                while ((ol = p.StandardOutput.ReadLine()) != null)
                    if (OutputLine != null)
                        OutputLine(ol);
            });
            Task sim = new Task(() =>
            {
                Process p = new Process();
                p.StartInfo.FileName = Settings.Default.SIMExe;
                p.StartInfo.Arguments = Settings.Default.SIMArgs;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.EnableRaisingEvents = true;
                p.StartInfo.CreateNoWindow = true;
                if (terminated) return;
                simproc = current = p;
                p.Start();
                foreach (string l in Settings.Default.SIMInput.Replace("\r", "").Split('\n'))
                    p.StandardInput.WriteLine(l);
                while (!p.HasExited)
                {
                    string l = p.StandardOutput.ReadLine();
                    if (OutputLine != null)
                        OutputLine(l);
                }
                // If stdout was not flushed in the proc
                string ol = null;
                while ((ol = p.StandardOutput.ReadLine()) != null)
                    if (OutputLine != null)
                        OutputLine(ol);
            });
            Task finished = new Task(() =>
             {
                 simproc = null;
                 Finished(DateTime.Now);
             });
            OutputLine("> Started...");
            TaskManager.Start("Assembling...", assemble, true);
            TaskManager.Start("Post assembly...", script, true);
            TaskManager.Start("Executing...", sim, true);
            TaskManager.Start("Terminating...", finished, true);
        }

        public override void Input(string line)
        {
            if (simproc != null && !simproc.HasExited)
                simproc.StandardInput.WriteLine(line);
        }
        public override void Input(char b)
        {
            if (simproc != null && !simproc.HasExited)
                simproc.StandardInput.Write(b);
        }
        public override void Terminate()
        {
            terminated = true;
            if (current != null && !current.HasExited)
            {
                terminated = true;
                Input("q");
                Thread.Sleep(100); // 100ms timeout for quitting
                if (!current.HasExited)
                    current.Kill();
                current = null;
            }
        }
    }
}