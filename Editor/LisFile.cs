using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ASMSharp
{
    class LisFile
    {
        Dictionary<int, Line> linedata = new Dictionary<int, Line>();
        Dictionary<int, List<string>> errors = new Dictionary<int, List<string>>();
        internal Dictionary<int, Line> LineData
        {
            get
            {
                return linedata;
            }
        }

        public Dictionary<int, List<string>> Errors
        {
            get
            {
                return errors;
            }
        }

        public LisFile(string content)
        {
            string addr = ""; List<string> data = new List<string>();
            int cl = 0;
            foreach (string line in content.Split('\n').Skip(2))
            {
                Match m;
                if ((m = Regex.Match(line, "^[0-9A-Za-z]+")).Success) //New line found
                {
                    if (data.Count > 0) linedata[cl++] = new Line(addr, data.ToArray());
                    data.Clear(); addr = m.Value;
                }
                if (line.Contains('*'))
                {
                    if (!errors.ContainsKey(cl))
                        errors[cl] = new List<string>();
                    errors[cl].Add(line.Trim());
                }
                else
                    data.Add(Regex.Match(line, "\\s[0-9A-Za-z]+").Value);
            }
            if (data.Count > 0) linedata[cl++] = new Line(addr, data.ToArray());
        }
    }
    class Line
    {
        string addr;
        string[] data;

        public Line(string addr, string[] data)
        {
            this.addr = addr;
            this.data = data;
        }

        public string Addr
        {
            get
            {
                return addr;
            }

            set
            {
                addr = value;
            }
        }

        public string[] Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }
    }
}
