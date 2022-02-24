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

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu._1._4___Overovacia_strana._1._5__Zadanie_Ziako
{
    
    public sealed partial class ŽiaciVTriede : Page
    {
        public  List<Ziak> ListZiakov;
        public ŽiaciVTriede()
        {
            ListZiakov = (App.Current as App).ListZiakov;
            this.InitializeComponent();
            (App.Current as App).boloNavigované = false;           
            
        }

        public static int PocetZiakov = Convert.ToInt32((App.Current as App).GlobálnaPremenaInfaTriedy.PocetZiakov);


        string[] MenoTextBoxu;
        TextBox[] textbox = new TextBox[PocetZiakov];
        string[] žiaci = new string[PocetZiakov];



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            if ((App.Current as App).boloNavigované == false)
            {
                for (int i = 0; i < PocetZiakov; i++)
                {
                }
            }
            
        }

        private void Naspäť_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(Overenie_triednych_údajóv));
        }

        private void Vyčistiť_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void Hotovo_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie.HlavnaStranaUčtu));

        }
    }
}
