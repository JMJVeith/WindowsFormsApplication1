using System;

namespace RealmWarsModel
{
    public class Phase
    {
        private PhaseTime timeHandler { get; }

        public Phase(int interval, EventHandler end_of_phase_action)
        {
            this.timeHandler = new PhaseTime(interval);
            add_end_event(end_of_phase_action);
        }


        public void start_phase()
        {
            timeHandler.start();
        }

        public void dispose()
        {
            timeHandler.dispose();
        }

        public int getWatchTime()
        {
            return timeHandler.get_watch_time();
        }

        public int getInterval()
        {
            return timeHandler.timer.Interval;
        }

        public void add_end_event(EventHandler q)
        {
            timeHandler.timer.Tick += q;
        }
    }
}
