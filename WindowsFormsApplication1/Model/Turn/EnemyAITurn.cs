using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWars
{
    class EnemyAITurn : Turn
    {

        private readonly BattleArena battle;

        private readonly Phase ActionPhase;

        public EnemyAITurn(BattleArena battle, ICombatant owner)
        {
            this.phases = new List<Phase>();
            this.battle = battle;
            this.owner = owner;
            //timeUntilTurn = this.owner.calc_time_cost(500);

            //currentPhase = 0;
            //timeOut = false;

            ActionPhase = new Phase(400);
            ActionPhase.phaseTime.timer.Tick += new EventHandler(attack);
            phases.Add(ActionPhase);
        }

        override
        public void startTurn()
        {

        }

        override
        public void stopTurn()
        {

        }

        private void attack(Object myObject, EventArgs eventArgs)
        {
            owner.activate(battle.Combatants[1]);
        }

    }
}
