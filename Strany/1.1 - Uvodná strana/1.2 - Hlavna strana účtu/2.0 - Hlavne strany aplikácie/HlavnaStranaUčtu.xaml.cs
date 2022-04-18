using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media;
using Windows.UI.Popups;
using Windows.Storage;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._5__Zber_peňazí;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._4___Sporenie;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HlavnaStranaUčtu : Page
    {
        public PlatobnySystem platobnySystem { get; set; }
        public Sporenie sporenie { get; set; }
        public HlavnaStranaUčtu()
        {
            sporenie = (App.Current as App).GlobalSporenie;
            platobnySystem = (App.Current as App).PlatobnySistem;
            this.InitializeComponent();

            if (sporenie.BoloVytvorené == false)
            {
                StackPanelSSporenim.Visibility = Visibility.Collapsed;
            }
            else
            {
                StackPanelSSporenim.Visibility = Visibility.Visible;
            }
        }

        public void NacitanieTriedy()
        {
            MenoPriIkonke.Text = (App.Current as App).GlobalnaPremenaTriedy.trieda;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.NacitanieTriedy();
        }

        public void Visible(TextBlock txtBloc)
        {
            txtBloc.Visibility = Visibility.Visible;
        }
        
        public void Collapsed(TextBlock txtBlox1)
        {
            txtBlox1.Visibility = Visibility.Collapsed;
        }

        private void MiškaNaVložení(object sender, PointerRoutedEventArgs e)
        {
            Visible(VlozenieProstriedkov);
        }


        private void MiškaOdišlaOdVloženia(object sender, PointerRoutedEventArgs e)
        {
            Collapsed(VlozenieProstriedkov);
        }

        

        private void MyškaNaPlatbe(object sender, PointerRoutedEventArgs e)
        {
            Visible(Platba);
        }

        private void MyškaOdišlaOdPlatby(object sender, PointerRoutedEventArgs e)
        {
            Collapsed(Platba);
        }

        private void MyškaNaHistorii(object sender, PointerRoutedEventArgs e)
        {
            Visible(HistoriaPlatieb);
        }

        private void MyškaOdišlaOdHistoria(object sender, PointerRoutedEventArgs e)
        {
            Collapsed(HistoriaPlatieb);
        }

        private void MyšNaSporeni(object sender, PointerRoutedEventArgs e)
        {
            Visible(Sporenie);
        }

        private void MyšOdyšlaOdSporenie(object sender, PointerRoutedEventArgs e)
        {
            Collapsed(Sporenie);
        }

        private void MyšNaZbere(object sender, PointerRoutedEventArgs e)
        {
            Visible(ZberPeňazí);
        }

        private void MyšOdišlaOdZberu(object sender, PointerRoutedEventArgs e)
        {
            Collapsed(ZberPeňazí);
        }

        private void MyšNaVoľnomČase(object sender, PointerRoutedEventArgs e)
        {
            Visible(VoľnýČas);
        }

        private void MyšOpustilaVoľnýČas(object sender, PointerRoutedEventArgs e)
        {
            Collapsed(VoľnýČas);
        }

        private void Odhlasenie_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Strany._1._1___Uvodná_strana.Prvá_strana));
        }

        private void VlozeniePeňazí_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._1___Pridanie_peňazí.PridaniePeňazí));
           
        }

        private void Platba1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(_1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._2___Platba.Platba));
        }

        private void HistoriaPlatieb1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(_1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._3___Historia_platieb.HistoriaPlatieb));
        }

        private void Sporenie1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._4___Sporenie.SporenieNaStužkovú));
        }

        private void ZberPeňazí1_Click(object sender, RoutedEventArgs e)
        {
            /*
            if ((App.Current as App).JeTriedaPlneVytvorená == true)
            {
                this.Frame.Navigate(typeof(Zberanie_peňazí));
            }
            else
            {
                var msg = new MessageDialog("Chýba kompletné vyplnenie triednych údajov", "Sporenie sa nedá vytvoriť");
                msg.ShowAsync();

                this.Frame.Navigate(typeof(Vytvorenie_triedy));
            }
            */

            this.Frame.Navigate(typeof(Zberanie_peňazí));

        }

        private void VoľnýČas1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._6___Zábava_a_relax.ZábavaARelax));
        }
    }
}
