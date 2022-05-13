using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using System.ComponentModel;
using System.Runtime.CompilerServices; 
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._4___Sporenie;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._5__Zber_peňazí;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Assets.Data
{
    public class Prijmy:INotifyPropertyChanged
    {
        public string Prijem { get; set; }

        Visibility _visibility;

        public Visibility viditelnost
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
