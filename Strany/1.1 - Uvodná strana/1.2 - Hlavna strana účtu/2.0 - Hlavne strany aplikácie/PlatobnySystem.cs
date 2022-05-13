using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Ročňíkový_projekt___Aplikácia_pre_banku.Assets.Data;

namespace Ročňíkový_projekt___Aplikácia_pre_banku.Strany._1._1___Uvodná_strana._1._2___Hlavna_strana_účtu._2._0___Hlavne_strany_aplikácie
{
    public class PlatobnySystem:IPlatobnySystem
    {

        public void InkasoNaBeznyUcet()
        {
            CelkovaSuma = CelkovaSuma + InkasovanaSuma;
            (App.Current as App).GlobalHistoria.prijmy.Add(new Prijmy((App.Current as App).PlatobnySistem));
        }

        public bool PlatbaZBeznehoUctu()
        {
            if(PlatenaSuma>CelkovaSuma)
            {
                
                return false;
            }
            else
            {
                CelkovaSuma = CelkovaSuma - PlatenaSuma;
                (App.Current as App).GlobalHistoria.vydavky.Add(new Vydavky((App.Current as App).PlatobnySistem,0));
                return true;
            }
        }

        public void Update()
        {
            (App.Current as App).PlatobnySistem = this;
        }
    }
}