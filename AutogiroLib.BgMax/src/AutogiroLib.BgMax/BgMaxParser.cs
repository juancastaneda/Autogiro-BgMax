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

            this.lines = lines;
        }

        public BgMaxRecord ParseBgMaxContents()
        {
            var avsnitt = new List<BgMaxAvsnitt>();
            var betallningar = new List<Betalningspost>();
            foreach (var line in lines)
            {
                if (line.StartsWith("15"))
                {
                    avsnitt.Add(new BgMaxAvsnitt(betallningar.ToArray()));
                }

                if (line.StartsWith("20"))
                {
                    betallningar.Add(new Betalningspost());
                }
            }

            return new BgMaxRecord(avsnitt.ToArray());
        }
    }
}