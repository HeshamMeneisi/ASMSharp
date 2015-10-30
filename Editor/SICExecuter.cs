using ASMSharp.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ASMSharp
{
    internal class SICExecuter : Executer
    {
        protected string[] DefOutDev = new string[] { "DEV04", "DEV05", "DEV06" };
        protected string[] DefReq = new string[] { "DEV00", "DEVF1", "DEVF3", "Rename.bat", "SICXEASM.exe", "SICSIM.exe" };
        protected Process simproc = null;
        protected Process current = null;
        protected bool terminated = true;
        protected LisFile lastlis = null;

        public event EventHandler<OutputLineEventArgs> OutputLine;
        public event EventHandler<OutputErrorEventArgs> OutputError;
        public event EventHandler Finished;

        LisFile LastLisfile { get { return lastlis; } }
        public bool IsRunning { get { return !terminated; } } // Accurate for now

        public void Start(string code, Form owner, params object[] other)
        {
            terminated = false;
            PrepareEnvironment(code);
            /////////////////////////////////////////        
            Task assemble = Assemble(owner);
            Task script = RunPostAsmScript();
            Task sim = RunSim();
            Task finished = new Task(() => OnFinished());
            OnOutputLine("> Started...");
            TaskManager.Start("Assembling...", assemble, true);
            TaskManager.Start("Post assembly...", script, true);
            TaskManager.Start("Executing...", sim, true);
            TaskManager.Start("Terminating...", finished, true);
        }

        protected Task RunSim()
        {
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
                {
                    string pr = GlobalSymbols.Resolve(l);
                    if (pr == null || pr == "") continue;
                    p.StandardInput.WriteLine(pr);
                }
                while (!p.HasExited)
                {
                    string l = p.StandardOutput.ReadLine();
                    OnOutputLine(l);
                }
                // If stdout was not flushed in the proc
                string ol = null;
                while ((ol = p.StandardOutput.ReadLine()) != null)
                    OnOutputLine(ol);
            });
            return sim;
        }

        protected Task RunPostAsmScript()
        {
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
                    OnOutputLine(l);
                }
                // If stdout was not flushed in the proc
                string ol = null;
                while ((ol = p.StandardOutput.ReadLine()) != null)
                    OnOutputLine(ol);
            });
            return script;
        }

        protected Task Assemble(Form owner)
        {
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
                foreach (string l in Settings.Default.ASMInput.Replace("\r", "").Split('\n'))
                {
                    string pr = GlobalSymbols.Resolve(l);
                    if (pr == null || pr == "") continue;
                    p.StandardInput.WriteLine(pr);
                }
                while (!p.HasExited)
                {
                    string l = p.StandardOutput.ReadLine();
                    OnOutputLine(l);
                }
                // If stdout was not flushed in the proc
                string ol = null;
                while ((ol = p.StandardOutput.ReadLine()) != null)
                    OnOutputLine(ol);
                // For Default Sim
                if (File.Exists("LISFILE"))
                {
                    var sr = File.OpenText("LISFILE");
                    string content = sr.ReadToEnd();
                    sr.Close();
                    lastlis = new LisFile(content);
                    foreach (int l in lastlis.Errors.Keys)
                        OnOutputError(l, lastlis.Errors[l].ToArray());
                    owner.Invoke(new MethodInvoker(() =>
                    {
                        if (lastlis.Errors.Count > 0 && MessageBox.Show(owner, "Errors found. Continue anyway?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                        {
                            terminated = true;
                            if (!p.HasExited)
                                p.Kill();
                        }
                    }));
                }
            });
            return assemble;
        }

        protected void PrepareEnvironment(string code)
        {
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
            foreach(string od in DefOutDev)
            if (File.Exists(od)) try { File.Delete(od); } catch { }
        }

        public void Input(string line)
        {
            if (simproc != null && !simproc.HasExited)
                simproc.StandardInput.WriteLine(line);
        }
        public void Input(char b)
        {
            if (simproc != null && !simproc.HasExited)
                simproc.StandardInput.Write(b);
        }
        public void Terminate()
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
                foreach (string od in DefOutDev)
                {
                    if (File.Exists(od))
                    {
                        OnOutputLine("> Reading " + od);
                        foreach (string line in File.ReadAllText(od).Split('\n'))
                            OnOutputLine(line);
                    }
                }
            }
        }

        public void OnOutputLine(string line)
        {
            if (OutputLine != null) OutputLine(this, new OutputLineEventArgs(line));
        }

        public void OnOutputError(int line, string[] errors)
        {
            if (OutputError != null) OutputError(this, new OutputErrorEventArgs(line, errors));
        }

        public void OnFinished()
        {
            simproc = null;
            if (Finished != null) Finished(this, null);
        }
    }
}