using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Popups;
using System.Runtime.CompilerServices;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu._1._4___Overovacia_strana._1._5__Zadanie_Ziako;
using Ročňíkový_projekt___Aplikácia_pre_banku.Assets.Data;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._4___Sporenie
{
    public class Sporenie
    {
        public List<Ziak> ZiaciPreSporenieNaStuzkovu { get; set; }
        public List<Ziak> ZiaciKtoryZaplatili { get; set; }

        public double SumaNaHistoriu { get; set; }


        public string ZiakKtoryZaplatil { get; set; }


        private double _vyzbieranaSuma;
        public double VyzbieranaSuma
        {
            get { return _vyzbieranaSuma; }
            set
            {
                _vyzbieranaSuma = value;
                OnPropertyChanged();
            }
        }

        private double _cielenaSuma;
        public double CielenaSuma
        {
            get { return _cielenaSuma; }
            set
            {
                _cielenaSuma = value;
                OnPropertyChanged();
            }
        }
        public string DatumUkonceniaSporeniaPriVytvoreniu { get; set; }
        public int ProgressSporenie { get; set; }

        public bool BoloVytvorené { get; set; }

        public  Sporenie()
        {
            BoloVytvorené = false;
            ZiaciKtoryZaplatili = new List<Ziak>();
            ZiaciPreSporenieNaStuzkovu = (App.Current as App).ListZiakov;
            VyzbieranaSuma = 0;
            CielenaSuma = 0;
            DatumUkonceniaSporeniaPriVytvoreniu = string.Empty;
            ProgressSporenie = 0;
        }

        /// <summary>
        /// Aktualizuje progress sporenia
        /// </summary>
        public async void UpdateProgress()
        {
            try
            {
                ProgressSporenie = Convert.ToInt32((VyzbieranaSuma / this.CielenaSuma) * 100);
            }
            catch (System.OverflowException)
            {
                var message = new MessageDialog("Platba nebola úspešná", "Sporiaci účet nieje vytvorený");
                await message.ShowAsync();
            }
        }

        /// <summary>
        /// Nahrá sumu, ktorá bola inkasovaná
        /// </summary>
        /// <param name="suma"></param>
        public void InkasoNaSporenie(double suma)
        {
            this.VyzbieranaSuma = this.VyzbieranaSuma + suma;
            this.UpdateProgress();
        }


        /// <summary>
        /// Je sporenie vytvorené ?
        /// </summary>
        /// <returns>true ak áno opačne false</returns>
        public bool ZobraziSaNaUvodnejStrane()
        {
            if (CielenaSuma == 0 || VyzbieranaSuma == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Vykoná platbu
        /// </summary>
        /// <param name="suma">suma, ktorá sa platí</param>
        public async void VykonatPlatbu(double suma)
        {
            if(suma>VyzbieranaSuma)
            {
                var message = new MessageDialog("Platba nebola úspešná", "Na sporiacom účte nemáte dostatok financií");
                await message.ShowAsync();
            }
            else
            {
                VyzbieranaSuma = VyzbieranaSuma - suma;
                (App.Current as App).GlobalHistoria.vydavky.Add(new Vydavky((App.Current as App).PlatobnySistem, 1));
                (App.Current as App).GlobalSporenie = this;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
