using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWars
{
    interface ICombatant
    {
        String name { get; }

        IAbility attack { get; }

        Attributes attributes { get; }

        void start_turn();

        void activate(ICombatant target);

        double calc_time_cost(double baseTime);

        int Health();

        Turn makeTurn();
    }
}
