using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmWarsModel;

namespace RealmWarsTestView
{
    class BattleArenaWrapper
    {
        public BattleArena battle { get; }

        public List<ICombatant> combatants { get; set; }

        public BattleArenaWrapper()
        {
            this.battle = new BattleArena();
            this.combatants = battle.get_combatants();
        }

        public string attack()
        {
            return battle.attack(battle.timeline.getEnemy());
        }

        public ICombatant add_combatant()
        {
            PCCombatant new_combatant = new PCCombatant("New Combatant", new Attributes(8, 12));

            battle.add_combatant(new_combatant);
            combatants = battle.get_combatants();

            return new_combatant;
        }
    }
}
