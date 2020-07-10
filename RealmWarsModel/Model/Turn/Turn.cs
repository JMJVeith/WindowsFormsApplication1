﻿using System.Collections.Generic;

namespace RealmWarsModel
{
    public abstract class Turn
    {
        public List<Phase> phases { get; set; }

        public ICombatant owner { get; set; }

        internal int current_phase;

        internal bool stopped = false;

        public double time_until_turn { get; internal set; }

        internal TurnManager timeline;

        public Turn() { }

        public Turn(ICombatant owner, TurnManager timeline)
        {
            this.owner = owner;
            this.timeline = timeline;

            this.phases = new List<Phase>();
            current_phase = 0;
        }



        public void start_turn()
        {
            phases[current_phase].start_phase();
        }

        public void stop_turn_timers()
        {
            stopped = true;
            dispose();
        }

        public abstract bool button();

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

        public string to_string()
        {
            return $"{owner.name,-7}: {(int)(time_until_turn * 1000)}";
        }

        internal void dispose()
        {
            for (int i = 0; i < phases.Count - 1; i++)
            {
                phases[i].dispose();
            }
        }
    }
}
