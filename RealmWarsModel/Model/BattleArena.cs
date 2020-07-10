using System.Collections.Generic;

namespace RealmWarsModel
{
    public class BattleArena
    {
        public TurnManager turn_manager { get; set; }

        private List<ICombatant> Combatants;

        public BattleArena()
        {
            Combatants = new List<ICombatant>();

            Combatants.Add(new PCCombatant(new PlayerCharacter("James")));
            Combatants.Add(new NPCCombatant(new PlayerCharacter("Orc")));
            Combatants.Add(new NPCCombatant(new PlayerCharacter("Orc")));

            turn_manager = new TurnManager(Combatants);
        }

        public void attack(ICombatant enemy)
        {
            turn_manager.active_player_turn.activate(enemy);

            turn_manager.next_turn();
        }

        public void add_combatant(ICombatant combatant)
        {
            Combatants.Add(combatant);
            turn_manager.timeline.fill();
        }

        public List<ICombatant> get_combatants()
        {
            return Combatants;
        }

        public ICombatant get_enemy()
        {
            return turn_manager.timeline.get_enemy();
        }
    }
}