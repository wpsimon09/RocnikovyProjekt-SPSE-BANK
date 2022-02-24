using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu._1._4___Overovacia_strana._1._5__Zadanie_Ziako
{
    public class Ziak : INotifyPropertyChanged
    {
        public string meno
        {
            get { return _meno; }

            set 
            {
                _meno = value;
                OnPropertyChanged();
            }
        }
        public string priezvysko { get; set; }
        public int Index { get; set; }
        public string _meno;
        public string _priezvysko;

        public bool JeZačiarknute { get; set; }

        public Ziak(string _meno, string _priezvysko)
        {
            meno = _meno;
            priezvysko = _priezvysko;
            JeZačiarknute = false;
            (App.Current as App).IndexZiaka++;
            Index = (App.Current as App).IndexZiaka;

        
        }

        public Ziak()
        {
            meno = string.Empty;
            priezvysko = string.Empty;
            JeZačiarknute = false;
            (App.Current as App).IndexZiaka++;
            Index = (App.Current as App).IndexZiaka;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NahranieZiakaDoListu(List<Ziak>ListZiakov)
        {
            ListZiakov.Add(new Ziak());
        }

    }
}
