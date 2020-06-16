using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmWarsModel;
using RealmWarsTestView;

namespace RealmWarsController
{
    class battleController
    {
        private Form1 host;
        public BattleArena battle { get; set; }
        private TimelineWrapper timeline;

        public battleController()
        {
            start_battle();
            this.host = new Form1(battle);
            Program.create_form(host);
        }

        public void start_battle()
        {
            //focus on refactoring battle
            this.battle = new BattleArena();
            this.timeline = new TimelineWrapper(host, battle);
        }
    }
}
