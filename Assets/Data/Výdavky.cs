using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Assets.Data
{
    public class Výdavky
    {
        public string Vydavok { get; set; }

        Výdavky(IPlatobnySystem vydavky)
        {
            Vydavok = $"{vydavky.PlatenaSuma} pre {vydavky.MenoPrijemcu} z triedneho fondu";
        }
    }
}
