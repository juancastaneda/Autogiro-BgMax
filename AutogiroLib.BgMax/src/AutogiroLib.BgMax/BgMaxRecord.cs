namespace AutogiroLib.BgMax
{
    using System.Collections.Generic;
    using System.Linq;

    public class BgMaxRecord
    {
        private readonly BgMaxAvsnitt[] avsnitt;

        public BgMaxRecord(params BgMaxAvsnitt[] avsnitt)
        {
            this.avsnitt = avsnitt.ToArray();
        }

        public IEnumerable<BgMaxAvsnitt> Avsnitt
        {
            get
            {
                return avsnitt.Skip(0);
            }
        }
    }
}