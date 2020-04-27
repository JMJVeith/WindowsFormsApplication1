using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWars
{
    interface ICharacter
    {
        Attributes attributes { get; }
        String name { get; }
    }
}
