using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASMSharp
{
    abstract class Executer
    {
        public Action<string> OutputLine;
        public Action<int, string> OutputError;
        public Action<DateTime> Finished;
        public abstract bool IsRunning { get; }
        public abstract void Start(string code, System.Windows.Forms.Form owner, params object[] other);
        public abstract void Terminate();
        public abstract void Input(char b);
        public abstract void Input(string line);
    }
}
