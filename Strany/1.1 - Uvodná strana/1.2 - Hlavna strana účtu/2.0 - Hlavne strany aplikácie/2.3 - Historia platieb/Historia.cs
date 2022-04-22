using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ročňíkový_projekt___Aplikácia_pre_banku.Assets.Data;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._3___Historia_platieb
{
    public class Historia
    {
        public double Prijmy { get; set; }
        public double Vydavky { get; set; } 

        public List<Prijmy> prijmy { get; set; }
        public List<Vydavky> vydavky { get; set; }

        public Historia()
        {
            prijmy = new List<Prijmy>();
            vydavky = new List<Vydavky>();

            Prijmy = 0;
            Vydavky = 0;
        }



    }
}
