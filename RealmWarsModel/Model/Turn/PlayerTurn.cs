using System;

namespace RealmWarsModel
{
    public class PlayerTurn : Turn
    {
        private Phase freePhase;
        private Phase ActionPhase;


        public PlayerTurn(ICombatant owner) : base(owner)
        {
            initialize_phases();
            time_until_turn = this.owner.calc_turn_timing(500);
        }

        private void initialize_phases()
        {
            freePhase = new Phase(200, new EventHandler(next_phase));
            ActionPhase = new Phase(1000, new EventHandler(end_turn));

            phases.Add(freePhase);
            phases.Add(ActionPhase);
        }

        private void next_phase(Object myObject, EventArgs eventArgs)
        {
            if (stopped) return;

            current_phase += 1;
            phases[current_phase].start_phase();
        }

        private void end_turn(Object myObject, EventArgs eventArgs)
        {
            dispose();
        }

        public override bool button()
        {
            return true;
        }
    }
}