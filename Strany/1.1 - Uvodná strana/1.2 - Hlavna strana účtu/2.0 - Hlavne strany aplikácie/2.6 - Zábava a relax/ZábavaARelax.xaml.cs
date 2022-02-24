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
using System.ComponentModel;
using System.Runtime.CompilerServices;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._6___Zábava_a_relax
{

    public sealed partial class ZábavaARelax : Page,INotifyPropertyChanged
    {
        Hra hra;
        Stopwatch stopky;
        DispatcherTimer timer;
        TimeSpan HodnotaCasovacu;

        private string _cas;
        public string cas
        {
            get
            {
                return _cas;
                OnPropertyChanged();
            }
            set 
            {
                _cas = value;
                OnPropertyChanged();
            }
        }
        TimeSpan casNajdenia;
        bool UkoncenieStopiek = false;
        public int pocetNajdenychObrazkov { get; set; }
        
        public ZábavaARelax()
        {
            casNajdenia = new TimeSpan();
            stopky = new Stopwatch();
            hra = (App.Current as App).GlobalNaPremenaHry;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += Timer_Tick;

            this.InitializeComponent();
        }

        private void Timer_Tick(object sender, object e)
        {
            HodnotaCasovacu = HodnotaCasovacu + timer.Interval;
            Casovac.Text = HodnotaCasovacu.ToString();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            hra.VygenerovanieHodnotPreRozmiestnenie();
            OznámenieOHre oznam = new OznámenieOHre();
            await oznam.ShowAsync();
            stopky.Start();
            timer.Start();
        }

        private void Naspat_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie.HlavnaStranaUčtu));
        }

        private async void Obrazok1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Image tempObrazok;
            string meno;

            tempObrazok = sender as Image;
            meno = tempObrazok.Name;

            switch (meno)
            {
                case "Obrazok1":
                    {
                        obr1.IsChecked = true;
                        break;
                    }
                case "Obrazok2":
                    {
                        obr2.IsChecked = true;
                        break;
                    }
                case "Obrazok3":
                    {
                        obr3.IsChecked = true;
                        break;
                    }
                case "Obrazok4":
                    {
                        obr4.IsChecked = true;
                        break;
                    }

            }


            hra.SkrytieObrazku(tempObrazok);
            pocetNajdenychObrazkov++;

            if (pocetNajdenychObrazkov >=4)
            {
                stopky.Stop();
                casNajdenia = stopky.Elapsed;

                TimeSpan[] najlepsieCasi = hra.PorovnanieANahranieNajlepsichCasov(casNajdenia);
                
                cas1.Text = najlepsieCasi[0].ToString();
                cas2.Text = najlepsieCasi[1].ToString();
                cas3.Text = najlepsieCasi[2].ToString();

                stopky.Reset();
                timer.Stop();
                (App.Current as App).GlobalNaPremenaHry = hra;
                UkoncenieHry vysledky = new UkoncenieHry();
                await vysledky.ShowAsync();
            }
           

           
        }
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void Reload_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            (App.Current as App).PrehranieAnimacieANavigovanieNaStranu(ReloadAnimacia, typeof(ZábavaARelax), this);
        }

        private void Reload_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);

        }

        private void Reload_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 2);
        }
    }
}
