using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWarsModel
{
    public abstract class Turn
    {
        public List<Phase> phases { get; set; }

        public ICombatant owner { get; set; }

        public int current_phase { get; set; }

        public double time_until_turn { get; internal set; }

        public abstract Turn copy();

        public abstract void startTurn();

        public abstract void stop_turn_timers();

        private double total_time()
        {
            double total_time = 0;
            foreach (Phase phase in phases)
            {
                total_time += phase.getInterval();
            }
            return total_time;
        }

        private double get_turn_time()
        {
            double total = 0;
            int count = 0;

            foreach (Phase phase in phases)
            {
                if (count < current_phase)
                {
                    total += phase.getInterval();
                }
                else if (count == current_phase)
                {
                    total += phases[current_phase].getWatchTime();
                }
                count += 1;
            }
            return total;
        }

        public double get_turn_percentage()
        {
            return 100 * get_turn_time() / total_time();
        }
    }
}
