using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._6___Zábava_a_relax
{
    public class Hra : INotifyPropertyChanged
    {
        public Hra()
        {
            NajlepsieCasi = new TimeSpan[3];
            _najCas = new TimeSpan[3];
        }

        public Thickness Obrazok1 { get; set; }
        public Thickness Obrazok2 { get; set; }
        public Thickness Obrazok3 { get; set; }
        public Thickness Obrazok4 { get; set; }

        private TimeSpan[] _najCas;
        public TimeSpan[] NajlepsieCasi
        {
            get
            {
                return _najCas;
            }
            set
            {
                try
                {
                    _najCas[0] = value[0];
                    _najCas[1] = value[1];
                    _najCas[2] = value[2];
                    NajlepsieCasi = _najCas;
                }
                catch(System.NullReferenceException)
                {

                }
                
                OnPropertyChanged();
            }
        }
      

        public TimeSpan aktualnyCas;
        
        double [] x = new double[4];
        double [] y = new double[4];

        Random rand = new Random();
        
        /// <summary>
        /// Vygeneruje x a y pre obrázok na ktorý sa má hľadať
        /// </summary>
        public void VygenerovanieHodnotPreRozmiestnenie()
        {
           
            for (int i = 0; i < 4; i++)
            {
                x[i] = rand.Next(0, 532);
                y[i] = rand.Next(0, 376);
            }
            Obrazok1 = new Thickness(x[0], y[0], 0,0);
            Obrazok2 = new Thickness(x[1], y[1], 0, 0);
            Obrazok3 = new Thickness(x[2], y[2],0,0);
            Obrazok4 = new Thickness(x[3], y[3], 0,0);

        }

        /// <summary>
        /// Porovná najlepsie 3 časi a zaradí aktuálne získaný čas medzi ne ak je lepší ako jeden z predchádzajucích
        /// </summary>
        /// <param name="cas">TimeSpan: cas strávený nájdením všetkých obrázkov</param>
        public void PorovnanieANahranieNajlepsichCasov(TimeSpan cas)
        {
            for (int i = 0; i < 3; i++)
            {
                if (NajlepsieCasi[i] == TimeSpan.Zero)
                {
                    NajlepsieCasi[i] = cas;
                    break;
                }
                else if(cas<NajlepsieCasi[i])
                {
                    NajlepsieCasi[i] = cas;
                    break;
                }
                else
                {
                    continue;
                }
            }
            aktualnyCas = cas;
            Array.Sort(NajlepsieCasi);
        }

        public void SkrytieObrazku(Image obrazok)
        {          
            obrazok.Visibility = Visibility.Collapsed;
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
