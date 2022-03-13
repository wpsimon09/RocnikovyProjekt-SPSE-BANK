using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu._1._4___Overovacia_strana._1._5__Zadanie_Ziako;
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
        public int indexZberu { get; set; }
        public System.DateTimeOffset DatumUkonceniaOffSet { get; set; }
        public List<Ziak> Ziaci { get; set; }

        /// <summary>
        /// Konstruktor pre triedu ZberPenati
        /// </summary>
        /// <param name="nazov">názov zberania</param>
        /// <param name="datum">dokedy treba vyzbierat</param>
        /// <param name="suma">suma ktoru treba vyzbierat</param>
        public ZberPenazi(string nazov, string datum, string suma, List<Ziak> ziaci,DateTimeOffset timeOffset)
        {
            Nazov = nazov;
            DatumUkoncenia = datum;
            SumaNaVyzbieranie = suma;
            DatumUkonceniaOffSet = timeOffset;
            try
            {
                Ziaci = ziaci;
                KolkoKazdyZaplati = Math.Round( Convert.ToDouble(SumaNaVyzbieranie) / Convert.ToDouble( Ziaci.Count),2);
            }
            catch (NullReferenceException)
            {
                
            }
            (App.Current as App).IndexZberu++;
            this.indexZberu = (App.Current as App).IndexZberu;
            
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
        public void NahranieSporeniaDoListu(List<ZberPenazi> Listzberanie, string nazov, string datum, string suma,List<Ziak> ziaci,DateTimeOffset date)
        {
            Listzberanie.Add(new ZberPenazi(nazov,datum, suma,ziaci,date));     
        }

        public void NahranieLudi(ListView list,int NaKtoreSaKliklo)
        {
            int index = 0;
            foreach (object item in list.Items)
            {
                ListViewItem items = list.ContainerFromItem(item) as ListViewItem;

                if(items.IsSelected)
                {
             
                    (App.Current as App).ListZbieranychPenazi[NaKtoreSaKliklo].Ziaci[index].JeZačiarknute = true;
                    index++;
                }
                else if (!items.IsSelected )
                {
                    (App.Current as App).ListZbieranychPenazi[NaKtoreSaKliklo].Ziaci[index].JeZačiarknute = false;
                    index++;
                }
               
            }
  
        }

        public void NahranieItemovKtoreBoliZakliknute(ListView Nezaplatili,int NaKtoreSaKliklo)
        {
            int i = 0;
            foreach (object item in Nezaplatili.Items)
            {
                if ((App.Current as App).ListZbieranychPenazi[NaKtoreSaKliklo].Ziaci[i].JeZačiarknute == true)
                {
                    Nezaplatili.SelectRange(new ItemIndexRange(i, 1));
                    i++;
                }
                else
                {

                    i++;
                }
            }

        }

    }
}
