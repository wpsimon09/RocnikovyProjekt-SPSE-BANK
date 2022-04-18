using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Assets.Data
{
    public class Prijmy
    {
        public string Prijem { get; set; }
        
        public Prijmy (IPlatobnySystem prijem)
        {
            Prijem = $"{prijem.InkasovanaSuma} od {prijem.OdKohoPrisliPenia} do triedneho fondu";
        }
    }
}
