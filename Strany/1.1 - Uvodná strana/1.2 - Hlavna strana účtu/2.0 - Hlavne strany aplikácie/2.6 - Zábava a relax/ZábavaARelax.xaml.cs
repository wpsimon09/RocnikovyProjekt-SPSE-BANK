using System;
using System.Diagnostics;
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
using Ročňíkový_projekt___Aplikácia_pre_banku.Správy;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._6___Zábava_a_relax
{

    public sealed partial class ZábavaARelax : Page
    {
        Hra hra;
        Stopwatch stopky;
        TimeSpan casNajdenia;
        public int pocetNajdenychObrazkov { get; set; }
        public ZábavaARelax()
        {
            casNajdenia = new TimeSpan();
            stopky = new Stopwatch();
            hra = (App.Current as App).GlobalNaPremenaHry;
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            hra.VygenerovanieHodnotPreRozmiestnenie();
            OznámenieOHre oznam = new OznámenieOHre();
            await oznam.ShowAsync();
            stopky.Start();
        }

        private void Naspat_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie.HlavnaStranaUčtu));
        }

        private async void Obrazok1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            hra.SkrytieObrazku(sender as Image);
            pocetNajdenychObrazkov++;
            if (pocetNajdenychObrazkov >=4)
            {
                stopky.Stop();
                casNajdenia = stopky.Elapsed;
                hra.PorovnanieANahranieNajlepsichCasov(casNajdenia);
                stopky.Reset();
                (App.Current as App).GlobalNaPremenaHry = hra;
                UkoncenieHry vysledky = new UkoncenieHry();
                await vysledky.ShowAsync();
            }
        }
    }
}
