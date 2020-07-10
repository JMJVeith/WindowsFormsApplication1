using System;
using View;

namespace RealmWarsModel
{
    public class NPCTurn : Turn
    {
        private Phase action_phase;

        public NPCTurn(ICombatant owner, TurnManager timeline) : base(owner, timeline)
        {
            time_until_turn = this.owner.calc_turn_timing(500);

            action_phase = new Phase(400, new EventHandler(action));

            phases.Add(action_phase);
        }

        public override bool button()
        {
            attackButtonEntity.button(false);
            return false;
        }

        private void action(Object myObject, EventArgs eventArgs)//runs after .4 seconds
        {
            owner.attack.activate(owner);//attacks self temporarly
            timeline.next_turn();
        }
    }
}
