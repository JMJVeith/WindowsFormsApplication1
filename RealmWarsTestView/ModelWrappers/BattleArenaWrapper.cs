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

        public List<ICombatant> combatants { get; }

        public BattleArenaWrapper()
        {
            this.battle = new BattleArena();
            this.combatants = battle.get_combatants();
        }

        public string attack()
        {
            string r_message = "";

            r_message = battle.attack(battle.timeline.getEnemy());

            return r_message;
        }

        public double get_turn_percentage()
        {
            return battle.get_turn_percentage();
        }

        public ICombatant getEnemy()
        {
            return battle.timeline.getEnemy();
        }

        public ICombatant getActivePlayer()
        {
            return battle.timeline.getActivePlayer();
        }

        public ICombatant add_combatant()
        {
            PCCombatant new_combatant = new PCCombatant("New Combatant", new Attributes(8, 12));

            battle.add_combatant(new_combatant);
            combatants.Add(new_combatant);

            return new_combatant;
        }
    }
}
