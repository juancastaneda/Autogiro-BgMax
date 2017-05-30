namespace AutogiroLib.BgMax
{
    using System.Collections.Generic;
    using System;
    using System.Collections;

    /// <summary>
    /// Parser for a source of lines on
    /// BgMax format
    /// </summary>
    public class BgMaxParser
    {
        private readonly IEnumerable<string> lines;

        public BgMaxParser(IEnumerable<string> lines)
        {
            if (lines == null)
            {
                throw new ArgumentNullException(nameof(lines));
            }
        }

        public BgMaxRecord ParseBgMaxContents()
        {
            return new BgMaxRecord();
        }
    }
}