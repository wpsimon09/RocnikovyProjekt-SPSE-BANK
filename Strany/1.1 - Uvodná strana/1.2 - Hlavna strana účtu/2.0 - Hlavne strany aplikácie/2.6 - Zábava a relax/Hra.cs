using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._6___Zábava_a_relax
{
    public class Hra
    {
        public Thickness Obrazok1 { get; set; }
        public Thickness Obrazok2 { get; set; }
        public Thickness Obrazok3 { get; set; }
        public Thickness Obrazok4 { get; set; }

        double [] x = new double[4];
        double [] y = new double[4];

        Random rand = new Random();

        public void VygenerovanieHodnotPreRozmiestnenie()
        {
            for (int i = 0; i < 4; i++)
            {
                x[i] = rand.Next(0, 532);
                y[i] = rand.Next(0, 376);
            }
            Obrazok1 = new Thickness(x[0], y[0], 0,0);
            Obrazok2 = new Thickness(x[1], y[1], 0, 0);
            Obrazok3 = new Thickness(x[2], y[2],0,0);
            Obrazok4 = new Thickness(x[3], y[3], 0,0);

        }


    }
}
