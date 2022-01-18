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
        public Vytvorenie_triedy.ZistenéTriedneÚdaje GlobálnaPremenaInfaTriedy { get; set; }
        public string GlobalnaPremenaTriedyString { get; set; }


        //------------------------Premenné pri pridanie paňazí------------------------------//
        public PridaniePeňazí.InfoOPridanýchPeniazoch[] GlobálnaPremenáInfaOPridanýchPeniazoch { get; set; }



        //-------------------------Premenné pri platbe--------------------------------------//
        public Platba.InfoOplatbe[] GlobálnaPremenaOPlatbe { get; set; }


        //-------------------------Premenné pre zadávanie žiakov----------------------------//
        public string[] Menažiakov { get; set; }
        public bool boloNavigované { get; set; }

        //---------------------------Premenné pri sporení-----------------------------------//
        public uint SumaNaSporenie { get; set; }
        public uint SumaNaSporeniePriVytvoreniu { get; set; }
        public string DatumUkonceniaSporeniaPriVytvoreniu { get; set; }
        public int ProgressSporenie { get; set; }

        //---------------------------Premenné pri zberaní peňazí-----------------------------//
        public VytvorenieZberaniaPeňazí.VyzbieranePeniaze[] GlobalnaPremenaVytvorenieZberania { get; set; }
        public int NaKtoréZberanieSaKliklo { get; set; }
        public int KtoreZberanieBudeUpravené { get; set; }
        public int KtoreZberanieJeUžHotove { get; set; }
        public double[] ProgressZberania { get; set; }
        public double[] KolkoSaZatialVyzbieralo { get; set; }


        //----------------------------Premenné pri hlavnej strane --------------------------//
        public uint hlavnáSuma { get; set; }
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

        /// <summary>
        /// Nahranie textu pre historiu v prípade inkasa
        /// </summary>
        /// <param name="inkaso"> Štruktúra pre inkaso, kde sa nachádzajú všetky potrebné informácie</param>
        public void NahranieTextuDoHistorie(PridaniePeňazí.InfoOPridanýchPeniazoch inkaso)
        {
            for (int i = 0; i < 100; i++)
            {
                if(string.IsNullOrEmpty(TextPreHistoriu[i]))
                {
                    if(inkaso.KamSaPeniazeUlozia == 0)
                    {
                        TextPreHistoriu[i] = $"+ {DateTime.Now.ToString("d")} - Inkaso v hodnote {inkaso.suma.ToString()} na bežný účet";
                    }
                    else if(inkaso.KamSaPeniazeUlozia == 1)
                    {
                        TextPreHistoriu[i] = $"+ {DateTime.Now.ToString("d")} - Inkaso v hodnote {inkaso.suma.ToString()} na sporiaci účet";
                    }
                    PrijemAleboVýdavok[i] = 1;
                    Príjmy = Príjmy + Convert.ToDouble(inkaso.suma);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// Nahrá text pre historiu platieb v prípade platby
        /// </summary>
        /// <param name="platba"> Štruktúra, ktorá obsahuje všetky potrebné informácie o platbe</param>
        public void NahranieTextuDoHistorie(Platba.InfoOplatbe platba)
        {
            for (int i = 0; i < 100; i++)
            {
                if (string.IsNullOrEmpty(TextPreHistoriu[i]))
                {
                    if (platba.ZakéhoUčtuPojduPeniaze == 0)
                    {
                        TextPreHistoriu[i] = $"- {platba.DátumSplatnosti} - platba v hodnote {platba.PlatenáSuma} pre {platba.MenoPríjemcu} z bežného účtu";
                    }
                    else if (platba.ZakéhoUčtuPojduPeniaze == 1)
                    {
                        TextPreHistoriu[i] = $"- {platba.DátumSplatnosti} - platba v hodnote {platba.PlatenáSuma} pre {platba.MenoPríjemcu} zo sporiaceho účtu";
                    }
                    Výdavky = Výdavky + Convert.ToDouble(platba.PlatenáSuma);
                    PrijemAleboVýdavok[i] = 2;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// Nahrá text pre historiu platieb v prípade ukončeneho zberania
        /// </summary>
        /// <param name="ZberPenazi"> Štruktúra, ktorá obsahuje všetky potrebné informácie o zbere peňazí</param>
        public void NahranieTextuDoHistorie(VytvorenieZberaniaPeňazí.VyzbieranePeniaze ZberPenazi)
        {
            for (int i = 0; i < 100; i++)
            {
                if (string.IsNullOrEmpty(TextPreHistoriu[i]))
                {
                    TextPreHistoriu[i] = $"+ {DateTime.Now.ToString("d")}  vyzbieraná čiastka {ZberPenazi.SumaNaVyzbieranie}€ na {ZberPenazi.NázovZberania}";
                    PrijemAleboVýdavok[i] = 1;
                    Príjmy = Príjmy + Convert.ToDouble(ZberPenazi.SumaNaVyzbieranie);
                    break;
                }
                else
                {
                    continue;
                }
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
            GlobálnaPremenáInfaOPridanýchPeniazoch = new PridaniePeňazí.InfoOPridanýchPeniazoch[2];
            GlobálnaPremenaOPlatbe = new Platba.InfoOplatbe[100];
            GlobalnaPremenaVytvorenieZberania = new VytvorenieZberaniaPeňazí.VyzbieranePeniaze[3];
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
