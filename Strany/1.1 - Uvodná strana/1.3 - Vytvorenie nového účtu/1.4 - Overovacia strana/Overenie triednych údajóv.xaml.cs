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

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu._1._4___Overovacia_strana
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Overenie_triednych_údajóv : Page
    {
        public string TriedaNaPrednuStranu;

        public Overenie_triednych_údajóv()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu.Vytvorenie_triedy.ZistenéTriedneÚdaje InfoNaOverenie;
            InfoNaOverenie = (App.Current as App).GlobálnaPremenaInfaTriedy;

            Triednyucitel_MENO.Text = $"Meno - {InfoNaOverenie.TriednyUcitel_MENO}";
            Triednyucitel_TELEFON.Text = $"Telfon - {InfoNaOverenie.TriednyUcitel_TELEFON}";
            Triednyucitel_EMAIL.Text = $"Email - {InfoNaOverenie.TriednyUcitel_EMAIL}";

            TriednyUctovnik_MENO.Text = $"Meno - {InfoNaOverenie.Finančník_MENO}";
            TriednyUctovnik_TELEFON.Text = $"Telefon - {InfoNaOverenie.Finančník_TELEFON}";
            TriednyUctovnik_EMAIL.Text = $"Email - {InfoNaOverenie.Finančník_EMAIL}";

            Predseda_MENO.Text = $"Meno - {InfoNaOverenie.Predseda_MENO}";
            Predseda_TELEFON.Text = $"Telefon - {InfoNaOverenie.Predseda_TELEFON}";
            Predseda_EMAIL.Text = $"Email - {InfoNaOverenie.Finančník_EMAIL}";

            Predsedarodičov_MENO.Text = $"Meno - {InfoNaOverenie.PredsedaRodičov_MENO}";
            Predsedarodičov_TELEFON.Text = $"Telfon - {InfoNaOverenie.PredsedaRodičov_TELEFON}";
            Predsedarodičov_EMAIL.Text = $"Email - {InfoNaOverenie.PredsedaRodicov_EMAIL}";

            //PRVÁCI

            Convert.ToInt32(InfoNaOverenie.trieda);
           

            if (InfoNaOverenie.trieda== 0)
            {
                trieda.Text = $"Trieda - I.A";
                TriedaNaPrednuStranu = trieda.Text;
            }

            if (InfoNaOverenie.trieda == 1)
            {
                trieda.Text = $"Trieda - I.B";
                TriedaNaPrednuStranu = trieda.Text;
            }

            if (InfoNaOverenie.trieda == 2)
            {
                trieda.Text = $"Trieda - I.C";
                TriedaNaPrednuStranu = trieda.Text;
            }
            if (InfoNaOverenie.trieda == 3)
            {
             
                trieda.Text = $"Trieda - I.SA";
                TriedaNaPrednuStranu = trieda.Text;
            }
            if (InfoNaOverenie.trieda == 4)
            {
                trieda.Text = $"Trieda - I.SB";
                TriedaNaPrednuStranu = trieda.Text;
            }
            if (InfoNaOverenie.trieda == 5)
            {
                trieda.Text = $"Trieda - I.SC";
                TriedaNaPrednuStranu = trieda.Text;
            }

            //DRUHÁCI

            if (InfoNaOverenie.trieda == 6)
            {
                trieda.Text = $"Trieda - II.A";
                TriedaNaPrednuStranu = trieda.Text;
            }

            if (InfoNaOverenie.trieda == 7)
            {
                trieda.Text = $"Trieda - II.B";
                TriedaNaPrednuStranu = trieda.Text;
            }

            if (InfoNaOverenie.trieda == 8)
            {
                trieda.Text = $"Trieda - II.C";
                TriedaNaPrednuStranu = trieda.Text;
            }
            if (InfoNaOverenie.trieda == 9)
            {
                trieda.Text = $"Trieda - II.SA";
                TriedaNaPrednuStranu = trieda.Text;
            }
            if (InfoNaOverenie.trieda == 10)
            {
                trieda.Text = $"Trieda - II.SB";
                TriedaNaPrednuStranu = trieda.Text; ;
            }
            if (InfoNaOverenie.trieda == 11)
            {
                trieda.Text = $"Trieda - II.SC";
                TriedaNaPrednuStranu = trieda.Text;
            }
            if(InfoNaOverenie.trieda == 12)
            {
                trieda.Text = $"Trieda - II.F";
                TriedaNaPrednuStranu = trieda.Text;
            }

            //TRERIACI

            if(InfoNaOverenie.trieda == 13)
            {
                trieda.Text = $"Trieda - III.A";
                TriedaNaPrednuStranu = trieda.Text;
            }

            if (InfoNaOverenie.trieda == 14)
            {
                trieda.Text = $"Trieda - III.B";
                TriedaNaPrednuStranu = trieda.Text;
            }

            if (InfoNaOverenie.trieda == 15)
            {
                trieda.Text = $"Trieda - III.C";
                TriedaNaPrednuStranu = trieda.Text;
            }
            if (InfoNaOverenie.trieda == 16)
            {
                trieda.Text = $"Trieda - III.SA";
                TriedaNaPrednuStranu = trieda.Text;
            }
            if (InfoNaOverenie.trieda == 17)
            {
                trieda.Text = $"Trieda - III.SB";
                TriedaNaPrednuStranu = trieda.Text;
            }
            if (InfoNaOverenie.trieda == 18)
            {
                trieda.Text = $"Trieda - III.SC";
                TriedaNaPrednuStranu = trieda.Text;
            }
            if (InfoNaOverenie.trieda == 19)
            {
                trieda.Text = $"Trieda - III.F";
                TriedaNaPrednuStranu = trieda.Text;
            }


            //ŠTVRTÁCI

            if(InfoNaOverenie.trieda == 20)
            {
                trieda.Text = $"Trieda - IV.A";
                TriedaNaPrednuStranu = trieda.Text;
            }

            if (InfoNaOverenie.trieda == 21)
            {
                trieda.Text = $"Trieda - IV.B";
                TriedaNaPrednuStranu = trieda.Text;
            }

            if (InfoNaOverenie.trieda == 22)
            {
                trieda.Text = $"Trieda - IV.C";
                TriedaNaPrednuStranu = trieda.Text;
            }
            if (InfoNaOverenie.trieda == 23)
            {
                trieda.Text = $"Trieda - IV.SA";
                TriedaNaPrednuStranu = trieda.Text;
            }
            if (InfoNaOverenie.trieda == 24)
            {
                trieda.Text = $"Trieda - IV.SB";
                TriedaNaPrednuStranu = trieda.Text;
            }
            if (InfoNaOverenie.trieda == 25)
            {
                trieda.Text = $"Trieda - IV.SC";
                TriedaNaPrednuStranu = trieda.Text;
            }
            if (InfoNaOverenie.trieda == 26)
            {
                trieda.Text = $"Trieda - IV.F";
                TriedaNaPrednuStranu = trieda.Text;
            }

            PočetZiakov.Text = InfoNaOverenie.PocetZiakov;
            KoniecŠtúdia.Text = InfoNaOverenie.RokUkoncenia;
            MailTriedy.Text = InfoNaOverenie.TriednyEmail;
        }

        private void VsetkoOK_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).GlobalnaPremenaTriedyString = TriedaNaPrednuStranu;


            this.Frame.Navigate(typeof(Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu._1._4___Overovacia_strana._1._5__Zadanie_Ziako.ŽiaciVTriede));
        }

        private void Zle_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Vytvorenie_triedy));
            
        }
        public static bool TryGoBack()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack)
            {
                
                rootFrame.GoBack();
                return true;
            }
            return false;
        }

        private void PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Vytvorenie_triedy));
        }

    }
}

