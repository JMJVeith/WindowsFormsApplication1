namespace RealmWarsModel
{
    public interface IAbility
    {
        int timeCost { get; }

        string activate(ICombatant target);
    }
}
