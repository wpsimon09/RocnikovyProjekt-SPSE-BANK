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

namespace Ročňíkový_projekt___Aplikácia_pre_banku
{

    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    partial class App : Application
    {
        public Vytvorenie_triedy.ZistenéTriedneÚdaje GlobálnaPremenaInfaTriedy { get; set; }
        public string GlobalnaPremenaTriedyString { get; set; }
        public PridaniePeňazí.InfoOPridanýchPeniazoch[] GlobálnaPremenáInfaOPridanýchPeniazoch { get; set; }
        public Platba.InfoOplatbe[] GlobálnaPremenaOPlatbe { get; set; }
        public uint hlavnáSuma { get; set; }
        public bool boloNavigované { get; set; }
        public string[] Menažiakov { get; set; }
        public int[] indexAkcie { get; set; }
        public uint SumaNaSporenie { get; set; }
        public uint SumaNaSporeniePriVytvoreniu { get; set; }
        public string DatumUkonceniaSporeniaPriVytvoreniu { get; set; }
        public int ProgressSporenie { get; set; }

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

        public async void PrehranieAnimacieANavigovanieNaStranu(Microsoft.UI.Xaml.Controls.AnimatedVisualPlayer animácia, Type StranaNaKtoruSaNviguje,Page StranaZKtorejSaNaviguje)
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
        public async void PrehranieAnimacieANavigovanieNaStranu(Microsoft.UI.Xaml.Controls.AnimatedVisualPlayer animácia)
        {
            await animácia.PlayAsync(0.0, 1.0, false);
        }



        public delegate void PlatbaEventHandler(object sender, EventArgs args);

        public event PlatbaEventHandler VykonanaPlatba;

        protected virtual void OnVykonanáPlatba()
        {
            if (VykonanaPlatba != null)
            {
                VykonanaPlatba(this, EventArgs.Empty);
               
            }
        }

        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            indexAkcie = new int[100];
            GlobálnaPremenáInfaOPridanýchPeniazoch = new PridaniePeňazí.InfoOPridanýchPeniazoch[100];
            GlobálnaPremenaOPlatbe = new Platba.InfoOplatbe[100];
        
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
