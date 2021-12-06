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

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._4___Sporenie
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SporenieNaStužkovú : Page
    {

        public SporenieNaStužkovú()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        

            if ((App.Current as App).SumaNaSporeniePriVytvoreniu == 0 ||
                string.IsNullOrEmpty((App.Current as App).DatumUkonceniaSporeniaPriVytvoreniu)
                )
            {
                this.Frame.Navigate(typeof(_4___Sporenie._2._4._1___Pridať_sporenie.VytvorenieSporenia));
                var msg = new MessageDialog("Prosím, vytvorte si ho teraz", "Sporenie nieje vytvorené");
                msg.ShowAsync();
            }
            else
            {
                CielEura.Text = $"{(App.Current as App).SumaNaSporenie} € z {(App.Current as App).SumaNaSporeniePriVytvoreniu}";
                Dátum.Text = $"Do {(App.Current as App).DatumUkonceniaSporeniaPriVytvoreniu}";
                DosiahnutyGoal.Value = (App.Current as App).ProgressSporenie;
            }
        }

        private void Naspäť_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie.HlavnaStranaUčtu));

        }

        private void Pridať_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._1___Pridanie_peňazí.PridaniePeňazí));
        }

        private void Zaplatiť_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(_0___Hlavne_strany_aplikácie._2._2___Platba.Platba));
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Frame.Navigate(typeof(_4___Sporenie._2._4._1___Pridať_sporenie.VytvorenieSporenia));
        }

        
    }
}
