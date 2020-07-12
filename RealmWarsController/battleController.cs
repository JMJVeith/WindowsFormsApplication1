using RealmWarsModel;
using System.Collections.Generic;
using View;

namespace RealmWarsController
{
    public class battleController
    {
        public BattleArena battle { get; set; }

        public TurnManager manager { get; set; }

        public battleController(BattleArena battle)
        {
            this.battle = battle;
            this.manager = new TurnManager(battle.Combatants);
        }

        public BattleArena new_battle()
        {
            battle = new BattleArena();
            return this.battle;
        }

        public void attack(ICombatant target)
        {
            string msg = manager.active_player_turn.activate(target);

            ConsoleEntity.print(msg);

            manager.next_turn();
        }

        public void add_combatant(ICombatant combatant)
        {
            battle.Combatants.Add(combatant);
            manager.timeline.fill();
            manager.subscribe_all();
        }

        public ICombatant get_enemy()
        {
            return manager.timeline.get_enemy();
        }

        public List<ICombatant> get_combatants()
        {
            return battle.Combatants;
        }
    }
}
