using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace RealmWarsModel
{
    public class BattleArena
    {
        public delegate void EventHandler();



        public BattleArena()
        {
            Combatants = new List<ICombatant>();

            Combatants.Add(new PCCombatant(new PlayerCharacter("James")));
            Combatants.Add(new EnemyAICombatant(new PlayerCharacter("Orc")));

            timeline = new Timeline(Combatants);
        }



        public Timeline timeline { get; set; }

        private List<ICombatant> Combatants;



        public string attack(ICombatant enemy)
        {
            //perform action
            string r_msg = timeline.getActivePlayer().activate(enemy);//only deals damage

            //updates the timeline values
            //timeline.update();
            //starts the next turn
            timeline.next_turn();

            return r_msg;
        }

        public void add_combatant(ICombatant combatant)
        {
            Combatants.Add(combatant);
        }

        public List<ICombatant> get_combatants()
        {

            return Combatants;
        }
    }
}