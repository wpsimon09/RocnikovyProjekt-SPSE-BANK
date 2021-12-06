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
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._2___Platba;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._1___Pridanie_peňazí;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._3___Historia_platieb
{
   
    public sealed partial class HistoriaPlatieb : Page
    {
        
        public HistoriaPlatieb()
        {           
            this.InitializeComponent();
          
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {


            for (int i = 0; i < 100; i++)
            {
                if((App.Current as App).indexAkcie[i]!=0)
                {
                    switch ((App.Current as App).indexAkcie[i])
                    {
                        case 1:
                            {
                                vykonanáplatba();
                                break;
                            }
                        case 2:
                            {

                                prijatáplatba();
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                } 
                else if((App.Current as App).indexAkcie[i] == 0)
                {
                    break;
                }
            }
        }

         

        public TextBlock[] PrijatePeniaze = new TextBlock[100];
        public TextBlock[] OdoslanaPlatba = new TextBlock[100];

        private void vykonanáplatba()
        {
            
            for(int c = 0; c<100; c++)
            {
                if((App.Current as App).GlobálnaPremenaOPlatbe[c].PlatenáSuma== Convert.ToUInt32(0))
                {
                    break;
                }
                else
                {
                    OdoslanaPlatba[c].Text = $" - {(App.Current as App).GlobálnaPremenaOPlatbe[c].PlatenáSuma} pre {(App.Current as App).GlobálnaPremenaOPlatbe[c].MenoPríjemcu} ";
                    OdoslanaPlatba[c].Style = (Style)RootLayout.Resources["OdoslanáPlatba"];
                    RootLayout.Children.Add(OdoslanaPlatba[c]);
                } 
            }
        }

        private void prijatáplatba()
        {
            for (int b = 0; b < 100; b++)
            {
                //convertnuť zo string na uint mozno sa nebrakne
                if((App.Current as App).GlobálnaPremenáInfaOPridanýchPeniazoch[b].suma == Convert.ToUInt32(0))
                {
                    break;
                }
                else
                {
                    PrijatePeniaze[b].Text = $" + {(App.Current as App).GlobálnaPremenáInfaOPridanýchPeniazoch[b].suma}";
                    PrijatePeniaze[b].Style = (Style)RootLayout.Resources["PrijatáPlatba"];
                    RootLayout.Children.Add(PrijatePeniaze[b]);
                }
            }
            



        }

        private void Naspäť_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie.HlavnaStranaUčtu));
           
        }
    }
 
}
