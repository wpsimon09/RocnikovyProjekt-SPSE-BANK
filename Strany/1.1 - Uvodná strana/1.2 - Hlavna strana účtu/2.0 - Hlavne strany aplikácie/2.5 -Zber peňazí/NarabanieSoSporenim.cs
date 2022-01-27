using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._5__Zber_peňazí;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._5__Zber_peňazí
{
    public class NarabanieSoSporenim
    {
        /// <summary>
        /// Vytvorí nové zberanie peňazí
        /// </summary>
        /// <param name="Listzberanie">List do ktorého sa má nahrat najčastejsie globálna premenná</param>
        /// <param name="nazov">Názov zberania</param>
        /// <param name="datum">Dokedy sa ma vyzbierat</param>
        /// <param name="suma">Kolko sa má vyzbierat</param>
        /// <returns></returns>
        public List<ZberPenazi> NahranieSporeniaDoListu(List<ZberPenazi> Listzberanie,string nazov, string datum, long suma)
        {
            Listzberanie.Add(new ZberPenazi(nazov, datum, suma));
            return Listzberanie;
        }
    }
}
