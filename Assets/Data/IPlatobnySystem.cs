using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Assets.Data
{
    public abstract class IPlatobnySystem:INotifyPropertyChanged
    {

        public List<Prijmy> ListPrijmov { get; set; }
        public List<Výdavky> ListVydavkov { get; set; }
        public double CelkovaSuma { get; set; }
        
        
        //Inkaso
        private double _inkasovanaSUma;
        public double InkasovanaSuma
        {
            get { return _inkasovanaSUma; }
            set
            {
                _inkasovanaSUma = value;
                OnPropertyChanged();
            }
        }
        private string _odKohoPrisliPeniaze;
        public string OdKohoPrisliPenia
        {
            get { return _odKohoPrisliPeniaze; }
            set
            {
                _odKohoPrisliPeniaze = value;
                OnPropertyChanged();
            }
        }
        public int KamPojduPeniaze { get; set; }

        //platba
        public double PlatenaSuma { get; set; }
        private string _menoPrijemcu;
        public string MenoPrijemcu
        {
            get { return _menoPrijemcu; }
            set
            {
                _menoPrijemcu = value;
                OnPropertyChanged();
            }
        }
        private string _IbanPrijemcu;
        public string IBANPrijemcu
        {
            get { return _IbanPrijemcu; }
            set
            {
                _IbanPrijemcu = value;
                OnPropertyChanged();
            }
        }

        private DateTime _datumSplatnosti;
        public DateTime DatumSplatnosti
        {
            get { return _datumSplatnosti; }
            set
            {
                _datumSplatnosti = value;
                OnPropertyChanged();
            }
        }
        public int zAkehoUctuSaPlati { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
