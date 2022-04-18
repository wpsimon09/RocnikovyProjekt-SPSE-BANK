using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie._2._1___Pridanie_peňazí
{
    public class Inkaso:INotifyPropertyChanged
    {
        private double _InkasovanaSuma;
        public double InkasovanaSuma
        {
            get { return _InkasovanaSuma; }
            set 
            {
                _InkasovanaSuma = value;
                OnPropertyChanged();
            }
        }

        public int Index { get; set; }

        private string _OdKohoSaInkasuje;
        public string OdKohoSaInkasuje
        {
            get { return _OdKohoSaInkasuje; }
            set
            {
                _OdKohoSaInkasuje = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Vykonať(double hlavnaSuma,double inkasovanaSuma)
        {
            hlavnaSuma = hlavnaSuma + inkasovanaSuma;
        }
    }
}
