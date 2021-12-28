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
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }
        
        //Convert.ToInt32((App.Current as App).GlobálnaPremenaInfaTriedy.PocetZiakov)
        public string[] MenaŽiakov = new string[4];
        public string [] ŽiaciKtoryZaplatili = new string[Convert.ToInt32((App.Current as App).GlobálnaPremenaInfaTriedy.PocetZiakov)];
        public VytvorenieZberaniaPeňazí.VyzbieranePeniaze [] InfoOvyzbieranychPeniazoch = new VytvorenieZberaniaPeňazí.VyzbieranePeniaze[3];
        public double [] CelkovaSuma = new double[3];
        public double [] ZaplatenaSuma = new double[3];
        public double [] KolkoMaKazdyZaplatiť = new double [3];
        public ListView [] TempListView = new ListView [3];
        public CacheMode[] cacheModes = new CacheMode[2];
        DependencyProperty[] dependencyProperties = new DependencyProperty[2];

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
       

            
            switch((App.Current as App).NaKtoréZberanieSaKliklo)
            {
                case 1:
                    {

                        MenaŽiakov = (App.Current as App).Menažiakov;
                        Array.Sort(MenaŽiakov);

                        InfoOvyzbieranychPeniazoch[0] = (App.Current as App).GlobalnaPremenaVytvorenieZberania[0];
                        KolkoMaKazdyZaplatiť[0] = Convert.ToDouble(Convert.ToDouble(InfoOvyzbieranychPeniazoch[0].SumaNaVyzbieranie )/ Convert.ToDouble((App.Current as App).GlobálnaPremenaInfaTriedy.PocetZiakov) );       //(App.Current as App).GlobálnaPremenaInfaTriedy.PocetZiakov
                        Nadpis.Text = $"{InfoOvyzbieranychPeniazoch[0].NázovZberania}";

                        Nezaplatili.ItemsSource = MenaŽiakov;
                        break;
                    }
                case 2:
                    {
                        MenaŽiakov = (App.Current as App).Menažiakov;
                        Array.Sort(MenaŽiakov);

                       
                        InfoOvyzbieranychPeniazoch[1] = (App.Current as App).GlobalnaPremenaVytvorenieZberania[1];
                        Nadpis.Text = $"{InfoOvyzbieranychPeniazoch[1].NázovZberania}";
                        KolkoMaKazdyZaplatiť[1] = Convert.ToDouble(Convert.ToDouble(InfoOvyzbieranychPeniazoch[1].SumaNaVyzbieranie) / Convert.ToDouble((App.Current as App).GlobálnaPremenaInfaTriedy.PocetZiakov));       //(App.Current as App).GlobálnaPremenaInfaTriedy.PocetZiakov

                        Nezaplatili.ItemsSource = MenaŽiakov;
                        break;
                    }
            }
            
            Nezaplatili.ItemsSource = MenaŽiakov;

        }

        private void Naspäť_Click(object sender, RoutedEventArgs e)
        {         
            this.Frame.Navigate(typeof(Zberanie_peňazí));
            switch ((App.Current as App).NaKtoréZberanieSaKliklo)
            {
                case 1:
                    {
                        /*
                         dependencyProperties[0].GetMetadata(Nezaplatili.GetType());
                        cacheModes[0].SetValue(dependencyProperties[0],Nezaplatili);
                        break;
                        */
                        break;


                    }
                case 2:
                    {
                        /*
                        dependencyProperties[0].GetMetadata(Nezaplatili.GetType());
                        cacheModes[1].ReadLocalValue(dependencyProperties[1]);
                        break;
                        */
                        break;
                    }
            }
        }


        public int nd;
        public int index;
        public int[,] SelctnuteIndexy = new int[3,4];


        private void Nezaplatili_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nd = Nezaplatili.SelectedItems.Count();
            PocetZaplatených.Text = $"Zaplatilo: {nd}/{(App.Current as App).GlobálnaPremenaInfaTriedy.PocetZiakov}";
            
            double KolkoSaVyzbieralo = new double();

            switch ((App.Current as App).NaKtoréZberanieSaKliklo)
            {
                case 1:
                    {
                        //TempListView[0].SelectedValue = Nezaplatili.SelectedValuePath;
                        KolkoSaVyzbieralo = (KolkoSaVyzbieralo + KolkoMaKazdyZaplatiť[0]) * nd;
                        KtoVaetkoZaplatil1.Text = $"{KolkoSaVyzbieralo} / {InfoOvyzbieranychPeniazoch[0].SumaNaVyzbieranie} €";
                        DosiahnutyGoal.Value = Convert.ToInt32((KolkoSaVyzbieralo / InfoOvyzbieranychPeniazoch[0].SumaNaVyzbieranie) * 100);
                        (App.Current as App).ProgressZberania[0] = DosiahnutyGoal.Value;
                        (App.Current as App).KolkoSaZatialVyzbieralo[0] = KolkoSaVyzbieralo;
                        //dependencyProperties[0].GetMetadata(Nezaplatili.SelectedItems.GetType());
                        //cacheModes[0].GetValue(dependencyProperties[0]);
                        break;
                    }
                case 2:
                    {
                        //TempListView[1].SelectedValue = Nezaplatili.SelectedValuePath;
                        KolkoSaVyzbieralo = (KolkoSaVyzbieralo + KolkoMaKazdyZaplatiť[1]) * nd;
                        KtoVaetkoZaplatil1.Text = $"{KolkoSaVyzbieralo} / {InfoOvyzbieranychPeniazoch[1].SumaNaVyzbieranie} €";
                        DosiahnutyGoal.Value = Convert.ToInt32((KolkoSaVyzbieralo / InfoOvyzbieranychPeniazoch[1].SumaNaVyzbieranie) *100);
                        (App.Current as App).ProgressZberania[1] = DosiahnutyGoal.Value;
                        (App.Current as App).KolkoSaZatialVyzbieralo[1] = KolkoSaVyzbieralo;

                        break;
                    }
            }

            if(DosiahnutyGoal.Value == 100)
            {
                UkončenieZberania.IsEnabled = true;
            }
            else
            {
                UkončenieZberania.IsEnabled = false;
            }
        }

        public void NahratieInfoDoListView (int index,ListView []temp, ListView pôvodnyListView)
        {

            try
            {
                pôvodnyListView.SelectedValue = temp[index].SelectedValuePath;
            }
            catch(System.NullReferenceException)
            {

            }
        }

        public void NahranieInfo(TextBlock Nadpis, TextBlock KtoVšetkoZaplatil, TextBlock PocetZaplatených)
        {

        }

        private void UkončenieZberania_Click(object sender, RoutedEventArgs e)
        {
            switch ((App.Current as App).NaKtoréZberanieSaKliklo)
            {
                case 1:
                    {
                        (App.Current as App).KtoreZberanieJeUžHotove= 1;
                        (App.Current as App).NahranieTextuDoHistorie((App.Current as App).GlobalnaPremenaVytvorenieZberania[0]);
                        (App.Current as App).hlavnáSuma = (App.Current as App).hlavnáSuma + InfoOvyzbieranychPeniazoch[0].SumaNaVyzbieranie;
                        break;
                    }
                case 2:
                    {
                        (App.Current as App).NahranieTextuDoHistorie((App.Current as App).GlobalnaPremenaVytvorenieZberania[0]); ;
                        (App.Current as App).KtoreZberanieJeUžHotove = 2;
                        (App.Current as App).hlavnáSuma = (App.Current as App).hlavnáSuma + InfoOvyzbieranychPeniazoch[1].SumaNaVyzbieranie;
                        break;
                    }
            }
            (App.Current as App).NahranieIndexuAkcie(5);
            
            this.Frame.Navigate(typeof(Zberanie_peňazí));
        }

        



    }
}
