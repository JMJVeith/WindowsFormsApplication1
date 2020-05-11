using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWarsModel
{
    public interface ICombatant
    {
        String name { get; }

        IAbility attack { get; }

        Attributes attributes { get; }

        void start_turn();

        string activate(ICombatant target);

        double calc_turn_timing(double baseTime);

        int get_health();

        Turn makeTurn();
    }
}
