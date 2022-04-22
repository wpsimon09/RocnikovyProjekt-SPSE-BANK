using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._4___Sporenie;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Assets.Data
{
    public class Vydavky
    {
        public string Vydavok { get; set; }

        public  Vydavky(PlatobnySystem vydavky, int index = 0)
        {
            if (index == 0)
            {
                Vydavok = $"{vydavky.DatumSplatnosti} - {vydavky.PlatenaSuma} pre {vydavky.MenoPrijemcu} z triedneho fondu";
            }
            else if (index == 1)
            {
                Vydavok = $"{vydavky.DatumSplatnosti} - {vydavky.PlatenaSuma} pre {vydavky.MenoPrijemcu} zo sporiaceho účtu";
            }
            else
                Vydavok = "Chyba";

            (App.Current as App).GlobalHistoria.Prijmy += vydavky.InkasovanaSuma;

        }

    }
}
