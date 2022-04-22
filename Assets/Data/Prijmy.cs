using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._4___Sporenie;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._5__Zber_peňazí;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Assets.Data
{
    public class Prijmy
    {
        public string Prijem { get; set; }
        
        public Prijmy (PlatobnySystem prijem)
        {
            Prijem = $"{DateTime.Now} - {prijem.InkasovanaSuma} € od {prijem.OdKohoPrisliPenia} do triedneho fondu";
            (App.Current as App).GlobalHistoria.Prijmy += prijem.InkasovanaSuma;
        }

        public Prijmy (Sporenie prijemnaSporenie, string ziak)
        {
            Prijem = $"{DateTime.Now} - {prijemnaSporenie.SumaNaHistoriu} € od {ziak} na sporenie";
            (App.Current as App).GlobalHistoria.Prijmy += prijemnaSporenie.SumaNaHistoriu;

        }

        public Prijmy (ZberPenazi zber)
        {
            Prijem = $"{zber.DatumUkoncenia} - {zber.SumaNaVyzbieranie} € na {zber.Nazov} od  do triedneho fondu";
            (App.Current as App).GlobalHistoria.Prijmy += Convert.ToDouble(zber.SumaNaVyzbieranie);

        }
    }
}
