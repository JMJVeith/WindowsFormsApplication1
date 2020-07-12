using System;

namespace RealmWarsModel
{
    class basicAttack : IAbility
    {
        public readonly String name;

        private readonly ICombatant user;

        public int timeCost { get; }

        private static readonly Random rnd = new Random();

        public basicAttack(ICombatant player, int timeCost)
        {
            this.timeCost = timeCost;
            this.user = player;
            this.name = "attack";
        }

        public string activate(ICombatant target)
        {
            int damage = handle_damage(target);

            target.attributes.Health[0] -= damage;

            return generateAbilityLog(target, damage);
        }

        private int handle_damage(ICombatant target)
        {
            if (calc_chance_to_hit(target) < rnd.Next(0, 100))
            {
                return 0;
            }

            //Crit Calc
            int critCount = crit_count(target);

            int damage = CalcDamage(critCount);

            return damage;
        }

        private int calc_chance_to_hit(ICombatant target)
        {
            int chance_to_hit = (int)
                (100 * user.attributes.hit[0] / (double)
            //  ------------------------------------
                (user.attributes.hit[0] + target.attributes.dodge[0]));
            return chance_to_hit;
        }

        private string generateAbilityLog(ICombatant target, int damage)
        {
            string log = user.name + " attacks " + target.name + " for " + damage + " damage";
            //ConsoleEntity.print(user.name + " attacks " + target.name + " for " + damage + " damage");
            return log;
        }

        private int crit_count(ICombatant target)
        {
            //Crit Calc
            int critCount = 0;
            //Lets you know if the previous calc whas a crit
            bool critChain = true;

            do
            {
                //if you dont crit
                if (CalcCritChance(critCount, target) < rnd.Next(0, 1000))
                {
                    return critCount;
                }
                //if you do crit
                else
                {
                    critCount++;
                    //critChain = true;
                }
            } while (critChain);
            return critCount;
        }

        private int CalcCritChance(int critCount, ICombatant target)
        {
            int Carry = (critCount + 1) * target.attributes.dodge[0];
            if (critCount * target.attributes.dodge[0] >= user.attributes.hit[0])
            {
                return 0;
            }
            return (int)(10 * user.attributes.hit[1] * user.attributes.hit[0] / (double)(user.attributes.hit[0] + Carry));
        }

        private int CalcDamage(int critCount)
        {
            return rnd.Next(user.attributes.AttackDamage[0], user.attributes.AttackDamage[1]) *
                                    (int)(Math.Pow((double)user.attributes.hit[2] / 100, critCount));
        }
    }
}
