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
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu._1._4___Overovacia_strana;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu._1._4___Overovacia_strana._1._5__Zadanie_Ziako;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Vytvorenie_triedy : Page
    {
        private Trieda LocalTrieda { get; set; }
      
        public Vytvorenie_triedy()
        {
            LocalTrieda = new Trieda();
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Strany._1._1___Uvodná_strana.Prvá_strana));
        }

        private void Hotovo_Click(object sender, RoutedEventArgs e)
        {

            if (
                    string.IsNullOrEmpty(MenoTriednehoUcitela.Text) ||
                    string.IsNullOrEmpty(MenoPredsedu.Text) ||
                    string.IsNullOrEmpty(MenoFinančníka.Text) ||
                    string.IsNullOrEmpty(MenoPredseduRodičov.Text) ||

                    Convert.ToInt32(pocetZiakov.Value) <= 3 ||

                    trieda.SelectedIndex == -1 ||
                    string.IsNullOrEmpty(koniecŠtúdia.Date.ToString()) ||
                    string.IsNullOrEmpty(HesloTriedy.Password) ||
                    string.IsNullOrEmpty(TriednyEmail.Text) ||

                    string.IsNullOrEmpty(TelefonTriednyUcitel.Text) ||
                    string.IsNullOrEmpty(TelefonNaPredseduTriedy.Text) ||
                    string.IsNullOrEmpty(TelfonNaTriednehoUctovnika.Text) ||
                    string.IsNullOrEmpty(TelfonNaPredseduRodičov.Text) ||

                    string.IsNullOrEmpty(emailTriednyUcitel.Text) ||
                    string.IsNullOrEmpty(emailPredsedaTriedy.Text) ||
                    string.IsNullOrEmpty(emailTriednehyUctovnik.Text) ||
                    string.IsNullOrEmpty(emailPredsedaRodičov.Text)
                    )


            {

                var OhlasenieOnevyplneníPolia = new MessageDialog("Chýba vyplnené pole/polia, skúste skontrolovať počet Ziakov, triedu a ostatné údaje, ktoré treba doplniť", "Nevyplnené pole");
                OhlasenieOnevyplneníPolia.ShowAsync();

            }
            else
            {
                if ((App.Current as App).boloNavigované == false)
                {
                    Ziak ziak;
                    ziak = new Ziak();
                    LocalTrieda.trieda = LocalTrieda.NahratieTriedyString(trieda.SelectedIndex);
                    LocalTrieda.RokUkoncenia = koniecŠtúdia.Date.Value.ToString("d");
                    (App.Current as App).GlobalnaPremenaTriedy = LocalTrieda;
                    for (int i = 0; i < Convert.ToInt32(LocalTrieda.PocetZiakov); i++)
                    {
                        ziak.NahranieZiakaDoListu((App.Current as App).ListZiakov);
                    }
                    (App.Current as App).boloNavigované = true;
                    this.Frame.Navigate(typeof(Overenie_triednych_údajóv));

                }
                else if ((App.Current as App).boloNavigované == true)
                {
                    LocalTrieda.trieda = LocalTrieda.NahratieTriedyString(trieda.SelectedIndex);
                    LocalTrieda.RokUkoncenia = koniecŠtúdia.Date.Value.ToString("d");
                    (App.Current as App).GlobalnaPremenaTriedy = LocalTrieda;
                    this.Frame.Navigate(typeof(Overenie_triednych_údajóv));
                }

            }
        }

        private void ZmenaTelCUcitela(TextBox sender,TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void ZmenaTelCPredseduTriedy(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void ZmenaTelCUctovnika(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }


        private void ZmenaTelCPredseduRodicov(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
    
        }

  
        
        private void Vyčistiť_Click(object sender, RoutedEventArgs e)
        {
            StackPanelSAnimáciou.Visibility = Visibility.Visible;
            (App.Current as App).PrehranieAnimácieAZobrazenieElementu(AnimáciaNaSpustenie, StackPanelSAnimáciou);

            LocalTrieda = null;    
        }
    }
}
