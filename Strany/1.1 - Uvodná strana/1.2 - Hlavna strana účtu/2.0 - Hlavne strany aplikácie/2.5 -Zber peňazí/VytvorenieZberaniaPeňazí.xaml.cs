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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._5__Zber_peňazí
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VytvorenieZberaniaPeňazí : Page
    {
        public ZberPenazi zber;
        public VytvorenieZberaniaPeňazí()
        {
            if((App.Current as App).KtoreZberanieBudeUpravené == null)
            {
                zber = new ZberPenazi();
            }
            else
            {
                zber = (App.Current as App).KtoreZberanieBudeUpravené;
            }
            this.InitializeComponent();
        }


        private void CielenaSuma_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void Naspäť_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Zberanie_peňazí));
        }

        private async void Pokračovať_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CielenaSuma.Text) || string.IsNullOrEmpty(DôvodSporenia.Text) || UkoncenieSporenia == null)
            {
                var msg = new MessageDialog("Niesu vyplnené všetky údaje", "Vytvorenie zlyhalo");
                await msg.ShowAsync();
            }
            else
            {
                if ((App.Current as App).KtoreZberanieBudeUpravené == null)
                {
                    double peniaze;
                    peniaze = Math.Round(Convert.ToDouble(CielenaSuma.Text), 2);
                    zber.NahranieSporeniaDoListu((App.Current as App).ListZbieranychPenazi, DôvodSporenia.Text, UkoncenieSporenia.Date.Value.DateTime.ToString("d"), peniaze.ToString(), (App.Current as App).ListZiakov, UkoncenieSporenia.Date.Value);
                    this.Frame.Navigate(typeof(Zberanie_peňazí));
                }
                else
                {
                    (App.Current as App).KtoreZberanieBudeUpravené.DatumUkoncenia = UkoncenieSporenia.Date.Value.DateTime.ToString("d");
                    (App.Current as App).KtoreZberanieBudeUpravené.Nazov = DôvodSporenia.Text;
                    double peniaze;
                    peniaze = Math.Round(Convert.ToDouble(CielenaSuma.Text), 2);
                    (App.Current as App).KtoreZberanieBudeUpravené.SumaNaVyzbieranie = peniaze.ToString();

                    (App.Current as App).ListZbieranychPenazi[(App.Current as App).KtoreZberanieBudeUpravené.indexZberu] = (App.Current as App).KtoreZberanieBudeUpravené;
                    this.Frame.Navigate(typeof(Zberanie_peňazí));

                }

            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

    }
}
