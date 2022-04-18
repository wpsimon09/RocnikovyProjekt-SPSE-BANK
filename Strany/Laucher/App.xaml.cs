using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._1___Pridanie_peňazí;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._2___Platba;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._4___Sporenie;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._4___Sporenie._2._4._1___Pridať_sporenie;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._5__Zber_peňazí;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._3___Historia_platieb;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._6___Zábava_a_relax;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu._1._4___Overovacia_strana._1._5__Zadanie_Ziako;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu._1._4___Overovacia_strana;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie;
namespace Ročňíkový_projekt___Aplikácia_pre_banku
{

    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    partial class App : Application
    {
        /// <summary>
        /// Globálne Premenné v applikácii
        /// </summary>

        //------------------------Premenné pri vytvoreniu triedy------------------------------//
        public string GlobalnaPremenaTriedyString { get; set; }
        public Trieda GlobalnaPremenaTriedy { get; set; }


        //-------------------------PlatobnySystem-------------------------------------------//
        public PlatobnySystem PlatobnySistem { get; set; }

        //-------------------------Premenné pre zadávanie Ziakov----------------------------//
        public string[] MenaZiakov { get; set; }
        public bool boloNavigované { get; set; }
        public List<Ziak> ListZiakov { get; set; }
        public int IndexZiaka { get; set; }

        //---------------------------Premenné pri sporení-----------------------------------//
        public Sporenie GlobalSporenie{ get; set; }

        //---------------------------Premenné pri zberaní peňazí-----------------------------//
        public  List<ZberPenazi> ListZbieranychPenazi { get; set; }
        public int NaKtoréZberanieSaKliklo { get; set; }
        public ZberPenazi KtoreZberanieBudeUpravené { get; set; }
        public int KtoreZberanieJeUžHotove { get; set; }
        public double[] ProgressZberania { get; set; }
        public double[] KolkoSaZatialVyzbieralo { get; set; }
        public int IndexZberu { get; set; }



        //----------------------------Premenné pri hlavnej strane --------------------------//
        public double hlavnáSuma { get; set; }
        public bool JeTriedaPlneVytvorená { get; set; }

        //----------------------------Premenné pri historii platieb-------------------------//
        public int[] indexAkcie { get; set; }
        public string [] TextPreHistoriu { get; set; }
        public double Príjmy { get; set; }
        public double Výdavky { get; set; }
        public int[] PrijemAleboVýdavok { get; set; } //1- príjem 2-výdavok

        //----------------------------Premenné pri hre -------------------------------------//
        public Hra GlobalNaPremenaHry { get; set; }


        /// <summary>
        /// Funkcia pre nahratie intexu akcie
        /// </summary>
        /// <param name="index"> 1 - platba || 2 - inkaso || 3 - platba zo sporenia || 4 - inkaso na sporenie || 5 - inkaso so zberania </param>
        public void NahranieIndexuAkcie(int index)
        {
            for (int i = 0; i < 100; i++)
            {
                if ((App.Current as App).indexAkcie[i] == 0)
                {
                    (App.Current as App).indexAkcie[i] = index;
                    break;
                }
                else
                {

                }
            }
        }

        /// <summary>
        /// Prehrá animáciu a po prehratí naviguje na stranu
        /// </summary>
        /// <param name="animácia"> Lottie animácia </param>
        /// <param name="StranaNaKtoruSaNviguje"> Strana na ktorú sa má navigovat</param>
        /// <param name="StranaZKtorejSaNaviguje"> Strana z ktorej sa naviguje</param>
        public async void PrehranieAnimacieANavigovanieNaStranu(Microsoft.UI.Xaml.Controls.AnimatedVisualPlayer animácia, Type StranaNaKtoruSaNviguje, Page StranaZKtorejSaNaviguje)
        {
            await animácia.PlayAsync(0.0, 1.0, false);
            if (animácia.IsPlaying)
            {

            }
            else
            {
                StranaZKtorejSaNaviguje.Frame.Navigate(StranaNaKtoruSaNviguje);

            }
        }

        /// <summary>
        /// Len prehra asynchrone animáciu
        /// </summary>
        /// <param name="animácia">Lottie animácia</param>
        public async void PrehranieAnimacieANavigovanieNaStranu(Microsoft.UI.Xaml.Controls.AnimatedVisualPlayer animácia)
        {
            await animácia.PlayAsync(0.0, 1.0, false);
        }

        /// <summary>
        /// Zobrazí stackpanel s animáciou a následne ju prehrá
        /// </summary>
        /// <param name="animácia"> Lottie animácia </param>
        /// <param name="stackPanel"> Stack panel v ktoróm sa animácia nachádza </param>
        public async void PrehranieAnimácieAZobrazenieElementu(Microsoft.UI.Xaml.Controls.AnimatedVisualPlayer animácia, StackPanel stackPanel)
        {
            await animácia.PlayAsync(0.0, 1.0, false);
            if (animácia.IsPlaying)
            {

            }
            else
            {
                stackPanel.Visibility = Visibility.Collapsed;
                
            }
        }


        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            GlobalNaPremenaHry = new Hra();
            KolkoSaZatialVyzbieralo = new double[2];
            Príjmy = 0;
            Výdavky = 0;
            TextPreHistoriu = new string[100];
            ProgressZberania = new double[2];
            indexAkcie = new int[100];
            PrijemAleboVýdavok = new int[100];
            PlatobnySistem = new PlatobnySystem();
            ListZbieranychPenazi = new List<ZberPenazi>();
            ListZiakov = new List<Ziak>();
            IndexZberu = -1;
            boloNavigované = false;
            GlobalnaPremenaTriedy = new Trieda();
            
            ListZiakov.Add(new Ziak("Jožko","Mrva"));
            ListZiakov.Add(new Ziak("Ján", "Heatfild"));
            ListZiakov.Add(new Ziak("Kristián", "Hammet"));
            ListZiakov.Add(new Ziak("Peter", "Vňať"));
            ListZiakov.Add(new Ziak("Michal", "Marcin"));
            ListZiakov.Add(new Ziak("Sára", "Janová"));
            ListZiakov.Add(new Ziak("Jaroslav", "Sedlák"));
            ListZiakov.Add(new Ziak("Miroslav", "Dužina"));

            GlobalSporenie = new Sporenie();

            ListZbieranychPenazi.Add(new ZberPenazi("ZRPŠ", "10.2.2022", "96", this.ListZiakov, DateTimeOffset.Now));

            IndexZiaka = -1;

        }


        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
               
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    
                }

              
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                   
                    rootFrame.Navigate(typeof(Strany._1._1___Uvodná_strana.Prvá_strana), e.Arguments);
                }

                Window.Current.Activate();
            }
        }


        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Stranu sa nepodarilo nacítať " + e.SourcePageType.FullName);
        }

        
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            
            deferral.Complete();
        }
    }
    
}
