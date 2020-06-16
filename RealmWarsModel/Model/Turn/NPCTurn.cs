using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWarsModel
{
    public class NPCTurn : Turn
    {
        private Phase action_phase;
        private Reporter<string> reporter;

        public NPCTurn(ICombatant owner, Reporter<string> reporter)
        {
            this.owner = owner;
            this.reporter = reporter;
            this.phases = new List<Phase>();
            time_until_turn = this.owner.calc_turn_timing(500);
            current_phase = 0;

            action_phase = new Phase(400, new EventHandler(action));

            phases.Add(action_phase);
        }

        public override bool button()
        {
            return true;//change to false once messaging is set up
        }

        private void action(Object myObject, EventArgs eventArgs)//runs after .4 seconds
        {
            //how do I get a target
            //reporter.print(this.to_string());
            owner.attack.activate(owner);//attacks self temporarly
            //update button
            //send message to form

            //make Observable
            //make controller
        }
    }
}
