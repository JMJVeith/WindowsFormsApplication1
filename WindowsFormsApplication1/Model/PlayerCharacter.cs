using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealmWars
{
    class PlayerCharacter : ICharacter
    {
        //Object that handles combat for the player character
        private readonly PCCombatant combatant;

        public PlayerCharacter(string name, BattleArena Battle)
        {
            this.name = name;
            this.attributes = new Attributes(8, 14);
            this.combatant = new PCCombatant(this, Battle);
        }

        public string name { get; set; }

        //Holds all the primary and secondary stats that this character has
        public Attributes attributes { get; }
    }
}