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
        public VytvorenieSporenia()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }
        public struct InfoOsporeniNaStuzkovu
        {
            public uint CielovaSuma;
            public string DatumUkoncenia;
        }

        public InfoOsporeniNaStuzkovu DocasnaPremena;

        public InfoOsporeniNaStuzkovu DoDocasnejPremene()
        {
            InfoOsporeniNaStuzkovu temp;

            temp.CielovaSuma = Convert.ToUInt32(CielenaSuma.Text);
            temp.DatumUkoncenia = UkoncenieSporenia.Date.Value.DateTime.ToString("d");

            return temp;
        }


        private void Pokračovať_Click(object sender, RoutedEventArgs e)
        {
            InfoOsporeniNaStuzkovu DocasnaPremena = new InfoOsporeniNaStuzkovu();
            DocasnaPremena = DoDocasnejPremene();
            if (string.IsNullOrEmpty(CielenaSuma.Text) ||
                string.IsNullOrEmpty(DocasnaPremena.DatumUkoncenia)
                )
            {
                var msg = new MessageDialog("Neboli zadané všetky údaje", "Sporenie nebolo upravené/vytvorené");
                msg.ShowAsync();
            }
            else
            {
                DoGlobalnejPremenej(DocasnaPremena);
                this.Frame.Navigate(typeof(SporenieNaStužkovú));
            }
        }

        public void DoGlobalnejPremenej(InfoOsporeniNaStuzkovu temp)
        {
            (App.Current as App).SumaNaSporeniePriVytvoreniu = temp.CielovaSuma;
            (App.Current as App).DatumUkonceniaSporeniaPriVytvoreniu = temp.DatumUkoncenia;

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
