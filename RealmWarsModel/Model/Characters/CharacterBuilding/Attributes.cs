using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWarsModel
{
    public class Attributes
    {
        private static Random rnd = new Random();

        //Bonus Types:
        //  Base (always 10)
        //  Mind
        //  Body
        //  Soul
        //  Divine
        //  Enhancement
        //  Alchemical
        //  Size?
        //  More?

        /// <summary>
        /// Affects Damage, Speed (based on weight), a few status resistances, and minimum equip value for weapons
        /// </summary>
        public int strength { get; }

        /// <summary>
        /// Affects Penetration, Crit, Hit Chance, Block (especially Parrying), 
        /// </summary>
        public int dexterity { get; }

        /// <summary>
        /// Affects Dodge, Speed, Defense, and my amusement
        /// </summary>
        public int agigity { get; }

        /// <summary>
        /// Affects Health, Stamina, Defense, Resistances
        /// </summary>
        public int constitution { get; }

        //#########################################################################

        /// <summary>
        /// Affects Magic Power, Mana, and Ability to Learn
        /// </summary>
        public int intelligence { get; }

        /// <summary>
        /// Affects Leveling Speed, Leadership, and Ability to Learn
        /// </summary>
        public int wisdom { get; }

        /// <summary>
        /// Afffects Leadership, Persuasion, Reputation
        /// </summary>
        public int charisma { get; }

        /// <summary>
        /// Affects Ability to Learn,
        /// </summary>
        public int creativity { get; }

        /// <summary>
        /// Affects Leveling Speed, fatigue effectiveness
        /// </summary>
        public int willpower { get; }

        //###########################################################################


        public Attributes(int lowest, int highest)
        {
            this.strength = rnd.Next(lowest, highest);
            this.dexterity = rnd.Next(lowest, highest);
            this.agigity = rnd.Next(lowest, highest);
            this.constitution = rnd.Next(lowest, highest);
            this.intelligence = rnd.Next(lowest, highest);
            this.wisdom = rnd.Next(lowest, highest);
            this.charisma = rnd.Next(lowest, highest);
            this.willpower = rnd.Next(lowest, highest);

            calcSecondaryStats();
        }

        /// <summary>
        /// //0-MinAD: minimum basic attack damage.
        /// //1-MaxAD: maximum basic attack Damage.
        /// </summary>
        public int[] AttackDamage { get; set; } = new int[2];

        /// <summary>
        /// 0-HitChance:  Score check vs Opponent's Dodge
        /// 1-CritChance: Base chance of Crit
        /// 2-CritDamage: Damage Multiplier on Crit
        /// 3-CritChain:  Number of Crits you can "chain" in one hit
        /// </summary>
        public int[] hit { get; set; } = new int[4];
        
        //############################################################################
        
        /// <summary>
        /// 0-maxHealth
        /// 1-currHealth
        /// 2-healthRegen
        /// </summary>
        public int[] Health { get; set; } = new int[1];

        //##############################################################################

        /// <summary>
        /// 0-Dodge:   Minus enemy hit chance;
        /// 1-Evasion: Percent AOE Damage reduction (doubled against allies);
        /// </summary>
        public int[] dodge { get; set; } = new int[2];

        /// <summary>
        /// 0-BaseSpeed: ;
        /// 1-AtkSpeed;
        /// 2-ChargeSpeed;
        /// </summary>
        public int[] speed { get; set; } = new int[1];//base actions per second, 10==1, 100==10, linear scaling//20==average adult

        private void calcSecondaryStats()
        {
            speed[0] = agigity;
            Health[0] = 10 * constitution;
            ///Min Attack
            AttackDamage[0] = (int)((double)strength * 4 / 5);
            ///Max Attack
            AttackDamage[1] = (int)((double)strength * 6 / 5);
            ///Hit Chance
            hit[0] = 100 * dexterity;
            ///Base Crit Chance %
            hit[1] = 5;
            ///Crit Damage Multiplier in %
            hit[2] = 150;
            ///Crit Multiplication Limit
            hit[3] = 2;

            ///Dodge Chance
            dodge[0] = 100 * agigity - 500 > 100 ? 100 * agigity - 500 : 100;
        }
    }
}
