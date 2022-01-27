using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._5__Zber_peňazí
{
    public class ZberPenazi
    {
        public string Nazov { get; set; }
        public string DátumUkoncenia { get; set; }
        public long SumaNaVyzbieranie { get; set; }
        public string[] MenaZiakov {get; set;}
        public double KolkoKazdyZaplati { get; set; }

        /// <summary>
        /// Konstruktor pre triedu ZberPenati
        /// </summary>
        /// <param name="nazov">názov zberania</param>
        /// <param name="datum">dokedy treba vyzbierat</param>
        /// <param name="suma">suma ktoru treba vyzbierat</param>
        public ZberPenazi(string nazov, string datum, long suma)
        {
            Nazov = nazov;
            DátumUkoncenia = datum;
            SumaNaVyzbieranie = suma;
            MenaZiakov = (App.Current as App).Menažiakov;
        }
    }
}
