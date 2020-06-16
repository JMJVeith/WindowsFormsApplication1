using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWarsModel
{
    public class PCCombatant : ICombatant
    {
        public String name { get; }
        public Attributes attributes { get; }
        public IAbility attack { get; }

        public PCCombatant(PlayerCharacter owner)
        {
            this.name = owner.name;
            this.attributes = owner.attributes;
            this.attack = new basicAttack(this, 1000);
        }

        public PCCombatant(String name, Attributes attributes)
        {
            this.name = name;
            this.attributes = attributes;
            this.attack = new basicAttack(this, 1000);
        }

        public Turn make_turn()
        {
            return new PlayerTurn(this);
        }

        public string activate(ICombatant enemy)
        {
            return attack.activate(enemy);

            //add turn handling
            //send request to timeline
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
