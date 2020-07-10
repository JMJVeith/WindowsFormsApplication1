using System;

namespace RealmWarsModel
{
    public interface ICombatant
    {
        String name { get; }

        IAbility attack { get; }

        Attributes attributes { get; }

        void activate(ICombatant target);

        Turn make_turn(TurnManager timeline);

        double calc_turn_timing(double baseTime);

        int get_health();

        string display();
    }
}
