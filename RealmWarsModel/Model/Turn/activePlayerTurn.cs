

namespace RealmWarsModel
{
    public class activePlayerTurn : Turn
    {
        private Turn turn;

        /// <summary>
        /// Wraps the real turn
        /// </summary>
        /// <param name="turn">The real turn that this is representing</param>
        public activePlayerTurn(Turn turn)
        {
            this.turn = turn;
            this.time_until_turn = turn.time_until_turn;
            this.owner = turn.owner;
            //this.phases = turn.phases;
            //this.current_phase = turn.current_phase;
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

        public new double get_turn_percentage()
        {
            return turn.get_turn_percentage();
        }

        public string activate(ICombatant enemy)
        {

            return turn.owner.activate(enemy);
        }
    }
}
