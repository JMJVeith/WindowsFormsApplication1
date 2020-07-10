namespace RealmWarsModel
{
    public interface IAbility
    {
        int timeCost { get; }

        void activate(ICombatant target);
    }
}
