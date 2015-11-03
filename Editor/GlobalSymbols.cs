using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ASMSharp
{
    static class GlobalSymbols
    {
        static Dictionary<string, string> Retriever = new Dictionary<string, string>
        {
            {"%brkpts%", "" }
        };

        internal static string Resolve(string l)
        {
            foreach (Match m in Regex.Matches(l, "%.+%"))
                if (Retriever.ContainsKey(m.Value))
                    l = l.Replace(m.Value, Retriever[m.Value]);
            return l;
        }
    }
}
