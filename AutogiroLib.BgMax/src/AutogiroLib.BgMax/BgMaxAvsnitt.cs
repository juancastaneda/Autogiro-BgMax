namespace AutogiroLib.BgMax
{
    using System.Collections.Generic;
    using System.Linq;

    public sealed class BgMaxAvsnitt
    {
        private readonly Betalningspost[] betalningsposts;

        public BgMaxAvsnitt(params Betalningspost[] betalningsposts)
        {
            this.betalningsposts = betalningsposts.ToArray();
        }

        public IEnumerable<Betalningspost> Betallningar
        {
            get
            {
                return betalningsposts.Skip(0);
            }
        }
    }
}