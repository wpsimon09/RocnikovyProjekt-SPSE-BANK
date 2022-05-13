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
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._2___Platba;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._1___Pridanie_peňazí;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._3___Historia_platieb
{
   
    public sealed partial class HistoriaPlatieb : Page
    {
        public Historia historia { get; set; } 
        public static int NaKtoreSaKliklo { get; set; }

        public static StackPanel stackPanelNaZakrytie { get; set; } 

        public HistoriaPlatieb()
        {
            stackPanelNaZakrytie = new StackPanel();
            NaKtoreSaKliklo = new int();
            historia = (App.Current as App).GlobalHistoria;
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            Vysledok.Text = $"{VyrátanieCelkovéhoVýsledku((App.Current as App).GlobalHistoria.Prijmy,(App.Current as App).GlobalHistoria.Vydavky)} €";
            PomerPrijmovAVydajkov.Value = VyrátanieHodnotyPreProgressBar((App.Current as App).GlobalHistoria.Prijmy, (App.Current as App).GlobalHistoria.Vydavky);   
        }

        private void Naspäť_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie.HlavnaStranaUčtu)); 
        }

        
        /// <summary>
        /// Navráti hodnotu value pre progressbar
        /// </summary>
        /// <param name="prijmy">double: súčet všetkých príjmov</param>
        /// <param name="vydavky">double súčet všetkých výdavkov</param>
        private int VyrátanieHodnotyPreProgressBar(double prijmy, double vydavky)
        {
            double temp;
            int hodnota = 0;

            if (vydavky < prijmy)
            {
                hodnota = Convert.ToInt32((prijmy / (prijmy + vydavky)) * 100);
                StackPanelSInformáciami.Visibility = Visibility.Visible;
                return hodnota;
            }

            else if (prijmy < vydavky)
            {
                hodnota = Convert.ToInt32((vydavky / (prijmy + vydavky)) * 100);
                StackPanelSInformáciami.Visibility = Visibility.Visible;
                return hodnota;
            }

            else if (vydavky == 0 && prijmy > 0)
            {
                StackPanelSInformáciami.Visibility = Visibility.Visible;
                hodnota = 100;
                return hodnota;
            }

            else if (prijmy == vydavky)
            {
                StackPanelSInformáciami.Visibility = Visibility.Visible;
                hodnota = 50;
                return hodnota;
            }

            else if (prijmy == 0 && vydavky > 0)
            {
                StackPanelSInformáciami.Visibility = Visibility.Visible;
                hodnota = 0;
                return hodnota;
            }

            else if (prijmy == 0 && vydavky == 0)
            {
                hodnota = 0;
                StackPanelSInformáciami.Visibility = Visibility.Collapsed;
                return hodnota;
            }

            else
            {
                StackPanelSInformáciami.Visibility = Visibility.Collapsed;
                hodnota = 0;
                return hodnota;
            }
        }

        /// <summary>
        /// Vyráta hospodársky výsledok
        /// </summary>
        /// <param name="prijmy"> double: súčet príjmov </param>
        /// <param name="vydavky"> double: súčet výdavkov </param>
        /// <returns></returns>
        public double VyrátanieCelkovéhoVýsledku(double prijmy, double vydavky)
        {
            double vysledok;
            vysledok = prijmy - vydavky;
            return vysledok;
        }


        private void itemVydavky_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
           stackPanelNaZakrytie = (e.OriginalSource as FrameworkElement) as StackPanel;

            MenuFlyout menu = new MenuFlyout();
            MenuFlyoutItem nezobrazovat_vydavok = new MenuFlyoutItem();


            nezobrazovat_vydavok.Text = "Nezobrazovať";

            nezobrazovat_vydavok.Click += Nezobrazovat_vydavok_Click;
            

            menu.Items.Add(nezobrazovat_vydavok);

            FrameworkElement senderElement = sender as FrameworkElement;
            menu.ShowAt(senderElement);
        }


        private void Prijmy_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            MenuFlyout menu = new MenuFlyout();
            MenuFlyoutItem nezobrazovatPrijem = new MenuFlyoutItem();


            nezobrazovatPrijem.Text = "Nezobrazovať";
            nezobrazovatPrijem.Click += NezobrazovatPrijem_Click;


            menu.Items.Add(nezobrazovatPrijem);

            FrameworkElement senderElement = sender as FrameworkElement;
            menu.ShowAt(senderElement);
        }

        private void Nezobrazovat_vydavok_Click(object sender, RoutedEventArgs e)
        {

            historia.vydavky[NaKtoreSaKliklo].viditelnost = Visibility.Collapsed;

            (App.Current as App).GlobalHistoria.vydavky.Remove((App.Current as App).GlobalHistoria.vydavky[NaKtoreSaKliklo]);
        }


        private void NezobrazovatPrijem_Click(object sender, RoutedEventArgs e)
        {
            historia.prijmy[NaKtoreSaKliklo].viditelnost = Visibility.Collapsed;

            (App.Current as App).GlobalHistoria.prijmy.Remove((App.Current as App).GlobalHistoria.prijmy[NaKtoreSaKliklo]);
        }

        private void Prijmy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NaKtoreSaKliklo = Prijmy.SelectedIndex;
        }

        private void Vydavky_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NaKtoreSaKliklo = Vydavky.SelectedIndex;
        }
    }
 
}