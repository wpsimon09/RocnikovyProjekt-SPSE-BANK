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
using Ročňíkový_projekt___Aplikácia_pre_banku.Assets.MessageDIalogy;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._5__Zber_peňazí
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HlavnaStranaZberaniaPeňazí : Page
    {
        public ZberPenazi zberanie;
        public int NaKtoreSaKliklo;
        public HlavnaStranaZberaniaPeňazí()
        {
            NaKtoreSaKliklo = (App.Current as App).NaKtoréZberanieSaKliklo;
            zberanie = (App.Current as App).ListZbieranychPenazi[NaKtoreSaKliklo];
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                DosiahnutyGoal.Value = (App.Current as App).ListZbieranychPenazi[NaKtoreSaKliklo].ProgressZberania;
                Nezaplatili.Loaded += Nezaplatili_Loaded;
            }
            catch (System.NullReferenceException)
            {
                DosiahnutyGoal.Value = 0;
            }
        }

        private void Nezaplatili_Loaded(object sender, RoutedEventArgs e)
        {
            NaKtoreSaKliklo = (App.Current as App).NaKtoréZberanieSaKliklo;
            (App.Current as App).ListZbieranychPenazi[NaKtoreSaKliklo].NahranieItemovKtoreBoliZakliknute(Nezaplatili, NaKtoreSaKliklo);
        }

        private void Nezaplatili_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double dosiahnutyGoal = new double();
            double KolkoSaVyzbieralo = new double();

            int SelectnutyIndex = Nezaplatili.SelectedIndex;

            KolkoSaVyzbieralo = Math.Round(zberanie.KolkoKazdyZaplati * Nezaplatili.SelectedItems.Count,2 );

            dosiahnutyGoal = (KolkoSaVyzbieralo / Convert.ToDouble(zberanie.SumaNaVyzbieranie) * 100);
            dosiahnutyGoal = Math.Round(dosiahnutyGoal, 2);
            DosiahnutyGoal.Value = dosiahnutyGoal;

            KtoVaetkoZaplatil1.Text = $"{KolkoSaVyzbieralo}/{zberanie.SumaNaVyzbieranie}";

            PocetZaplatenych.Text = $"{Nezaplatili.SelectedItems.Count}/{zberanie.Ziaci.Count}";

            DaSaTlacidloUvolnit();
        }

        private void Naspäť_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).ListZbieranychPenazi[NaKtoreSaKliklo].ProgressZberania = DosiahnutyGoal.Value;
            (App.Current as App).ListZbieranychPenazi[NaKtoreSaKliklo].NahranieLudi(Nezaplatili,NaKtoreSaKliklo);
            this.Frame.Navigate(typeof(Zberanie_peňazí));
        }

        private async void InfoIkonka_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            InfoOZberani msgOZberani = new InfoOZberani();
            await msgOZberani.ShowAsync();
        }

        private void InfoIkonka_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand,1);
        }

        private void InfoIkonka_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 2);
        }

        private void DaSaTlacidloUvolnit()
        {
            if(Nezaplatili.SelectedItems.Count == zberanie.Ziaci.Count)
            {
                UkončenieZberania.IsEnabled = true;
            }
            else
            {   
                UkončenieZberania.IsEnabled = false;
            }
        }

        private void UkončenieZberania_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).PlatobnySistem.CelkovaSuma += Convert.ToDouble(zberanie.SumaNaVyzbieranie);
            this.Frame.Navigate(typeof(Zberanie_peňazí));
        }

        
    }
}
