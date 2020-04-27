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
        Timeline timeline;

        public TimelineWrapper(BattleArena b)
        {
            this.timeline = new Timeline(b);
        }

        public ICombatant getEnemy()
        {
            return timeline.getEnemy();
        }
    }
}
