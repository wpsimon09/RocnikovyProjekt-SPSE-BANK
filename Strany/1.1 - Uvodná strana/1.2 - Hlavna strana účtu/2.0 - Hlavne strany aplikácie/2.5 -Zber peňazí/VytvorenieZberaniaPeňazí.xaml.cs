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
        public VytvorenieZberaniaPeňazí()
        {
            this.InitializeComponent();
        }

        public struct VyzbieranePeniaze
        {
            public string NázovZberania;
            public uint SumaNaVyzbieranie;
            public string DátumDoKedySaMaVyzbirať;
        }

        public VyzbieranePeniaze [] vyzbieranePeniaze_l = new VyzbieranePeniaze [3];

        private void CielenaSuma_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void Naspäť_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Zberanie_peňazí));
        }

        private void Pokračovať_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CielenaSuma.Text) || string.IsNullOrEmpty(DôvodSporenia.Text) || UkoncenieSporenia == null)
            {
                var msg = new MessageDialog("Niesu vyplnené všetky údaje", "Vytvorenie zlyhalo");
                msg.ShowAsync();
            }
            else
            {
                switch ((App.Current as App).NaKtoréZberanieSaKliklo)
                {
                    case 1:
                        {
                            vyzbieranePeniaze_l[0] = DoLocalnejPremennej();
                            DoGlobálnejPremennej(0, vyzbieranePeniaze_l);
                            break;
                        }
                    case 2:
                        {
                            vyzbieranePeniaze_l[1] = DoLocalnejPremennej();
                            DoGlobálnejPremennej(1, vyzbieranePeniaze_l);
                            break;
                        }

                }
                this.Frame.Navigate(typeof(Zberanie_peňazí));
            }
        }

        public void DoGlobálnejPremennej(int index, VyzbieranePeniaze [] localPremena)
        {
            (App.Current as App).GlobalnaPremenaVytvorenieZberania[index].NázovZberania = localPremena[index].NázovZberania;
            (App.Current as App).GlobalnaPremenaVytvorenieZberania[index].SumaNaVyzbieranie = localPremena[index].SumaNaVyzbieranie;
            (App.Current as App).GlobalnaPremenaVytvorenieZberania[index].DátumDoKedySaMaVyzbirať = localPremena[index].DátumDoKedySaMaVyzbirať;
        }

        public VyzbieranePeniaze DoLocalnejPremennej()
        {
            VyzbieranePeniaze vyzbieranePeniaze;

            try
            {
                vyzbieranePeniaze.SumaNaVyzbieranie = Convert.ToUInt32(CielenaSuma.Text);
                vyzbieranePeniaze.NázovZberania = DôvodSporenia.Text;
                vyzbieranePeniaze.DátumDoKedySaMaVyzbirať = UkoncenieSporenia.Date.Value.DateTime.ToString("d");
                return vyzbieranePeniaze;

            }
            catch(System.InvalidOperationException)
            {
                vyzbieranePeniaze.SumaNaVyzbieranie = 0;
                vyzbieranePeniaze.NázovZberania = "null";
                vyzbieranePeniaze.DátumDoKedySaMaVyzbirať = "null";
                return vyzbieranePeniaze;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            switch((App.Current as App).KtoreZberanieBudeUpravené)
            {
                case 1:
                    {
                        NahranieHôdnôtKtoréSaIdúUpraviť(0, (App.Current as App).GlobalnaPremenaVytvorenieZberania);
                        break;
                    }
                case 2:
                    {
                        NahranieHôdnôtKtoréSaIdúUpraviť(1, (App.Current as App).GlobalnaPremenaVytvorenieZberania);
                        break;
                    }
            }
        }

        public void NahranieHôdnôtKtoréSaIdúUpraviť(int index, VyzbieranePeniaze[] vyzbieranePeniazes)
        {
            try
            {
                CielenaSuma.Text = vyzbieranePeniazes[index].SumaNaVyzbieranie.ToString();
                DôvodSporenia.Text = vyzbieranePeniazes[index].NázovZberania;
                UkoncenieSporenia.Date = Convert.ToDateTime(vyzbieranePeniazes[index].DátumDoKedySaMaVyzbirať);
            }
            catch(ArgumentNullException)
            {

            }
            catch(ArgumentOutOfRangeException)
            {

            }


        }


    }
}
