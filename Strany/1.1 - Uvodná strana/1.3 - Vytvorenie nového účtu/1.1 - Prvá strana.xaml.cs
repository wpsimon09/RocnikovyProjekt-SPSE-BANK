using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu._1._4___Overovacia_strana;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana
{

    public partial class Prvá_strana : Page
    {

        public Trieda Trieda { get; set; }

        public Prvá_strana()
        {
            Trieda = new Trieda();  
            this.InitializeComponent();
        }
        public string TriedaNaPrednuStranuZUvodnejStrany;

        private void ZmenaTriedy(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Pokračovať_Klik(object sender, RoutedEventArgs e)
        {
            (App.Current as App).GlobalnaPremenaTriedy.trieda = this.Trieda.NahratieTriedyString(TriedaComboBox.SelectedIndex);

            if (TriedaComboBox.SelectedIndex != -1)
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
