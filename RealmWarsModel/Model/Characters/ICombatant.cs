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

        string activate(ICombatant target);

        Turn make_turn();

        double calc_turn_timing(double baseTime);//move to turn?

        int get_health();
    }
}
