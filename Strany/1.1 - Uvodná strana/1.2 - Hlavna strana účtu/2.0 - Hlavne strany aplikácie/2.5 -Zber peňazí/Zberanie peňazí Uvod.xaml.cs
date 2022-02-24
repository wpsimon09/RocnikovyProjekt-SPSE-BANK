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
        public int KtoreSporenieSaIdeUpraviť;
        public List<ZberPenazi> ListZberani;

        public Zberanie_peňazí()
        {
            KtoreSporenieSaIdeUpraviť = 0;
            (App.Current as App).KtoreZberanieBudeUpravené = null;
            ListZberani = (App.Current as App).ListZbieranychPenazi;
            this.InitializeComponent();
        }

        private void Naspat_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HlavnaStranaUčtu));
        }
     
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            

        }

        private void PridatZberanie_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            (App.Current as App).PrehranieAnimacieANavigovanieNaStranu(AnimáciaNaSpustenie, typeof(VytvorenieZberaniaPeňazí), this);
        }

        private void Zberania_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (App.Current as App).NaKtoréZberanieSaKliklo = Zberania.SelectedIndex;
            this.Frame.Navigate(typeof(HlavnaStranaZberaniaPeňazí));
        }

        private void Item_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            (App.Current as App).KtoreZberanieBudeUpravené = (e.OriginalSource as FrameworkElement).DataContext as ZberPenazi;
           

            MenuFlyout menu = new MenuFlyout();
            MenuFlyoutItem upravit = new MenuFlyoutItem();
            MenuFlyoutItem vymazať = new MenuFlyoutItem();

            upravit.Text = "Upraviť";
            vymazať.Text = "Vymazať";

            upravit.Click += Upravit_Click;
            vymazať.Click += Vymazať_Click;

            menu.Items.Add(vymazať);
            menu.Items.Add(upravit);

            FrameworkElement senderElement = sender as FrameworkElement;
            menu.ShowAt(senderElement);
            

        }

        private void Vymazať_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).ListZbieranychPenazi.Remove((App.Current as App).KtoreZberanieBudeUpravené);
           
        }

        private void Upravit_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(VytvorenieZberaniaPeňazí));
        }
    }
}
