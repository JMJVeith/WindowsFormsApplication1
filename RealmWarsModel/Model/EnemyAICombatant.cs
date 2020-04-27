using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWarsModel
{
    class EnemyAICombatant : ICombatant
    {
        public String name { get; }

        public IAbility attack { get; }

        public Attributes attributes { get; }

        public EnemyAICombatant(PlayerCharacter owner)
        {
            this.name = owner.name;
            this.attributes = owner.attributes;
            this.attack = new basicAttack(this, 1000);
        }

        public Turn makeTurn()
        {
            return new EnemyAITurn(this);
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
            //activate(battle.get_combatants()[1]);
        }

        public string activate(ICombatant target)
        {
            return attack.activate(target);
        }

        public double calc_time_cost(double baseTime)
        {
            double time = baseTime / (baseTime + (500 * Math.Pow(1.05, attributes.agigity)));
            return time;
        }

        public int get_health()
        {
            return attributes.Health[0];
        }
    }
}
