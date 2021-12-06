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

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu._1._4___Overovacia_strana._1._5__Zadanie_žiako
{
    
    public sealed partial class ŽiaciVTriede : Page
    {
        public ŽiaciVTriede()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            (App.Current as App).boloNavigované = false;
        }

        public static int PocetŽiakov = Convert.ToInt32((App.Current as App).GlobálnaPremenaInfaTriedy.PocetZiakov);

       
        
        string[] MenoTextBoxu;
        TextBox[] temp = new TextBox[PocetŽiakov];
        TextBox[] textbox = new TextBox[PocetŽiakov];
        string[] žiaci = new string[PocetŽiakov];



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            if ((App.Current as App).boloNavigované == false)
            {
                MenoTextBoxu = new string[PocetŽiakov];
                

                for (int i = 0; i < PocetŽiakov; i++)
                {
                    textbox[i] = new TextBox();
                    textbox[i].Margin = new Thickness(20);
                    textbox[i].HorizontalAlignment = HorizontalAlignment.Left;
                    textbox[i].Style = (Style)StackovanieTextBoxov.Resources["TxtBox"];
                    textbox[i].Width = 500;
                    textbox[i].Header = $"Žiak v poradí č. {i + 1}";
                    textbox[i].Name = Convert.ToString(i);
                    StackovanieTextBoxov.Children.Add(textbox[i]);
                    
                }
                (App.Current as App).boloNavigované = true;
            }
            
        }

        private void Naspäť_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(Overenie_triednych_údajóv));
        }

        private void Vyčistiť_Click(object sender, RoutedEventArgs e)
        {
            for(int j = 0; j<PocetŽiakov; j ++)
            {
                textbox[j].Text = string.Empty;
            }
        }

        private void Hotovo_Click(object sender, RoutedEventArgs e)
        {
            bool VšetkoVyplnené = new bool();
            for (int a = 0; a < PocetŽiakov; a++)
            {
                if (string.IsNullOrEmpty(textbox[a].Text))
                {
                    VšetkoVyplnené = false;
                    break;
                }
                else
                {
                    VšetkoVyplnené = true;   
                }
                
            }
            if(VšetkoVyplnené == true)
            {
                (App.Current as App).Menažiakov = new string[PocetŽiakov];
                for (int b = 0; b<PocetŽiakov;b++)
                {
                    
                    (App.Current as App).Menažiakov[b] = textbox[b].Text;

                    }

                this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie.HlavnaStranaUčtu));

            }
            else
            {
                var msg = new MessageDialog("Nevyplnené meno žiaka/žiakov", "Zabudli ste vyplniť meno žiaka, prosím skontrolujte si vyplnené údaje");
                msg.ShowAsync();
            }

        }
    }
}
