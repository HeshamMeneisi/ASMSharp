using ASMSharp.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASMSharp
{
    class SICDebugger : SICExecuter, Debugger
    {
        public event EventHandler<BreakPointReachedEventArgs> BreakPointReached;

        public void OnBreakPointReached(int line, int address)
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new Exception("SICSIM does NOT support pausing.");
        }

        public void Resume()
        {
            Input("r");
        }
        int[] bkpts = null;
        void Debugger.Start(string code, Form owner, params object[] other)
        {
            if (other.Length == 0) base.Start(code, owner);
            bkpts = other[0] as int[];
            if (bkpts == null) throw new Exception("Arg0 is expected to be int[] (Breakpoints).\nFound: " + other[0].GetType());
            this.owner = owner;
            terminated = false;
            PrepareEnvironment(code);
            /////////////////////////////////////////        
            Task assemble = Assemble();
            Task script = RunPostAsmScript();
            Task sim = RunSim();
            Task finished = new Task(() => OnFinished());
            OnOutputLine("> Started...");
            TaskManager.Start("Assembling...", assemble, true);
            TaskManager.Start("Post assembly...", script, true);
            TaskManager.Start("Debugging...", sim, true);
            TaskManager.Start("Terminating...", finished, true);
        }
        new protected Task RunSim()
        {
            Task sim = new Task(() =>
            {
                if (!File.Exists(Settings.Default.ASMExe))
                {
                    terminated = true;
                    owner.Invoke(new MethodInvoker(() =>
                    {
                        MessageBox.Show(owner, "Simulator was not found. Terminating.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
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
                    if (l == "%brkpts%")
                    {
                        foreach (int b in bkpts)
                            if (b < lastlis.LineData.Count)
                                Input("b " + lastlis.LineData[b].Addr);
                    }
                    else
                        p.StandardInput.WriteLine(GlobalSymbols.Resolve(l));
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
    }
}
