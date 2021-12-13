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
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._5__Zber_peňazí
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Zberanie_peňazí : Page
    {
        int PocetZobrazenýchSporení = 0;
        public Zberanie_peňazí()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;

            Sporenie1.Visibility = Visibility.Collapsed;
            Sporenie2.Visibility = Visibility.Collapsed;
            Sporenie3.Visibility = Visibility.Collapsed;
        }

        private void Naspat_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HlavnaStranaUčtu));
        }
        private void ZberaniePeňazí_Click(object sender, RoutedEventArgs e)
        {
            switch (PocetZobrazenýchSporení)
            {
                case 0:
                    {
                        (App.Current as App).PrehranieAnimacieANavigovanieNaStranu(AnimáciaNaSpustenie);
                        PocetZobrazenýchSporení++;
                        Sporenie1.Visibility = Visibility.Visible;
                        break;
                    }
                case 1:
                    {
                        (App.Current as App).PrehranieAnimacieANavigovanieNaStranu(AnimáciaNaSpustenie);
                        PocetZobrazenýchSporení++;
                        Sporenie2.Visibility = Visibility.Visible;
                        break;
                    }
                case 2:
                    {
                        (App.Current as App).PrehranieAnimacieANavigovanieNaStranu(AnimáciaNaSpustenie);
                        PocetZobrazenýchSporení++;
                        Sporenie3.Visibility = Visibility;
                        StackPanelTlacidlomNaPridávanie.Visibility = Visibility.Collapsed;
                        Naspat.Margin = new Thickness(30);
                        break;
                    }
                    
            }
            PocetSporeni.Text = $"{PocetZobrazenýchSporení}/3";
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if((App.Current as App).GlobalnaPremenaVytvorenieZberania[0].NázovZberania!=string.Empty)
            {
                NahranieHodnôtDoZbierania(NázovZberania1, DokedyTrebaVyzbierať1, VztbieranePeniaze1, 0, (App.Current as App).GlobalnaPremenaVytvorenieZberania);
            }
            else
            {

            }

            if ((App.Current as App).GlobalnaPremenaVytvorenieZberania[1].NázovZberania != string.Empty)
            {
                NahranieHodnôtDoZbierania(NázovZberania2, DokedyTrebaVyzbierať2, VztbieranePeniaze2, 1, (App.Current as App).GlobalnaPremenaVytvorenieZberania);
            }
            else
            {

            }

            if ((App.Current as App).GlobalnaPremenaVytvorenieZberania[2].NázovZberania != string.Empty)
            {
                NahranieHodnôtDoZbierania(NázovZberania3, DokedyTrebaVyzbierať3, VztbieranePeniaze1, 2, (App.Current as App).GlobalnaPremenaVytvorenieZberania);
            }
            else
            {

            }

        }

        private void Sporenie1_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).NaKtoréZberanieSaKliklo = 1;
            this.Frame.Navigate(typeof(VytvorenieZberaniaPeňazí));
        }

        private void Sporenie2_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).NaKtoréZberanieSaKliklo = 2;
            this.Frame.Navigate(typeof(VytvorenieZberaniaPeňazí));
        }

        private void Sporenie3_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).NaKtoréZberanieSaKliklo = 3;
            this.Frame.Navigate(typeof(VytvorenieZberaniaPeňazí));
        }

        public void NahranieHodnôtDoZbierania(TextBlock názov, TextBlock dátum, TextBlock suma, int index, VytvorenieZberaniaPeňazí.VyzbieranePeniaze [] infoOVyzbieaniu)
        {
            try
            {
                názov.Text = infoOVyzbieaniu[index].NázovZberania;
                dátum.Text = infoOVyzbieaniu[index].DátumDoKedySaMaVyzbirať;
                suma.Text = infoOVyzbieaniu[index].SumaNaVyzbieranie.ToString();
            }
            catch(System.ArgumentNullException)
            {
                
            }
            
        }
    }
}
