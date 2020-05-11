using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmWarsModel;

namespace RealmWarsTestView
{
    class TimelineWrapper
    {
        public Timeline timeline { get; }

        public TimelineWrapper(BattleArenaWrapper b)
        {
            this.timeline = new Timeline(b.battle);
        }

        public ICombatant getEnemy()
        {
            return timeline.getEnemy();
        }

        public void update_timeline()
        {
            timeline.update();
        }
    }
}
