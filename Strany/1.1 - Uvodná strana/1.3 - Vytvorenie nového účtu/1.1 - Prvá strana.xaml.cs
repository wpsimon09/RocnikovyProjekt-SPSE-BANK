using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana
{

    public partial class Prvá_strana : Page
    {



        public Prvá_strana()
        {
            this.InitializeComponent();

        }
        public string TriedaNaPrednuStranuZUvodnejStrany;

        private void ZmenaTriedy(object sender, SelectionChangedEventArgs e)
        {


            //prváci

            if (TriedaComboBox.SelectedIndex == 0)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - I.A";
                

            }

            if (TriedaComboBox.SelectedIndex == 1)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - I.B";
                
            }

            if (TriedaComboBox.SelectedIndex == 2)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - I.C";
                
            }
            if (TriedaComboBox.SelectedIndex == 3)
            {

                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - I.SA";
                
            }
            if (TriedaComboBox.SelectedIndex == 4)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - I.SB";
                
            }
            if (TriedaComboBox.SelectedIndex == 5)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - I.SC";
                
            }

            //DRUHÁCI

            if (TriedaComboBox.SelectedIndex == 6)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - II.A";
                
            }

            if (TriedaComboBox.SelectedIndex == 7)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - II.B";
                
            }

            if (TriedaComboBox.SelectedIndex == 8)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - II.C";
                
            }
            if (TriedaComboBox.SelectedIndex == 9)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - II.SA";
                
            }
            if (TriedaComboBox.SelectedIndex == 10)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - II.SB";
                 ;
            }
            if (TriedaComboBox.SelectedIndex == 11)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - II.SC";
                
            }
            if (TriedaComboBox.SelectedIndex == 12)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - II.F";
                
            }

            //TRERIACI

            if (TriedaComboBox.SelectedIndex == 13)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - III.A";
                
            }

            if (TriedaComboBox.SelectedIndex == 14)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - III.B";
                
            }

            if (TriedaComboBox.SelectedIndex == 15)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - III.C";
                
            }
            if (TriedaComboBox.SelectedIndex == 16)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - III.SA";
                
            }
            if (TriedaComboBox.SelectedIndex == 17)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - III.SB";
                
            }
            if (TriedaComboBox.SelectedIndex == 18)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - III.SC";
                
            }
            if (TriedaComboBox.SelectedIndex == 19)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - III.F";
                
            }


            //ŠTVRTÁCI

            if (TriedaComboBox.SelectedIndex == 20)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - IV.A";
                
            }

            if (TriedaComboBox.SelectedIndex == 21)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - IV.B";
                
            }

            if (TriedaComboBox.SelectedIndex == 22)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - IV.C";
                
            }
            if (TriedaComboBox.SelectedIndex == 23)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - IV.SA";
                
            }
            if (TriedaComboBox.SelectedIndex == 24)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - IV.SB";
                
            }
            if (TriedaComboBox.SelectedIndex == 25)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - IV.SC";
                
            }
            if (TriedaComboBox.SelectedIndex == 26)
            {
                TriedaNaPrednuStranuZUvodnejStrany = $"Trieda - IV.F";
                
            }

        }






        private void Pokračovať_Klik(object sender, RoutedEventArgs e)
        {
            
            (App.Current as App).GlobalnaPremenaTriedyString = TriedaNaPrednuStranuZUvodnejStrany;

            if(TriedaNaPrednuStranuZUvodnejStrany != null)
            {
                this.Frame.Navigate(typeof(Strany._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie.HlavnaStranaUčtu));

            }
            else
            {
                var msg = new MessageDialog("Žiadna trieda nebola zvolená", "Trieda nebola zvolená");
                msg.ShowAsync();
            }




        }

        private void VytvoriťTriedu_Click(object sender, RoutedEventArgs e)
        {
            if((App.Current as App).JeTriedaPlneVytvorená == true)
            {

            }
            else
            {
                (App.Current as App).JeTriedaPlneVytvorená = false;
            }
            this.Frame.Navigate(typeof(Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu.Vytvorenie_triedy));
        }


       
    }    
}
