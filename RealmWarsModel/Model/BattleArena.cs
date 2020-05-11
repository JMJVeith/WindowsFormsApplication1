using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace RealmWarsModel
{
    public class BattleArena
    {
        private Turn currentTurn;

        //public PlayerCharacter active_character { get; }

        public delegate void EventHandler();



        public BattleArena()
        {
            Combatants = new List<ICombatant>();

            Combatants.Add(new PCCombatant(new PlayerCharacter("James")));
            Combatants.Add(new EnemyAICombatant(new PlayerCharacter("Orc")));

            timeline = new Timeline(this);

            currentTurn = timeline.getNextTurn();
        }


        public Timeline timeline;// { get; set; }// = new List<PlayerTurn>();
        private List<ICombatant> Combatants;// { get;}



        public string attack(ICombatant enemy)
        {
            //ends the current turn before the timer runs out
            currentTurn.stopTurn();

            string msg = timeline.getActivePlayer().activate(enemy);

            //starts the next turn
            timeline.next_turn();

            return msg;
        }

        public void add_combatant(ICombatant combatant)
        {
            Combatants.Add(combatant);
        }

        public List<ICombatant> get_combatants()
        {

            return Combatants;
        }

        public double get_turn_percentage()
        {
            return currentTurn.get_turn_percentage();
        }
    }
}