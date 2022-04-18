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
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._1___Pridanie_peňazí;
using Ročňíkový_projekt___Aplikácia_pre_banku.Správy;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._1___Pridanie_peňazí
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PridaniePeňazí : Page
    {
        public PlatobnySystem platobnysystem { get; set; }
        public PridaniePeňazí()
        {
            platobnysystem = (App.Current as App).PlatobnySistem;
            this.InitializeComponent();
            KamPôjduPeniaze.SelectedIndex = 1;

        }

        private void KamPôjduPeniaze_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(KamPôjduPeniaze.SelectedIndex == 1)
            {
                OdKohoPrisli.IsEnabled = false;
            }
            else
            {
                OdKohoPrisli.IsEnabled = true;
            }
        }

        private async void Pokračovať_Click(object sender, RoutedEventArgs e)
        {
            if(KontrolaÚdajov())
            {
                platobnysystem.InkasovanaSuma = Convert.ToDouble(VloženáSuma.Text);
                if (platobnysystem.KamPojduPeniaze == 0)
                {
                    platobnysystem.Update();
                    platobnysystem.InkasoNaBeznyUcet();
                    this.Frame.Navigate(typeof(HlavnaStranaUčtu));
          
                }
                else if (platobnysystem.KamPojduPeniaze == 1)
                {

                    var OdCiarknutieZiaka = new SporenieNaStužkovú(); //vytvorý novy instance of message dialog 
                    OdCiarknutieZiaka.Suma = Convert.ToDouble(VloženáSuma.Text); //nahrá hodnoty do premenej suma, ktorá sa nachádza v message dialogu
                    await OdCiarknutieZiaka.ShowAsync();
                    this.Frame.Navigate(typeof(HlavnaStranaUčtu));
                }
            }
            else
            {
                var msg = new MessageDialog("Prosím vyplne všetky potrebné údaje", "Nevyplnene údajé");
                await msg.ShowAsync();
            }
            
        }

        private void Naspäť_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HlavnaStranaUčtu));
        }

        private void VloženáSuma_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {

        }

        public bool KontrolaÚdajov()
        {
            bool vysledok = new bool();
            foreach (TextBox txt in StackPanelSFormulárom.Children)
            {
                if (txt.Text != string.Empty)
                {
                    vysledok = true;
                }
                else
                {
                    vysledok = false;
                }
                return vysledok;
            }
            return vysledok;
            
        }
    }
}
