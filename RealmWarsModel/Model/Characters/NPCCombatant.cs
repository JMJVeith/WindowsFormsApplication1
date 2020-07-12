using System;

namespace RealmWarsModel
{
    public class NPCCombatant : ICombatant
    {
        public String name { get; }

        public IAbility attack { get; }

        public Attributes attributes { get; }

        public NPCCombatant(PlayerCharacter owner)
        {
            this.name = owner.name;
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
            return new NPCTurn(this);
        }

        public string activate(ICombatant target)
        {
            return attack.activate(target);
        }

        public double calc_turn_timing(double baseTime)
        {
            return baseTime / (baseTime + (500 * Math.Pow(1.05, attributes.agigity)));
        }

        public int get_health()
        {
            return attributes.Health[0];
        }

        public string display()
        {
            return $"{name,-7} HP: {get_health()}";
        }
    }
}
