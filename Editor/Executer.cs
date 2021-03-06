﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASMSharp
{
    interface Executer
    {
        event EventHandler<OutputLineEventArgs> OutputLine;
        event EventHandler<OutputErrorEventArgs> OutputError;
        event EventHandler Finished;
        bool IsRunning { get; }
        void Start(string code, System.Windows.Forms.Form owner, params object[] other);
        void Terminate();
        void Input(char b);
        void Input(string line);
        void OnOutputLine(string line);
        void OnOutputError(int line, string[] errors);
        void OnFinished();
    }

    public class OutputErrorEventArgs : EventArgs
    {
        int linenum;
        string[] errors;
        
        public OutputErrorEventArgs(int linenum,string[] errors)
        {
            this.linenum = linenum;
            this.errors = errors;
        }
        public string[] Errors
        {
            get
            {
                return errors;
            }

            set
            {
                errors = value;
            }
        }

        public int LineNum
        {
            get
            {
                return linenum;
            }

            set
            {
                linenum = value;
            }
        }
    }

    public class OutputLineEventArgs : EventArgs
    {
        string line;
        public OutputLineEventArgs(string line)
        {
            this.line = line;
        }

        public string Line
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
