using System;

namespace RealmWarsModel
{
    interface ICharacter
    {
        Attributes attributes { get; }
        String name { get; }
    }
}
