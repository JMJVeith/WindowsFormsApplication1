using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWars
{
    class PCCombatant : ICombatant
    {
        public String name { get; }
        public Attributes attributes { get; }
        public IAbility attack { get; }
        private BattleArena Battle;

        public PCCombatant(PlayerCharacter owner, BattleArena Battle)
        {
            this.name = owner.name;
            this.attributes = owner.attributes;
            this.Battle = Battle;
            this.attack = new basicAttack(this, 1000);
        }

        public Turn makeTurn()
        {
            return new PlayerTurn(Battle, this);
        }

        public void start_turn() { }

        public void activate(ICombatant enemy)
        {
            int damage = attack.activate(enemy);

            Battle.printStuff(this.name + " attacks " + enemy.name + " dealing " + damage + " damage");
            Battle.Host.displayHP(this, enemy);

            if (enemy.Health() <= 0)
            {
                Battle.printStuff(name + " Wins :)");
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
