using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._3___Vytvorenie_nového_účtu
{
    public class TriedaData : INotifyPropertyChanged
    {
        string tu_m;
        public string TriednyUcitel_MENO
        {
            get { return tu_m; }
            set
            {
                tu_m = value;
                OnPropertyChanged();
            }
        }

        string pr_m;
        public string Predseda_MENO
        {
            get { return pr_m; }
            set
            {
                pr_m = value;
                OnPropertyChanged();
            }
        }

        string fn_m;
        public string Financnik_MENO
        {
            get { return fn_m; }
            set
            {
                fn_m = value;
                OnPropertyChanged();
            }
        }

        string prod_m;
        public string PredsedaRodicov_MENO
        {
            get { return prod_m; }
            set
            {
                prod_m = value;
                OnPropertyChanged();
            }
        }

        int pctz;
        public int  PocetZiakov
        {
            get { return pctz; }
            set
            {
                pctz = value;
                OnPropertyChanged();
            }
        }

        string tr;
        public string trieda
        {
            get { return tr; }
            set
            {
                tr = value;
                OnPropertyChanged();
            }
        }

        string rk;
        public string RokUkoncenia
        {
            get { return rk; }
            set
            {
                
                rk = value;
                OnPropertyChanged();
            }
        }

        string h;
        public string Heslo
        {
            get { return h; }
            set
            {
                h = value;
                OnPropertyChanged();
            }
        }

        string tre;
        public string TriednyEmail
        {
            get { return tre; }
            set
            {
                tre = value;
                OnPropertyChanged();
            }
        }

        string trtel;
        public string TriednyUcitel_TELEFON
        {
            get { return trtel; }
            set
            {
                trtel = value;
                OnPropertyChanged();
            }
        }

        string prtel;
        public string Predseda_TELEFON
        {
            get { return prtel; }
            set
            {
                prtel = value;
                OnPropertyChanged();
            }
        }

        string fntel;
        public string Financnik_TELEFON
        {
            get { return fntel; }
            set
            {
                fntel = value;
                OnPropertyChanged();
            }
        }

        string prdrtel;
        public string PredsedaRodicov_TELEFON
        {
            get { return prdrtel; }
            set
            {
                prdrtel = value;
                OnPropertyChanged();
            }
        }

        string truem;
        public string TriednyUcitel_EMAIL
        {
            get { return truem; }
            set
            {
                truem = value;
                OnPropertyChanged();
            }
        }

        string predsm;
        public string PresedaTriedy_EMAIL
        {
            get { return predsm; }
            set
            {
                predsm = value;
                OnPropertyChanged();
            }
        }

        string ucte;
        public string Financnik_EMAIL
        {
            get { return ucte; }
            set
            {
                ucte = value;
                OnPropertyChanged();
            }
        }

        string predre;
        public string PredsedaRodicov_EMAIL
        {
            get { return predre; }
            set
            {
                predre = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// Navratí string format triedy na ktoru bolo kliknute
        /// </summary>
        /// <param name="SelectedValue">Parameter selected value v elemente ComboBox</param>
        /// <returns></returns>
        public string NahratieTriedyString(int SelectedValue)
        {
            string triedaString;

            if (SelectedValue == 0)
            {
                triedaString = $"Trieda - I.A";
                return triedaString;
            }

            else if (SelectedValue == 1)
            {
                triedaString = $"Trieda - I.B";
                return triedaString;
            }

            else if (SelectedValue == 2)
            {
                triedaString = $"Trieda - I.C";
                return triedaString;
            }
            else if (SelectedValue == 3)
            {

                triedaString = $"Trieda - I.SA";
                return triedaString;
            }
            else if (SelectedValue == 4)
            {
                triedaString = $"Trieda - I.SB";
                return triedaString;
            }
            else if (SelectedValue == 5)
            {
                triedaString = $"Trieda - I.SC";
                return triedaString;
            }

            //DRUHÁCI

            else if (SelectedValue == 6)
            {
                triedaString = $"Trieda - II.A";
                return triedaString;
            }

            else if (SelectedValue == 7)
            {
                triedaString = $"Trieda - II.B";
                return triedaString;
            }

            else if (SelectedValue == 8)
            {
                triedaString = $"Trieda - II.C";
                return triedaString;
            }
            else if (SelectedValue == 9)
            {
                triedaString = $"Trieda - II.SA";
                return triedaString;
            }
            else if (SelectedValue == 10)
            {
                triedaString = $"Trieda - II.SB";
                return triedaString; ;
            }
            else if (SelectedValue == 11)
            {
                triedaString = $"Trieda - II.SC";
                return triedaString;
            }
            else if (SelectedValue == 12)
            {
                triedaString = $"Trieda - II.F";
                return triedaString;
            }

            //TRERIACI

            else if (SelectedValue == 13)
            {
                triedaString = $"Trieda - III.A";
                return triedaString;
            }

            else if (SelectedValue == 14)
            {
                triedaString = $"Trieda - III.B";
                return triedaString;
            }

            else if (SelectedValue == 15)
            {
                triedaString = $"Trieda - III.C";
                return triedaString;
            }
            else if (SelectedValue == 16)
            {
                triedaString = $"Trieda - III.SA";
                return triedaString;
            }
            else if (SelectedValue == 17)
            {
                triedaString = $"Trieda - III.SB";
                return triedaString;
            }
            else if (SelectedValue == 18)
            {
                triedaString = $"Trieda - III.SC";
                return triedaString;
            }
            else if (SelectedValue == 19)
            {
                triedaString = $"Trieda - III.F";
                return triedaString;
            }


            //ŠTVRTÁCI

            else if (SelectedValue == 20)
            {
                triedaString = $"Trieda - IV.A";
                return triedaString;
            }

            else if (SelectedValue == 21)
            {
                triedaString = $"Trieda - IV.B";
                return triedaString;
            }

            else if (SelectedValue == 22)
            {
                triedaString = $"Trieda - IV.C";
                return triedaString;
            }
            else if (SelectedValue == 23)
            {
                triedaString = $"Trieda - IV.SA";
                return triedaString;
            }
            else if (SelectedValue == 24)
            {
                triedaString = $"Trieda - IV.SB";
                return triedaString;
            }
            else if (SelectedValue == 25)
            {
                triedaString = $"Trieda - IV.SC";
                return triedaString;
            }
            else if (SelectedValue == 26)
            {
                triedaString = $"Trieda - IV.F";
                return triedaString;
            }

            else
            {
                triedaString = "Error - trieda nebola vybrata";
                return triedaString;
            }
        }
    }
}
