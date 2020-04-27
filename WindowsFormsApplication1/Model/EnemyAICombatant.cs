using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWars
{
    class EnemyAICombatant : ICombatant
    {
        public String name { get; }

        public IAbility attack { get; }

        public Attributes attributes { get; }

        private readonly BattleArena battle;

        public EnemyAICombatant(PlayerCharacter owner, BattleArena Battle)
        {
            this.name = owner.name;
            this.attributes = owner.attributes;
            this.battle = Battle;
            this.attack = new basicAttack(this, 1000);
        }

        public Turn makeTurn()
        {
            return new EnemyAITurn(battle, this);
        }

        public void start_turn()
        {
            run_turn();
        }

        private void run_turn()
        {
            //wait ?0.4? seconds
            //activate ability

            //enable attack button
            //end turn
            activate(battle.Combatants[1]);
        }

        public void activate(ICombatant target)
        {
            int damage = attack.activate(target);

            battle.printStuff(this.name + " attacks " + target.name + " dealing " + damage + " damage");
            battle.Host.displayHP(this, target);

            if (target.Health() <= 0)
            {
                battle.printStuff(name + " Wins :)");
            }
        }

        public double calc_time_cost(double baseTime)
        {
            double time = baseTime / (baseTime + (500 * Math.Pow(1.05, attributes.agigity)));
            return time;
        }

        public int Health()
        {
            return attributes.Health[0];
        }
    }
}
