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
        public int KtoreSporenieSaIdeUpraviť;


        public Zberanie_peňazí()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;

            Sporenie1.Visibility = Visibility.Collapsed;
            Sporenie2.Visibility = Visibility.Collapsed;
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
                        if(Sporenie1.Visibility == Visibility.Visible)
                        {
                            break;
                        }
                        else
                        {
                            PocetZobrazenýchSporení++;
                            (App.Current as App).PrehranieAnimacieANavigovanieNaStranu(AnimáciaNaSpustenie);
                            Sporenie1.Visibility = Visibility.Visible;
                            break;
                        }
                        
                    }
                case 1:
                    {
                        if(Sporenie2.Visibility == Visibility.Visible)
                        {
                            break;
                        }
                        else
                        {
                            ZberaniePeňazí.Visibility = Visibility.Collapsed;
                            PocetZobrazenýchSporení++;
                            (App.Current as App).PrehranieAnimacieANavigovanieNaStranu(AnimáciaNaSpustenie);
                            Sporenie2.Visibility = Visibility.Visible;
                            break;
                        }
                        
                    }
                    
            }
            PocetSporeni.Text = $"{PocetZobrazenýchSporení}/2";

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

            switch ((App.Current as App).KtoreZberanieJeUžHotove)
            {
                case 1:
                    {
                        VymazanieUkoncenehoSporenia(NázovZberania1, DokedyTrebaVyzbierať1, VztbieranePeniaze1, 0, (App.Current as App).GlobalnaPremenaVytvorenieZberania);
                        break;
                    }
                case 2:
                    {
                        VymazanieUkoncenehoSporenia(NázovZberania2, DokedyTrebaVyzbierať2, VztbieranePeniaze2, 1, (App.Current as App).GlobalnaPremenaVytvorenieZberania);
                        break;
                    }
            }

            switch((App.Current as App).NaKtoréZberanieSaKliklo)
            {
                case 1:
                    {
                        KtoVaetkoZaplatil1.Text = $"{(App.Current as App).KolkoSaZatialVyzbieralo[0]}/{(App.Current as App).GlobalnaPremenaVytvorenieZberania[0].SumaNaVyzbieranie}";
                        DosiahnutyGoal.Value = (App.Current as App).ProgressZberania[0];
                        break;
                    }
                case 2:
                    {
                        DosiahnutyGoa2.Value = (App.Current as App).ProgressZberania[1];
                        KtoVaetkoZaplatil2.Text = $"{(App.Current as App).KolkoSaZatialVyzbieralo[1]}/{(App.Current as App).GlobalnaPremenaVytvorenieZberania[1].SumaNaVyzbieranie}";
                        break;
                    }

            }
 

        }

        private void Sporenie1_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).NaKtoréZberanieSaKliklo = 1;
            VytvorenieAleboManažovanie(0, (App.Current as App).GlobalnaPremenaVytvorenieZberania);
        }

        private void Sporenie2_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).NaKtoréZberanieSaKliklo = 2;
            VytvorenieAleboManažovanie(1, (App.Current as App).GlobalnaPremenaVytvorenieZberania);
        }

        private void Sporenie3_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).NaKtoréZberanieSaKliklo = 3;
            VytvorenieAleboManažovanie(2, (App.Current as App).GlobalnaPremenaVytvorenieZberania);
        }

        /// <summary>
        /// nahrá hodnoty, ktoré sa obrazia pri náhľade zberania
        /// </summary>
        /// <param name="názov"></param>
        /// <param name="dátum"></param>
        /// <param name="suma"></param>
        /// <param name="index"></param>
        /// <param name="infoOVyzbieaniu"></param>
        public void NahranieHodnôtDoZbierania(TextBlock názov, TextBlock dátum, TextBlock suma, int index, VytvorenieZberaniaPeňazí.VyzbieranePeniaze [] infoOVyzbieaniu)
        {
            try
            {
                názov.Text = infoOVyzbieaniu[index].NázovZberania;
                dátum.Text = $"Do: {infoOVyzbieaniu[index].DátumDoKedySaMaVyzbirať}";
                suma.Text = $"Cieľ: {infoOVyzbieaniu[index].SumaNaVyzbieranie.ToString()}€";
            }
            catch(System.ArgumentNullException)
            {
                
            }
            
        }

        public void VytvorenieAleboManažovanie(int index, VytvorenieZberaniaPeňazí.VyzbieranePeniaze[] infoOVyzbieaniu)
        {
            if(string.IsNullOrEmpty(infoOVyzbieaniu[index].NázovZberania))
            {
                this.Frame.Navigate(typeof(VytvorenieZberaniaPeňazí));
            }
            else
            {
                this.Frame.Navigate(typeof(HlavnaStranaZberaniaPeňazí));
            }
        }

        private void Sporenie1_PravýKlik(object sender, RightTappedRoutedEventArgs e)
        {
            MenuFlyout sporenie1Menu = new MenuFlyout();
            MenuFlyoutItem Upraviť1 = new MenuFlyoutItem { Text = "Upraviť" };
            MenuFlyoutItem Vymazať1 = new MenuFlyoutItem { Text = "Vymazať" };
            sporenie1Menu.ShowMode = FlyoutShowMode.TransientWithDismissOnPointerMoveAway;

            Upraviť1.Click += Upraviť1_Click;
            Vymazať1.Click += Vymazať1_Click;

            sporenie1Menu.Items.Add(Upraviť1);
            sporenie1Menu.Items.Add(Vymazať1);

            FrameworkElement senderElement = sender as FrameworkElement;
            sporenie1Menu.ShowAt(senderElement);
        }

        private void Vymazať1_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).KtoreZberanieBudeUpravené = 1;
            VymazanieSporenia(NázovZberania1, DokedyTrebaVyzbierať1, VztbieranePeniaze1, 0, (App.Current as App).GlobalnaPremenaVytvorenieZberania);
        }

        private void Upraviť1_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).KtoreZberanieBudeUpravené = 1;
            this.Frame.Navigate(typeof(VytvorenieZberaniaPeňazí));
        }


        private void Sporenie2_PravýmClick(object sender, RightTappedRoutedEventArgs e)
        {

            MenuFlyout sporenie2Menu = new MenuFlyout();
            MenuFlyoutItem Upraviť2 = new MenuFlyoutItem { Text = "Upraviť" };
            MenuFlyoutItem Vymazať12 = new MenuFlyoutItem { Text = "Vymazať" };
            sporenie2Menu.ShowMode = FlyoutShowMode.TransientWithDismissOnPointerMoveAway;

            Upraviť2.Click += Upraviť2_Click;
            Vymazať12.Click += Vymazať12_Click;

            sporenie2Menu.Items.Add(Upraviť2);
            sporenie2Menu.Items.Add(Vymazať12);

            FrameworkElement senderElemnt = sender as FrameworkElement;
            sporenie2Menu.ShowAt(senderElemnt);

        }

        private void Vymazať12_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).KtoreZberanieBudeUpravené = 2;
            VymazanieSporenia(NázovZberania2, DokedyTrebaVyzbierať2, VztbieranePeniaze2, 1, (App.Current as App).GlobalnaPremenaVytvorenieZberania);
        }

        private void Upraviť2_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).KtoreZberanieBudeUpravené = 2;
            this.Frame.Navigate(typeof(VytvorenieZberaniaPeňazí));
        }


        public void VymazanieSporenia(TextBlock názov, TextBlock dátum, TextBlock suma, int index, VytvorenieZberaniaPeňazí.VyzbieranePeniaze[] infoOVyzbieaniu)
        {
            názov.Text = "Nieje vytvorené";
            dátum.Text = "--.--.----";
            suma.Text = "0€";

            infoOVyzbieaniu[index].DátumDoKedySaMaVyzbirať = null;
            infoOVyzbieaniu[index].NázovZberania = string.Empty;
            infoOVyzbieaniu[index].SumaNaVyzbieranie = 0;

            switch((App.Current as App).KtoreZberanieBudeUpravené)
            {
                case 1:
                    {
                        ZberaniePeňazí.Visibility = Visibility.Visible;
                        Sporenie1.Visibility = Visibility.Collapsed;
                        PocetZobrazenýchSporení--;

                        break;
                    }
                case 2:
                    {
                        ZberaniePeňazí.Visibility = Visibility.Visible;
                        Sporenie2.Visibility = Visibility.Collapsed;
                        PocetZobrazenýchSporení--;

                        break;
                    }
            }

            
            if(PocetZobrazenýchSporení == 2)
            {
                StackPanelTlacidlomNaPridávanie.Visibility = Visibility.Collapsed;
            }
            else if (PocetZobrazenýchSporení == 1 || PocetZobrazenýchSporení == 0)
            {
                StackPanelTlacidlomNaPridávanie.Visibility = Visibility.Visible;
            }

            PocetSporeni.Text = $"{PocetZobrazenýchSporení}/2";
        }

        public void VymazanieUkoncenehoSporenia(TextBlock názov, TextBlock dátum, TextBlock suma, int index, VytvorenieZberaniaPeňazí.VyzbieranePeniaze[] infoOVyzbieaniu)
        {
            názov.Text = "Nieje vytvorené";
            dátum.Text = "--.--.----";
            suma.Text = "0€";

            infoOVyzbieaniu[index].DátumDoKedySaMaVyzbirať = null;
            infoOVyzbieaniu[index].NázovZberania = string.Empty;
            infoOVyzbieaniu[index].SumaNaVyzbieranie = 0;

            switch ((App.Current as App).KtoreZberanieJeUžHotove)
            {
                case 1:
                    {
                        ZberaniePeňazí.Visibility = Visibility.Visible;
                        Sporenie1.Visibility = Visibility.Collapsed;
                        PocetZobrazenýchSporení--;

                        break;
                    }
                case 2:
                    {
                        ZberaniePeňazí.Visibility = Visibility.Visible;
                        Sporenie2.Visibility = Visibility.Collapsed;
                        PocetZobrazenýchSporení--;

                        break;
                    }
            }


            if (PocetZobrazenýchSporení == 2)
            {
                StackPanelTlacidlomNaPridávanie.Visibility = Visibility.Collapsed;
            }
            else if (PocetZobrazenýchSporení == 1 || PocetZobrazenýchSporení == 0)
            {
                StackPanelTlacidlomNaPridávanie.Visibility = Visibility.Visible;
            }
            (App.Current as App).KtoreZberanieJeUžHotove = 0;
            PocetSporeni.Text = $"{PocetZobrazenýchSporení}/2";
        }
    }
}
