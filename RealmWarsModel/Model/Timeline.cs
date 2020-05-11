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

        public List<Turn> turns { get; set; }


        public Timeline(BattleArena battle)
        {
            this.battle = battle;
            turns = new List<Turn>();

            fill();
            sort();

            next_turn_time = turns[0].time_until_turn;
        }

        public double next_turn_time { get; set; }

        private void sort()
        {
            turns.Sort((x, y) => x.time_until_turn.CompareTo(y.time_until_turn));// x.owner.attributes.speed[0].CompareTo(-1 * y.owner.attributes.speed[0]));
        }

        public void next_turn()
        {
            end_turn();
            start_next_turn();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The Next Turn in turn order, including the current turn</returns>
        internal Turn getNextTurn()
        {
            return turns[0].owner.makeTurn();
        }

        /// <summary>
        /// Goes through all the Turns in the timeline and progresses time forward by a fixed amount (to the start of the next turn)
        /// gets called after each attack
        /// updates everything in the list
        /// </summary>
        public void update()
        {
            foreach (Turn t in turns)
            {
                Console.WriteLine("" + t.time_until_turn);
            }

            next_turn_time = turns[0].time_until_turn;

            for (int i = 0; i < turns.Count; i++)
            {
                turns[i].time_until_turn -= next_turn_time;
                
                Console.WriteLine("" + turns[i].time_until_turn);
            }
            for (int i = 0; i < turns.Count; i++)
            {
                if (turns[i].time_until_turn < 0)
                {
                    turns[i].time_until_turn = turns[i].owner.calc_turn_timing(500);
                }
            }

        }

        private void fill()
        {
            foreach (ICombatant combatant in battle.get_combatants())
            {
                turns.Add(new PlayerTurn(combatant));
            }
        }

        public ICombatant getActivePlayer()
        {
            return turns[0].owner;
        }

        public ICombatant getEnemy()
        {
            return turns[1].owner;
        }

        private void stop_turn()
        {
            turns[0].stopTurn();
        }

        public void start_next_turn()
        {
            turns[0].startTurn();
        }

        public void end_turn()
        {
            stop_turn();
            new_turn();
            sort();

            next_turn_time = turns[0].time_until_turn;
        }

        private void new_turn()
        {
            //Console.WriteLine("" + turns[0].time_until_turn);
            Turn t = turns[0].copy();
            turns.Add(t);
            //turns.Add(new PlayerTurn(turns[0].owner));
            //turns are mutually exclusive
            turns.RemoveAt(0);
            //next_turn_time = turns[0].time_until_turn;
            //Console.WriteLine("" + turns[0].time_until_turn);
            //foreach(Turn turn in turns)
            //{
            //    Console.WriteLine("" + turn.owner.name);
            //}
        }

        private void clone_turns()
        {
            List<Turn> t = turns;
            foreach (PlayerTurn turn in turns)
            {
                turn.time_until_turn = 4;
                t.Add(turn);
            }
            turns = t;
        }
    }
}
