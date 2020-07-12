namespace RealmWarsModel
{
    public class activeCharacterTurn : Turn
    {
        private Turn turn;

        public activeCharacterTurn(Turn turn) : base()
        {
            this.turn = turn;
            this.time_until_turn = turn.time_until_turn;
            this.owner = turn.owner;
        }

        private void retime()
        {
            turn.time_until_turn = owner.calc_turn_timing(500);
        }

        public override bool button()
        {
            return turn.button();
        }

        public new void start_turn()
        {
            turn.start_turn();
            button();
        }

        public void end_turn()
        {
            stop_turn_timers();
            retime();
        }

        public new void stop_turn_timers()
        {
            turn.stop_turn_timers();
        }

        public string activate(ICombatant enemy)
        {
            return turn.owner.activate(enemy);
        }
    }
}
