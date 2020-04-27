using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWars
{
    interface IAbility
    {
        int timeCost { get; }

        int activate(ICombatant target);
    }
}
