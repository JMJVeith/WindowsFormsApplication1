using System.Collections.Generic;

namespace RealmWarsModel
{
    public class BattleArena
    {
        public List<ICombatant> Combatants { get; set; }

        public BattleArena()
        {
            Combatants = new List<ICombatant>();

            Combatants.Add(new PCCombatant(new PlayerCharacter("James")));
            Combatants.Add(new NPCCombatant(new PlayerCharacter("Orc1")));
            Combatants.Add(new NPCCombatant(new PlayerCharacter("Orc2")));
        }
    }
}