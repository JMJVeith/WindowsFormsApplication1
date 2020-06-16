using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWarsModel
{
    class NPCCombatant : ICombatant
    {
        public String name { get; }

        public IAbility attack { get; }

        public Attributes attributes { get; }

        private Reporter<string> reporter;

        public NPCCombatant(PlayerCharacter owner)
        {
            this.name = owner.name;
            this.reporter = reporter;
            this.attributes = owner.attributes;
            this.attack = new basicAttack(this, 1000);
        }

        public NPCCombatant(string name, Attributes attributes)
        {
            this.name = name;
            this.attributes = attributes;
            this.attack = new basicAttack(this, 1000);
        }

        public Turn make_turn()
        {
            return new NPCTurn(this, reporter);
        }

        public string activate(ICombatant target)
        {
            //start turn
            //end turn
            return attack.activate(target);
            //report damage
            //remove damage report from battle arena
        }

        public double calc_turn_timing(double baseTime)
        {
            return baseTime / (baseTime + (500 * Math.Pow(1.05, attributes.agigity)));
        }

        public int get_health()
        {
            return attributes.Health[0];
        }
    }
}
