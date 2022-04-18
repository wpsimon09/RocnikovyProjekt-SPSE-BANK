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
        public PlatobnySystem()
        {
            ListPrijmov = new List<Prijmy>();
            ListVydavkov = new List<Výdavky>();
        }

        public void InkasoNaBeznyUcet()
        {
            //TODO: Vytvoriť objekt list prijmov
            CelkovaSuma = CelkovaSuma + InkasovanaSuma;
            ListPrijmov.Add(new Prijmy((App.Current as App).PlatobnySistem));
            
        }

        public async void PlatbaZBeznehoUctu()
        {
            if(PlatenaSuma>CelkovaSuma)
            {
                MessageDialog msg = new MessageDialog("Nemáte dostatok peňazí", "Platba nebola uspešná");
                await msg.ShowAsync();
            }
            else
            {
                CelkovaSuma = CelkovaSuma - PlatenaSuma;
            }
        }

        

        public void Update()
        {
            (App.Current as App).PlatobnySistem = this;
        }
    }
}
