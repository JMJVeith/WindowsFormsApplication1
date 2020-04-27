///Creates a Timeline for the Battle Arena Model
///Creates a List ordered based on speed
///Functions:
///     

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWarsModel
{
    public class Timeline
    {
        private readonly BattleArena battle;

        public List<PlayerTurn> timeline { get; set; }


        public Timeline(BattleArena battle)
        {
            this.battle = battle;
            timeline = new List<PlayerTurn>();

            fill();
            sort();
        }

        public int nextTurnTime { get; set; }

        private void sort()
        {
            timeline.Sort((x, y) => x.owner.attributes.speed[0].CompareTo(-1 * y.owner.attributes.speed[0]));
        }

        public void next_turn()
        {
            end_turn();
            start_turn();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The Next Turn in turn order, including the current turn</returns>
        internal Turn getNextTurn()
        {
            return timeline[0].owner.makeTurn();
        }

        /// <summary>
        /// Goes through all the Turns in the timeline and progresses time forward to the start of the next turn
        /// </summary>
        /// <param name="time"></param>
        public void update(int time)
        {
            for( int i = 0; i < timeline.Count; i++)
            {
                if (timeline[0].timeUntilTurn < time)
                {
                    throw new Exception("update failed: argument time too large");
                }
                timeline[0].timeUntilTurn -= time;
            }
            //battle.updateTimeline(this);
        }

        private void fill()
        {
            foreach (ICombatant combatant in battle.get_combatants())
            {
                timeline.Add(new PlayerTurn(combatant));
            }
        }

        public ICombatant getActivePlayer()
        {
            return timeline[0].owner;
        }

        public ICombatant getEnemy()
        {
            return timeline[1].owner;
        }

        private void stop_turn()
        {
            timeline[0].stopTurn();
        }

        public void start_turn()
        {
            timeline[0].startTurn();
        }

        public void end_turn()
        {
            stop_turn();
            timeline.Add(timeline[0]);
            timeline.RemoveAt(0);
        }
    }
}
