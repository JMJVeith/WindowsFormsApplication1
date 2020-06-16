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
        /// <summary>
        /// The phase where no penalty is applied to speed for acting slowly
        /// </summary>
        private Phase freePhase;

        /// <summary>
        /// The main action phase.  Every millisecond spent in this phase delays your next turn.
        /// </summary>
        private Phase ActionPhase;


        public PlayerTurn(ICombatant owner)
        {
            initialize_phases();
            this.owner = owner;
            time_until_turn = this.owner.calc_turn_timing(500);
        }

        private void initialize_phases()
        {
            this.phases = new List<Phase>();
            current_phase = 0;

            freePhase = new Phase(200, new EventHandler(next_phase));
            ActionPhase = new Phase(1000, new EventHandler(end_turn));

            phases.Add(freePhase);
            phases.Add(ActionPhase);
        }

        private void next_phase(Object myObject, EventArgs eventArgs)
        {
            //.if the turn was stopped ahead of time
            if (stopped)
            {return;}

            //Starts the timer for the next phase
            current_phase += 1;
            phases[current_phase].start_phase();
        }

        private void end_turn(Object myObject, EventArgs eventArgs)
        {
            dispose();
        }

        public override bool button()
        {
            return true;
        }
    }
}