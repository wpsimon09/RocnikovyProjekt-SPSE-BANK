﻿using System;
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
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._4___Sporenie;
// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Správy
{
    public sealed partial class SporenieNaStužkovú : ContentDialog
    {
        public Sporenie sporenie { get; set; } 
        public double Suma { get; set; }
        public SporenieNaStužkovú()
        {
            sporenie = (App.Current as App).GlobalSporenie;
            this.InitializeComponent();
            this.NahranieItemovKtoreBoliZakliknute(KtoPrispel);
            
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            (App.Current as App).GlobalSporenie.InkasoNaSporenie(Suma);
            (App.Current as App).GlobalSporenie.ZiaciPreSporenieNaStuzkovu[KtoPrispel.SelectedIndex].KolkoZaplatil = Suma;
            NahranieLudi(KtoPrispel);
            this.Hide();
        }

        private void KtoPrispel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void NahranieLudi(ListView list)
        {
            int index = 0;
            foreach (object item in list.Items)
            {
                ListViewItem items = list.ContainerFromItem(item) as ListViewItem;

                if (items.IsSelected)
                {
                    (App.Current as App).GlobalSporenie.ZiaciPreSporenieNaStuzkovu[index].JeZačiarknute = true;
                    index++;
                }
                else if (!items.IsSelected)
                {
                    (App.Current as App).GlobalSporenie.ZiaciPreSporenieNaStuzkovu[index].JeZačiarknute = false;
                    index++;
                }

            }

            (App.Current as App).GlobalSporenie.ZiaciKtoryZaplatili.Add((App.Current as App).GlobalSporenie.ZiaciPreSporenieNaStuzkovu[list.SelectedIndex]);
            (App.Current as App).GlobalSporenie.ZiaciPreSporenieNaStuzkovu.Remove((App.Current as App).GlobalSporenie.ZiaciPreSporenieNaStuzkovu[list.SelectedIndex]);
            

        }

        public void NahranieItemovKtoreBoliZakliknute(ListView Nezaplatili)
        {
            int i = 0;
            foreach (object item in Nezaplatili.Items)
            {
                if ((App.Current as App).GlobalSporenie.ZiaciPreSporenieNaStuzkovu[i].JeZačiarknute == true)
                {
                    Nezaplatili.SelectRange(new ItemIndexRange(i, 1));
                    i++;
                }
                else
                {
                    i++;
                }
            }

        }
    }
}
