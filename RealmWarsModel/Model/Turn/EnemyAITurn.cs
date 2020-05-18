using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWarsModel
{
    class EnemyAITurn : Turn
    {
        private readonly Phase ActionPhase;

        public EnemyAITurn(ICombatant owner)
        {
            this.phases = new List<Phase>();
            this.owner = owner;
            //timeUntilTurn = this.owner.calc_time_cost(500);

            //currentPhase = 0;
            //timeOut = false;

            ActionPhase = new Phase(400);
            ActionPhase.add_end_event(new EventHandler(attack));
            phases.Add(ActionPhase);
        }

        override
        public Turn copy()
        {
            return this;
        }

        override
        public void startTurn()
        {

        }

        override
        public void stop_turn_timers()
        {

        }

        private void attack(Object myObject, EventArgs eventArgs)
        {
            //owner.activate(battle.get_combatants()[1]);
        }

    }
}
