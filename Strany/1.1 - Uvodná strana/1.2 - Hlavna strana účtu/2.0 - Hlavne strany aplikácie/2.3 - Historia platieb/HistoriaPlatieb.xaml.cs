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

            PocetCelkovýchIndexov = IndexCount((App.Current as App).indexAkcie);
            PocetPrijmov = InkasaPočet((App.Current as App).indexAkcie);
            PocetVýdavkov = PlatbyPočet((App.Current as App).indexAkcie);
            InfoPreHistoriu = new string[PocetCelkovýchIndexov];
            PrijmyString = new string[PocetCelkovýchIndexov];
            VydavkyString = new string[PocetCelkovýchIndexov];
        }
        public static int PocetCelkovýchIndexov = new int();
        public static int PocetPrijmov = new int();
        public static int PocetVýdavkov = new int();


        private string[] InfoPreHistoriu;
        private string[] PrijmyString;
        private string[] VydavkyString;



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NahranieInformácií();
            NahranieInfoDOListView(PrijmyString, VydavkyString);
            Vysledok.Text = $"{VyrátanieCelkovéhoVýsledku((App.Current as App).Príjmy, (App.Current as App).Výdavky).ToString()} €";
            PomerPrijmovAVydajkov.Value = VyrátanieHodnotyPreProgressBar((App.Current as App).Príjmy, (App.Current as App).Výdavky);
            
        }
        

        private void Naspäť_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie.HlavnaStranaUčtu));
           
        }

        

        /// <summary>
        /// Navracá počet indexov ktoré neobsahujú 0
        /// </summary>
        /// <param name="index">Index akcie, ktorá sa vykonala</param>
        /// <returns></returns>
        private int IndexCount(int[] index)
        {
            int pocet = 0;

            for (int v = 0; v < 100; v++)
            {
                if(index[v] != 0)
                {
                    pocet++;
                    
                }
                else
                {
                    break;
                }
            }
            return pocet;
        }

       

        /// <summary>
        /// Vracia počet všetkých indexov, ktroé majú hodnoutú 1 a 3
        /// </summary>
        /// <param name="index">Všetky indexy platieb, ktoré trebá spočítať</param>
        /// <returns></returns>
        private int PlatbyPočet(int[] index)
        {
            int pocet = 0;

            for (int v = 0; v < 100; v++)
            {
                if (index[v] == 1 || index[v]==3)
                {
                    pocet++;

                }
                else if (index[v] == 0)
                {
                    break;
                }
            }
            return pocet;
        }

        /// <summary>
        /// Vratí počet všetkých indexov, ktoré majú hodnotu 2,4,5
        /// </summary>
        /// <param name="index">Všetky indexy platieb, ktoré trebá spočítať</param>
        /// <returns></returns>
        private int InkasaPočet (int[] index)
        {
            int pocet = 0;

            for (int v = 0; v < 100; v++)
            {
                if (index[v] == 2 || index[v] == 4 || index[v]==5)
                {
                    pocet++;

                }
                else if(index[v] == 0)
                {
                    break;
                }
            }
            return pocet;
        }

        /// <summary>
        /// Nahrá informácie do presne alokovonaj pamäti
        /// </summary>
        private void NahranieInformácií()
        {

            for (int i = 0; i < PocetCelkovýchIndexov; i++)
            {
                InfoPreHistoriu[i] = (App.Current as App).TextPreHistoriu[i];
                
                if(InfoPreHistoriu[i][0]== '+')
                {
                    PrijmyString[i] = InfoPreHistoriu[i];
                }
                else if(InfoPreHistoriu[i][0]=='-')
                {
                    VydavkyString[i] = InfoPreHistoriu[i];
                }             
            }
        }

        /// <summary>
        /// Nahrá príjmy a výdavky do list viewu
        /// </summary>
        /// <param name="inkasa">Pole stringov v ktorm sa nachádzajú informácie o inkasoch</param>
        /// <param name="vydavky">Pole stringov v ktorom sa nachádzajú infromácie o výdavkoch</param>
        private void NahranieInfoDOListView(string [] inkasa, string[]vydavky)
        {
            Array.Sort(inkasa);
            Array.Sort(vydavky);

            Array.Reverse(inkasa);
            Array.Reverse(vydavky);

            Prijmy.ItemsSource = inkasa;
            Vydavky.ItemsSource = vydavky;
        }

        /// <summary>
        /// Navráti hodnotu value pre progressbar
        /// </summary>
        /// <param name="prijmy">double: súčet všetkých príjmov</param>
        /// <param name="vydavky">double súčet všetkých výdavkov</param>
        private int VyrátanieHodnotyPreProgressBar(double prijmy, double vydavky)
        {
            double temp;
            int hodnota = 0;


            if (vydavky < prijmy)
            {
                hodnota = Convert.ToInt32((prijmy / (prijmy + vydavky)) * 100);
                StackPanelSInformáciami.Visibility = Visibility.Visible;
                return hodnota;
            }
            else if (prijmy < vydavky)
            {
                hodnota = Convert.ToInt32((vydavky / (prijmy + vydavky)) * 100);
                StackPanelSInformáciami.Visibility = Visibility.Visible;
                return hodnota;
            }
            else if (vydavky == 0 && prijmy > 0)
            {
                StackPanelSInformáciami.Visibility = Visibility.Visible;
                hodnota = 100;
                return hodnota;
            }
            else if (prijmy == vydavky)
            {
                StackPanelSInformáciami.Visibility = Visibility.Visible;
                hodnota = 50;
                return hodnota;
            }
            else if (prijmy == 0 && vydavky > 0)
            {
                StackPanelSInformáciami.Visibility = Visibility.Visible;
                hodnota = 0;
                return hodnota;
            }
            else if (prijmy == 0 && vydavky == 0)
            {
                hodnota = 0;
                StackPanelSInformáciami.Visibility = Visibility.Collapsed;
                return hodnota;
            }
            else
            {
                StackPanelSInformáciami.Visibility = Visibility.Collapsed;
                hodnota = 0;
                return hodnota;
            }
        }

        /// <summary>
        /// Vyráta hospodársky výsledok
        /// </summary>
        /// <param name="prijmy"> double: súčet príjmov </param>
        /// <param name="vydavky"> double: súčet výdavkov </param>
        /// <returns></returns>
        public double VyrátanieCelkovéhoVýsledku(double prijmy, double vydavky)
        {
            double vysledok;
            vysledok = prijmy - vydavky;
            return vysledok;
        }
    }
 
}