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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Vytvorenie_triedy : Page
    {
        public Vytvorenie_triedy()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            
        }



        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Strany._1._1___Uvodná_strana.Prvá_strana));
        }


        public  struct ZistenéTriedneÚdaje
        {
            public string TriednyUcitel_MENO;       //MenoTriednehoUcitela
            public string Predseda_MENO;            //MenoPredsedu
            public string Finančník_MENO;           //MenoFinančníka
            public string PredsedaRodičov_MENO;     //MenoPredseduRodičov

            public string PocetZiakov;              //pocetZiakov
            public int    trieda;                   //Trieda
            public string RokUkoncenia;             //koniecŠtúdia
            public string Heslo;                    //HesloTriedy
            public string TriednyEmail;             //TriednyEmail
            

            public string TriednyUcitel_TELEFON;    //TelefonTriednyUcitel
            public string Predseda_TELEFON;         //TelefonNaPredseduTriedy
            public string Finančník_TELEFON;        //TelfonNaTriednehoUctovnika
            public string PredsedaRodičov_TELEFON;  //TelfonNaPredseduRodičov

            public string TriednyUcitel_EMAIL;      //emailTriednyUcitel  
            public string PresedaTriedy_EMAIL;      //emailPredsedaTriedy
            public string Finančník_EMAIL;          //emailTriednyUctovnik
            public string PredsedaRodicov_EMAIL;    //emailPredsedaRodičov

        }

        private void Hotovo_Click(object sender, RoutedEventArgs e)
        {
            ZistenéTriedneÚdaje GlobálnaPremenná()
            {
                ZistenéTriedneÚdaje u;
                u.TriednyUcitel_MENO = MenoTriednehoUcitela.Text;
                u.Predseda_MENO = MenoPredsedu.Text;
                u.Finančník_MENO = MenoFinančníka.Text;
                u.PredsedaRodičov_MENO = MenoPredseduRodičov.Text;

                u.PocetZiakov = pocetZiakov.Value.ToString();
                u.trieda = Trieda.SelectedIndex;
                u.RokUkoncenia = koniecŠtúdia.Date.Value.DateTime.ToString("d");
                u.Heslo = HesloTriedy.Password.ToString();
                u.TriednyEmail = TriednyEmail.Text;

                u.TriednyUcitel_TELEFON = TelefonTriednyUcitel.Text;
                u.Predseda_TELEFON = TelefonNaPredseduTriedy.Text;
                u.Finančník_TELEFON = TelfonNaTriednehoUctovnika.Text;
                u.PredsedaRodičov_TELEFON = TelfonNaPredseduRodičov.Text;

                u.TriednyUcitel_EMAIL = emailTriednyUcitel.Text;
                u.PresedaTriedy_EMAIL = emailPredsedaTriedy.Text;
                u.Finančník_EMAIL = emailTriednehyUctovnik.Text;
                u.PredsedaRodicov_EMAIL = emailPredsedaRodičov.Text;


                return u;

            }
            ZistenéTriedneÚdaje temp = new ZistenéTriedneÚdaje();
            


           
            
            ZistenéTriedneÚdaje zistenéTriedneÚdaje = new ZistenéTriedneÚdaje();
            zistenéTriedneÚdaje =temp = GlobálnaPremenná();

            if (
                    string.IsNullOrEmpty(zistenéTriedneÚdaje.TriednyUcitel_MENO) ||
                    string.IsNullOrEmpty(zistenéTriedneÚdaje.Predseda_MENO) ||
                    string.IsNullOrEmpty(zistenéTriedneÚdaje.Finančník_MENO) ||
                    string.IsNullOrEmpty(zistenéTriedneÚdaje.PredsedaRodičov_MENO) ||

                    Convert.ToInt32(zistenéTriedneÚdaje.PocetZiakov) <= 3 ||

                    zistenéTriedneÚdaje.trieda == -1||
                    string.IsNullOrEmpty(zistenéTriedneÚdaje.RokUkoncenia) ||
                    string.IsNullOrEmpty(zistenéTriedneÚdaje.RokUkoncenia) ||
                    string.IsNullOrEmpty(zistenéTriedneÚdaje.Heslo) ||
                    string.IsNullOrEmpty(zistenéTriedneÚdaje.TriednyEmail) ||

                    string.IsNullOrEmpty(zistenéTriedneÚdaje.TriednyUcitel_TELEFON) ||
                    string.IsNullOrEmpty(zistenéTriedneÚdaje.Predseda_TELEFON) ||
                    string.IsNullOrEmpty(zistenéTriedneÚdaje.Finančník_TELEFON) ||
                    string.IsNullOrEmpty(zistenéTriedneÚdaje.PredsedaRodičov_TELEFON) ||

                    string.IsNullOrEmpty(zistenéTriedneÚdaje.TriednyUcitel_EMAIL) ||
                    string.IsNullOrEmpty(zistenéTriedneÚdaje.PresedaTriedy_EMAIL) ||
                    string.IsNullOrEmpty(zistenéTriedneÚdaje.Finančník_EMAIL) ||
                    string.IsNullOrEmpty(zistenéTriedneÚdaje.PredsedaRodicov_EMAIL) ||
                    string.IsNullOrEmpty(zistenéTriedneÚdaje.trieda.ToString())
                    )
                    
                    
            {
            
                var OhlasenieOnevyplneníPolia = new MessageDialog("Chýba vyplnené pole/polia, skúste skontrolovať počet Ziakov, triedu a ostatné údaje, ktoré treba doplniť", "Nevyplnené pole");
                OhlasenieOnevyplneníPolia.ShowAsync();

            }
            else
            {
                Ziak ziak;
                ziak = new Ziak();
                (App.Current as App).GlobálnaPremenaInfaTriedy = zistenéTriedneÚdaje;
                for (int i = 0; i < Convert.ToInt32(zistenéTriedneÚdaje.PocetZiakov); i++)
                {
                    ziak.NahranieZiakaDoListu((App.Current as App).ListZiakov);    
                }
                this.Frame.Navigate(typeof(Overenie_triednych_údajóv));

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

      
            MenoTriednehoUcitela.Text = string.Empty;
            MenoPredsedu.Text = string.Empty;
            MenoFinančníka.Text = string.Empty;
            MenoPredseduRodičov.Text = string.Empty;

            pocetZiakov.Value = 0;
            Trieda.SelectedIndex = -1;
            koniecŠtúdia.Date = null;
            HesloTriedy.Password = string.Empty;
            TriednyEmail.Text = string.Empty;

            TelefonTriednyUcitel.Text = string.Empty;
            TelefonNaPredseduTriedy.Text = string.Empty;
            TelfonNaTriednehoUctovnika.Text = string.Empty;
            TelfonNaPredseduRodičov.Text = string.Empty;

            emailTriednyUcitel.Text = string.Empty;
            emailPredsedaTriedy.Text = string.Empty;
            emailTriednehyUctovnik.Text = string.Empty;
            emailPredsedaRodičov.Text = string.Empty;
            
           
        }
    }
}
