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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="newline"></param>
        /// <returns>Line has changed.</returns>
        internal static bool FormatLine(string line, out string newline)
        {
            int[] ls = ColCellLengthArr; int gi = 0, al = Math.Min(line.Length,ColCellLengthArr.Sum());
            newline = "";
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
                    newline += current;
                    gi++; i++;
                    if (gi < line.Length)
                        current = line[gi];
                    else break;
                }
                // Fill with spaces if necessary
                for (; i < l; i++)
                    newline += ' ';
                // Skip everything up to next statement
                while (gi < al && ((current = line[gi]) == ' ' || current == '\t'))
                    gi++;
            }
            // Handle comments if any

            if (gi < line.Length)
                newline += line.Substring(gi);
            Finish:            
            return newline.Length != line.Length || newline != line;
        }
    }
}