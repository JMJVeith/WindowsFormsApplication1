using System.Collections.Generic;


namespace RealmWarsModel
{
    public class BattleArena
    {
        public delegate void EventHandler();


        public BattleArena()
        {
            Combatants = new List<ICombatant>();

            Combatants.Add(new PCCombatant(new PlayerCharacter("James")));
            Combatants.Add(new NPCCombatant(new PlayerCharacter("Orc")));

            timeline = new Timeline(Combatants);
        }



        public Timeline timeline { get; set; }

        private List<ICombatant> Combatants;



        public string attack(ICombatant enemy)
        {
            //this should not exist

            //attack
            string r_msg = timeline.active_player_turn.activate(enemy);

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

        public ICombatant get_enemy()
        {
            return timeline.get_enemy();
        }
    }
}