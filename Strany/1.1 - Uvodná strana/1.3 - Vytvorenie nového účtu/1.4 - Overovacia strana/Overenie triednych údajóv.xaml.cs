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

