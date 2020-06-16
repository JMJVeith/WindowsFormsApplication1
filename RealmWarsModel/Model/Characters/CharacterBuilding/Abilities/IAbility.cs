using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWarsModel
{
    public interface IAbility
    {
        int timeCost { get; }

        string activate(ICombatant target);
    }
}
