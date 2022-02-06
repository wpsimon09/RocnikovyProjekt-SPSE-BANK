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
        public string DatumUkoncenia { get; set; }
        public string SumaNaVyzbieranie { get; set; }
        public string[] MenaZiakov {get; set;}
        public double KolkoKazdyZaplati { get; set; }
        public double ProgressZberania { get; set; }

        /// <summary>
        /// Konstruktor pre triedu ZberPenati
        /// </summary>
        /// <param name="nazov">názov zberania</param>
        /// <param name="datum">dokedy treba vyzbierat</param>
        /// <param name="suma">suma ktoru treba vyzbierat</param>
        public ZberPenazi(string nazov, string datum, string suma)
        {
            Nazov = nazov;
            DatumUkoncenia = datum;
            SumaNaVyzbieranie = suma;
            try
            {
                MenaZiakov = new string[] { "iuhi", "sodijfosi","sdlfks","oijoi","sdfoji" }; //(App.Current as App).MenaZiakov;
                KolkoKazdyZaplati = Math.Round( Convert.ToDouble(SumaNaVyzbieranie) / Convert.ToDouble( MenaZiakov.Length),2);
            }
            catch (NullReferenceException)
            {

            }
        }

        public ZberPenazi()
        {
            Nazov = string.Empty;
            DatumUkoncenia = string.Empty;
            SumaNaVyzbieranie = string.Empty;
            try
            {
                MenaZiakov = (App.Current as App).MenaZiakov;
            }
            catch(NullReferenceException)
            { 

            }
        }

        /// <summary>
        /// Pridá nové zberanie peňazí
        /// </summary>
        /// <param name="Listzberanie">List do ktorého sa má nahrat najčastejsie globálna premenná</param>
        /// <param name="nazov">Názov zberania</param>
        /// <param name="datum">Dokedy sa ma vyzbierat</param>
        /// <param name="suma">Kolko sa má vyzbierat</param>
        public void NahranieSporeniaDoListu(List<ZberPenazi> Listzberanie, string nazov, string datum, string suma)
        {
            Listzberanie.Add(new ZberPenazi($"Dôvod:"+nazov, $"Do:" + datum, suma));
          
        }

      
    }
}
