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

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._2___Platba
{
    //TODO: dokončiť to aby so struct bol array a aby sa to ukladalo do globálnej premenej

    public partial class Platba : Page
    {
        public double celkovaSuma;
        public double vlozenaSuma;
        public int Progress;
        
        public uint HlavnaSuma = (App.Current as App).hlavnáSuma;

        public struct InfoOplatbe
        {
            public uint PlatenáSuma;
            public string MenoPríjemcu;
            public string IBANPríjemcu;
            public string DátumSplatnosti;
            public int ZakéhoUčtuPojduPeniaze;
        }

        public Platba()
        {
            this.InitializeComponent();
            ZakehoUčtuPojduPeniaze.SelectedIndex = 0;
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

        public InfoOplatbe DoDočasnejPremenej()
        {
            InfoOplatbe i;
            try
            {
                i.PlatenáSuma = Convert.ToUInt32(Suma.Text);
            }
            catch (System.FormatException)
            {
                i.PlatenáSuma = 0;
            }
            i.MenoPríjemcu = KomuPôjduPeniaze.Text;
            i.IBANPríjemcu = IBAN.Text;
            if(DnesnyDatumSplatnosti.IsOn)
            {
                i.DátumSplatnosti = DateTime.Now.ToString("d");
            }
            else 
            {
                i.DátumSplatnosti = DátumSplatnosti.Date.ToString("d");
            }
            i.ZakéhoUčtuPojduPeniaze = ZakehoUčtuPojduPeniaze.SelectedIndex;
            return i;
        }

        public InfoOplatbe GlobalPremena;

        public void Pokračovať_Click(object sender, RoutedEventArgs e)
        {
           
           
            GlobalPremena = DoDočasnejPremenej();
            if (
                string.IsNullOrEmpty(GlobalPremena.PlatenáSuma.ToString()) ||
                string.IsNullOrEmpty(GlobalPremena.MenoPríjemcu)||
                string.IsNullOrEmpty(GlobalPremena.IBANPríjemcu) ||
                string.IsNullOrEmpty(GlobalPremena.DátumSplatnosti) ||
                string.IsNullOrEmpty(GlobalPremena.ZakéhoUčtuPojduPeniaze.ToString())
                )
            {
                var msg = new MessageDialog("Neboli zadané všetky údaje", "Platba bola nebola úspešná");
                msg.ShowAsync();
                this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie.HlavnaStranaUčtu));
            }
            else
            {
                uint DoterajšíZostatok;
                DoterajšíZostatok = (App.Current as App).hlavnáSuma;
                if (GlobalPremena.ZakéhoUčtuPojduPeniaze == 0)
                {

                    if (DoterajšíZostatok < GlobalPremena.PlatenáSuma)
                    {

                        var msg1 = new MessageDialog("Nemáte dostatok prostriedkov v triednom fonde", "Platba bola nebola úspešná");
                        msg1.ShowAsync();
                        this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie.HlavnaStranaUčtu));

                    }
                    else
                    {
                        HlavnaSuma = HlavnaSuma - GlobalPremena.PlatenáSuma;
                        (App.Current as App).hlavnáSuma = HlavnaSuma;
                        (App.Current as App).NahranieIndexuAkcie(1);
                        DoGlobálnejPremenéj(GlobalPremena);
                        GridSAnimaciou.Visibility = Visibility.Visible;
                        (App.Current as App).PrehranieAnimacieANavigovanieNaStranu(AnimáciaNaSpustenie, typeof(HlavnaStranaUčtu),this);
                        (App.Current as App).NahranieTextuDoHistorie(GlobalPremena);
                    }
                }
                else if (GlobalPremena.ZakéhoUčtuPojduPeniaze == 1)
                {
                    if ((App.Current as App).SumaNaSporeniePriVytvoreniu == 0 ||
                    string.IsNullOrEmpty((App.Current as App).DatumUkonceniaSporeniaPriVytvoreniu)
                    )

                    {
                        this.Frame.Navigate(typeof(Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._4___Sporenie._2._4._1___Pridať_sporenie.VytvorenieSporenia));

                        var msg = new MessageDialog("Prosím, vytvorte si ho teraz", "Sporenie nieje vytvorené");
                        msg.ShowAsync();
                    }
                    else
                    {
                        if ((App.Current as App).SumaNaSporenie < GlobalPremena.PlatenáSuma)
                        {
                            var msg2 = new MessageDialog("Platba z účtu sporenia na stuškovu neuspešná", "Na učte kam sa sporí na stuškovú nieje dostatok prostriedkov");
                            this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie.HlavnaStranaUčtu));
                        }
                        else
                        {
                            (App.Current as App).SumaNaSporenie = (App.Current as App).SumaNaSporenie - GlobalPremena.PlatenáSuma;

                            celkovaSuma = Convert.ToDouble((App.Current as App).SumaNaSporeniePriVytvoreniu);
                            vlozenaSuma = Convert.ToDouble((App.Current as App).SumaNaSporenie);

                            Progress = Convert.ToInt32((vlozenaSuma / celkovaSuma) * 100);
                            (App.Current as App).ProgressSporenie = Progress;

                            GridSAnimaciou.Visibility = Visibility.Visible;
                            (App.Current as App).PrehranieAnimacieANavigovanieNaStranu(AnimáciaNaSpustenie, typeof(HlavnaStranaUčtu), this);

                            (App.Current as App).NahranieIndexuAkcie(3);
                            (App.Current as App).NahranieTextuDoHistorie(GlobalPremena);
                        }
                    }
                }

            } 

        }

        


        private void Naspäť_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie.HlavnaStranaUčtu));
        }

        private void ZmenaSumy(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        public void DoGlobálnejPremenéj(InfoOplatbe temp)
        {
            for (int b = 0; b < 1; b++)
            { 
                (App.Current as App).GlobálnaPremenaOPlatbe[b].PlatenáSuma = temp.PlatenáSuma;
                (App.Current as App).GlobálnaPremenaOPlatbe[b].MenoPríjemcu = temp.MenoPríjemcu;
                (App.Current as App).GlobálnaPremenaOPlatbe[b].IBANPríjemcu = temp.IBANPríjemcu;
                (App.Current as App).GlobálnaPremenaOPlatbe[b].DátumSplatnosti = temp.DátumSplatnosti;
            }
        }

        
    }
}
