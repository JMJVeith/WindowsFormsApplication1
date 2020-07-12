namespace View
{
    public interface IBattleScreen
    {
        IAttackButton attack_button { get; set; }
        ICombatantsDisplay combatants { get; set; }
        IConsole console { get; set; }
        ITimeline timeline { get; set; }
    }
}
