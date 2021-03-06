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
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._2___Platba
{
    //TODO: dokončiť to aby so struct bol array a aby sa to ukladalo do globálnej premenej

    public partial class Platba : Page
    {
        
        PlatobnySystem platobnySystem { get; set; }
        _4___Sporenie.Sporenie sporenie { get; set; }
        public Platba()
        {
            this.InitializeComponent();
            ZakehoUčtuPojduPeniaze.SelectedIndex = 0;
            platobnySystem = (App.Current as App).PlatobnySistem;
            sporenie = (App.Current as App).GlobalSporenie;
        }

        private void Toggled(object sender, RoutedEventArgs e)
        {
            if(DnesnyDatumSplatnosti.IsOn)
                try
                {
                DátumSplatnosti.Visibility = Visibility.Collapsed;

                }
                catch(System.NullReferenceException)
                {
                    
                }
            else 
            {
                try
                {
                    DátumSplatnosti.Visibility = Visibility.Visible;

                }
                catch (System.NullReferenceException)
                {

                }
            }
        }


        public async void Pokračovať_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(Suma.Text) ||
               string.IsNullOrEmpty(KomuPôjduPeniaze.Text) ||
               ZakehoUčtuPojduPeniaze.SelectedIndex == -1 ||
               string.IsNullOrEmpty(IBAN.Text))
            {
                var msg = new MessageDialog("Chýbajú zadané údaje", "Chyba");
                await msg.ShowAsync();
            }

            else
            {

                if (DnesnyDatumSplatnosti.IsOn)
                {
                    platobnySystem.DatumSplatnosti = DateTime.Now;
                }
                else
                {
                    platobnySystem.DatumSplatnosti = DátumSplatnosti.Date.DateTime;
                }

                if (ZakehoUčtuPojduPeniaze.SelectedIndex == 0)
                {

                    platobnySystem.PlatenaSuma = Convert.ToDouble(Suma.Text);
                    platobnySystem.MenoPrijemcu = KomuPôjduPeniaze.Text;
                    platobnySystem.Update();
                    if (platobnySystem.PlatbaZBeznehoUctu())
                    {
                        GridSAnimaciou.Visibility = Visibility.Visible;
                        (App.Current as App).PrehranieAnimacieANavigovanieNaStranu(AnimáciaNaSpustenie, typeof(HlavnaStranaUčtu), this as Page);
                    }
                    else
                    {
                        MessageDialog msg = new MessageDialog("Nemáte dostatok peňazí", "Platba nebola uspešná");
                        await msg.ShowAsync();
                        this.Frame.Navigate(typeof(HlavnaStranaUčtu));
                    }

                }
                else if (ZakehoUčtuPojduPeniaze.SelectedIndex == 1)
                {
                    if (sporenie.VykonatPlatbu(Convert.ToDouble(Suma.Text)))
                    {
                        sporenie.UpdateProgress();
                        GridSAnimaciou.Visibility = Visibility.Visible;
                        (App.Current as App).PrehranieAnimacieANavigovanieNaStranu(AnimáciaNaSpustenie, typeof(HlavnaStranaUčtu), this as Page);
                    }
                    else
                    {
                        var message = new MessageDialog("Platba nebola úspešná", "Na sporiacom účte nemáte dostatok financií");
                        await message.ShowAsync();
                    }
                }
            }
        }

        private void Naspäť_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HlavnaStranaUčtu));
        }

        private void ZmenaSumy(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }



        
    }
}
