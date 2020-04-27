using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWarsModel
{
    interface ICharacter
    {
        Attributes attributes { get; }
        String name { get; }
    }
}
