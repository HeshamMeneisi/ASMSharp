using ASMSharp.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASMSharp
{
    internal class CodeFormatter
    {
        static int[] ColCellLengthArr
        {
            get { return Settings.Default.ColCellCountArray.Split(',').Select(t => int.Parse(t)).ToArray(); }
        }
        internal static IEnumerable<string> Format(string[] lines)
        {
            foreach (string line in lines)
            {
                yield return new string(FormatLine(line).ToArray());
            }
        }
        internal static IEnumerable<char> FormatLine(string line)
        {
            int[] ls = ColCellLengthArr; int gi = 0;
            foreach (int l in ls)
            {
                int i = 0;
                // If the line has no more text, finish formatting
                if (gi >= line.Length) goto Finish;
                char current = line[gi];
                bool isstring = false;
                // Output all valid characters if any
                while (isstring || (i < l && current != ' ' && current != '\t'))
                {
                    if (current == '\'' || current == '\"') isstring = !isstring;
                    yield return current;
                    gi++; i++;
                    if (gi < line.Length)
                        current = line[gi];
                    else break;
                }
                // Fill with spaces if necessary
                for (; i < l; i++)
                    yield return ' ';
                // Skip everything up to next statement
                while (gi < line.Length && ((current = line[gi]) == ' ' || current == '\t'))
                    gi++;
            }
            // Handle comments if any
            if (gi < line.Length)
                yield return '\t';
            while (gi < line.Length)
                yield return line[gi++];
            Finish:;
        }
    }
}