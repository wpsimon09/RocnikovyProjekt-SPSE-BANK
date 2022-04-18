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

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._4___Sporenie._2._4._1___Pridať_sporenie
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VytvorenieSporenia : Page
    {
        Sporenie sporenie { get; set; }
        public VytvorenieSporenia()
        {
            this.InitializeComponent();
            sporenie = new Sporenie();
            
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void OnNavigatedTo(object sender,NavigationEventArgs e)
        {
            sporenie = (App.Current as App).GlobalSporenie;
        }

        private async void Pokračovať_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CielenaSuma.Text) ||
                UkoncenieSporenia.Date == null
                )
            {
                var msg = new MessageDialog("Neboli zadané všetky údaje", "Sporenie nebolo upravené/vytvorené");
                await msg.ShowAsync();
            }
            else
            {
                sporenie.DatumUkonceniaSporeniaPriVytvoreniu = UkoncenieSporenia.Date.Value.ToString("d");
                sporenie.CielenaSuma = Convert.ToDouble(CielenaSuma.Text);
                sporenie.BoloVytvorené = true;
                (App.Current as App).GlobalSporenie = sporenie;
                this.Frame.Navigate(typeof(SporenieNaStužkovú));
            }
        }



        private void CielenaSuma_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void Naspäť_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SporenieNaStužkovú));
        }
    }
}
