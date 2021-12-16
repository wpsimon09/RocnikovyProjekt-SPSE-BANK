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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._5__Zber_peňazí
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HlavnaStranaZberaniaPeňazí : Page
    {
        public HlavnaStranaZberaniaPeňazí()
        {
            this.InitializeComponent();
        }
        //Convert.ToInt32((App.Current as App).GlobálnaPremenaInfaTriedy.PocetZiakov)
        public string[] MenaŽiakov = new string[4];
        public string [] ŽiaciKtoryZaplatili = new string[Convert.ToInt32((App.Current as App).GlobálnaPremenaInfaTriedy.PocetZiakov)];
        public VytvorenieZberaniaPeňazí.VyzbieranePeniaze [] InfoOvyzbieranychPeniazoch = new VytvorenieZberaniaPeňazí.VyzbieranePeniaze[3];
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MenaŽiakov[0] = "Jessica";
            MenaŽiakov[1] = "Šimon";
            MenaŽiakov[2] = "Rijak";
            MenaŽiakov[3] = "Tobiaš";
            Array.Sort(MenaŽiakov);

           
       
            switch((App.Current as App).NaKtoréZberanieSaKliklo)
            {
                case 1:
                    {
                        InfoOvyzbieranychPeniazoch[0] = (App.Current as App).GlobalnaPremenaVytvorenieZberania[0];
                        Nadpis.Text = $"{InfoOvyzbieranychPeniazoch[0].NázovZberania}"; 
                        //MenaŽiakov = (App.Current as App).Menažiakov;
                        Array.Sort(MenaŽiakov);
                        Nezaplatili.ItemsSource = MenaŽiakov;
                        break;
                    }
                case 2:
                    {
                        InfoOvyzbieranychPeniazoch[1] = (App.Current as App).GlobalnaPremenaVytvorenieZberania[1];
                        Nadpis.Text = $"{InfoOvyzbieranychPeniazoch[1].NázovZberania}";
                        //MenaŽiakov = (App.Current as App).Menažiakov;
                        Array.Sort(MenaŽiakov);
                        Nezaplatili.ItemsSource = MenaŽiakov;
                        break;
                    }
                case 3:
                    {
                        InfoOvyzbieranychPeniazoch[2] = (App.Current as App).GlobalnaPremenaVytvorenieZberania[2];
                        Nadpis.Text = $"{InfoOvyzbieranychPeniazoch[2].NázovZberania}";
                       // MenaŽiakov = (App.Current as App).Menažiakov;
                        Array.Sort(MenaŽiakov);
                        Nezaplatili.ItemsSource = MenaŽiakov;
                        break;
                    }
            }
            
            Nezaplatili.ItemsSource = MenaŽiakov;

        }

        private void Naspäť_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Zberanie_peňazí));
        }

        private void Nezaplatili_ItemClick(object sender, ItemClickEventArgs e)
        {
            nd = Nezaplatili.SelectedItems.Count();
        }

        public int nd;
        public int index;

        private void TlacidloNaVykliknutie_Checked(object sender, RoutedEventArgs e)
        {
                   
        }

        private void Nezaplatili_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nd = Nezaplatili.SelectedItems.Count();
            PocetZaplatených.Text = $"Zaplatilo: {nd}/4";   
        }

    }

}
