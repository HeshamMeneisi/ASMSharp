using System;
using System.Text.RegularExpressions;

namespace ASMSharp
{
    // TODO: Use this class instead of the current code in CodeBox.FormatCodeBox()
    // The gain in efficiency is not that much but it's much more clean this way
    // Work in progress. This stub is not yet implemented.
    internal class RTFParser
    {
        // RTF Format
        // {
        // \rtf <charset> \deff? <fonttbl> <filetbl>? <colortbl>? <stylesheet>? <listtables>? <revtbl>?
        // text
        // }\r\n
        string defc, fonttbl, colortbl, stylesheet, listtables, revtbl;
        public RTFParser(string rtf)
        {
            throw new NotImplementedException();
            rtf = rtf.Substring(1, rtf.Length - 1); // remove { }            
            for(int i =0;i<rtf.Length;i++)
            {                
            }
        }
    }
}