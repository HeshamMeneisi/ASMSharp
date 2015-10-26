using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASMSharp
{
    interface Debugger
    {
        event EventHandler<OutputLineEventArgs> OutputLine;
        event EventHandler<OutputErrorEventArgs> OutputError;
        event EventHandler Finished;
        event EventHandler<BreakPointReachedEventArgs> BreakPointReached;
        bool IsRunning { get; }
        void Start(string code, System.Windows.Forms.Form owner, params object[] other);
        void Terminate();
        void Input(char b);
        void Input(string line);
        void Pause();
        void Resume();
        void OnOutputLine(string line);
        void OnOutputError(int line, string[] errors);
        void OnFinished();
        void OnBreakPointReached(int line, int address);
    }

    public class BreakPointReachedEventArgs : EventArgs
    {
        int line, address;
        public BreakPointReachedEventArgs(int line,int address)
        {
            this.line = line;
            this.address = address;
        }

        public int Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public int Line
        {
            get
            {
                return line;
            }

            set
            {
                line = value;
            }
        }
    }
}
