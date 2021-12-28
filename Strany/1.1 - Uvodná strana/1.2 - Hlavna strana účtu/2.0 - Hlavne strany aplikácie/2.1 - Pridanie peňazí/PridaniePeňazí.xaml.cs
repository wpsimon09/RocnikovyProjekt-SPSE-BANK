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
using System.Threading;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._1___Pridanie_peňazí
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PridaniePeňazí : Page
    {
        
        public PridaniePeňazí()
        {
            this.InitializeComponent();
            KamPôjduPeniaze.SelectedIndex = 0;
        }
        public double vlozenaCena;
        public double celkovaSuma;
        public int Progress;
        public uint CelkováSuma = (App.Current as App).hlavnáSuma;

        public struct InfoOPridanýchPeniazoch
        {
            public uint suma;
            public int KamSaPeniazeUlozia;
        }

        InfoOPridanýchPeniazoch ZískanieInfa()
        {
            InfoOPridanýchPeniazoch info;
            try
            {
                info.suma = Convert.ToUInt32(VloženáSuma.Text);
                info.KamSaPeniazeUlozia = KamPôjduPeniaze.SelectedIndex;
                return info;
            }
            catch(FormatException)
            {
               
            }
            finally
            {
                info.suma = 0;
                info.KamSaPeniazeUlozia = -1;
                
            }
            return info;


        }

        public InfoOPridanýchPeniazoch DočasnáPremenáPridanýchPeniazoch;
       
        
        private void Pokračovať_Click(object sender, RoutedEventArgs e)
        {
            DočasnáPremenáPridanýchPeniazoch = ZískanieInfa();
            
            
                
            if (DočasnáPremenáPridanýchPeniazoch.suma == 0||
               DočasnáPremenáPridanýchPeniazoch.KamSaPeniazeUlozia == -1) //pokial niesu vypísané všetky údaje

            {

                var msg = new MessageDialog("Pridanie peňaz neúspešné", "Neboli zadané všetky údaje");
                msg.ShowAsync();
                this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie.HlavnaStranaUčtu));
            }
            else //ak sú všetky údaje vypísané
            {
                if(DočasnáPremenáPridanýchPeniazoch.KamSaPeniazeUlozia==0 )
                {
                    GridSAnimaciou.Visibility = Visibility.Visible;
                    
                    (App.Current as App).PrehranieAnimacieANavigovanieNaStranu(AnimáciaNaSpustenie, typeof(HlavnaStranaUčtu), this);
                    
                    StoryBoard.Begin();
                    
                    CelkováSuma = CelkováSuma + DočasnáPremenáPridanýchPeniazoch.suma;
                    
                    (App.Current as App).hlavnáSuma = CelkováSuma;
                    (App.Current as App).NahranieIndexuAkcie(2);
                    (App.Current as App).NahranieTextuDoHistorie(DočasnáPremenáPridanýchPeniazoch);
                }
                else if(DočasnáPremenáPridanýchPeniazoch.KamSaPeniazeUlozia==1)
                {
                    if ((App.Current as App).SumaNaSporeniePriVytvoreniu == 0 ||
                        string.IsNullOrEmpty((App.Current as App).DatumUkonceniaSporeniaPriVytvoreniu)
                        )
                    {
                        var msg = new MessageDialog("Prosím, vytvorte si ho teraz", "Sporenie nieje vytvorené");
                        msg.ShowAsync();
                        this.Frame.Navigate(typeof(Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._4___Sporenie._2._4._1___Pridať_sporenie.VytvorenieSporenia));

                    }
                    else
                    {
                        if ((App.Current as App).SumaNaSporenie >= (App.Current as App).SumaNaSporeniePriVytvoreniu)
                        {
                            var msg1 = new MessageDialog("Vyzbierali ste všetky prostriedky na sporenie, sporenie si môžte upraviť", "Sporenie dosiahnuté");
                            msg1.ShowAsync();
                            this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie.HlavnaStranaUčtu));
                        }
                        else
                        {
                            GridSAnimaciou.Visibility = Visibility.Visible;
                            (App.Current as App).SumaNaSporenie = (App.Current as App).SumaNaSporenie + DočasnáPremenáPridanýchPeniazoch.suma;
                            (App.Current as App).PrehranieAnimacieANavigovanieNaStranu(AnimáciaNaSpustenie, typeof(HlavnaStranaUčtu), this);
                            (App.Current as App).NahranieIndexuAkcie(4);
                            celkovaSuma = Convert.ToDouble((App.Current as App).SumaNaSporeniePriVytvoreniu);
                            vlozenaCena = Convert.ToDouble((App.Current as App).SumaNaSporenie);
                            Progress = Convert.ToInt32((vlozenaCena / celkovaSuma) * 100);
                            
                            (App.Current as App).ProgressSporenie = Progress;
                            (App.Current as App).NahranieTextuDoHistorie(DočasnáPremenáPridanýchPeniazoch);

                        }
                    }
                }
                DoGlobálnejPremenej(DočasnáPremenáPridanýchPeniazoch);
            }

        }

        private void VloženáSumaZmena(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void Naspäť_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie.HlavnaStranaUčtu));
        }

        public void DoGlobálnejPremenej(InfoOPridanýchPeniazoch temp)
        {
            for(int b = 0; b<1; b++)
            {
               (App.Current as App).GlobálnaPremenáInfaOPridanýchPeniazoch[b].suma = temp.suma;
               (App.Current as App).GlobálnaPremenáInfaOPridanýchPeniazoch[b].KamSaPeniazeUlozia = temp.KamSaPeniazeUlozia+1;       
            }
        }

       
    }
}
