using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

/*
 * Object is created at the start of a Battle or after you choose your action for your turn
 * PlayerTurn
 * EnemyTurn
 * AllyTurn
 */

namespace RealmWarsModel
{
    public class PlayerTurn : Turn
    {
        //private readonly BattleArena battle;

        //public double time_until_turn { get; set; }

        /// <summary>
        /// The phase where no penalty is applied to speed for acting slowly
        /// </summary>
        private Phase freePhase;

        /// <summary>
        /// The main action phase.  Every millisecond spent in this phase delays your next turn.
        /// </summary>
        private Phase ActionPhase;


        private bool timeOut = false;

        private bool stopped = false;


        public PlayerTurn(ICombatant owner)//, BattleArena battle)
        {
            this.phases = new List<Phase>();
            this.owner = owner;
            time_until_turn = this.owner.calc_turn_timing(500);

            current_phase = 0;
            timeOut = false;

            freePhase = new Phase(200, new EventHandler(next_phase));
            ActionPhase = new Phase(1000, new EventHandler(next_phase));

            phases.Add(freePhase);
            phases.Add(ActionPhase);
        }

        public override Turn copy()
        {
            //this.phases = new List<Phase>();
            //this.owner = owner;
            time_until_turn = this.owner.calc_turn_timing(500);

            current_phase = 0;
            timeOut = false;

            freePhase = new Phase(200, new EventHandler(next_phase));
            ActionPhase = new Phase(1000, new EventHandler(next_phase));

            phases.Clear();
            phases.Add(freePhase);
            phases.Add(ActionPhase);

            //Console.WriteLine("" + time_until_turn);

            return new PlayerTurn(this.owner);
        }

        override
        public void startTurn()
        {
            phases[current_phase].start_phase();
            //current_phase += 1;
        }

        override
        public void stopTurn()
        {
            stopped = true;
            dispose();
        }

        private void next_phase(Object myObject, EventArgs eventArgs)
        {
            //.if the turn was stopped ahead of time
            if (stopped)
            {
                return;
            }
            //.if the turn ended
            if (current_phase >= phases.Count - 1)//timeOut)
            {
                end_turn();
                return;
            }

            ///Starts the timer for the next phase
            current_phase += 1;
            phases[current_phase].start_phase();

        }

        private void end_turn()
        {
            if (timeOut)
            {
                //battle.printStuff("Too Slow: ");// + get_turn_time());
            }
            dispose();
        }

        private void dispose()
        {
            for(int i = 0; i<phases.Count-1; i++)
            {
                phases[i].dispose();
            }
        }
    }
}