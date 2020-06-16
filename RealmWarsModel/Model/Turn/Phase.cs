using System;

namespace RealmWarsModel
{
    public class Phase
    {
        private PhaseTime timeHandler { get; }

        ///<summary>q</summary>
        /// <param name="interval">Sets the irl turn timespan to this value</param>
        /// <param name="end_of_phase_action"></param>
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

        /// <summary>
        /// Gets the elapsed time
        /// </summary>
        /// <returns>The total elapsed time as recorded by the stopwatch</returns>
        public int getWatchTime()
        {
            return (int)timeHandler.watch.getWatchTime();
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

    public class Phase2
    {
        public int interval;

        //private EventHandler end_of_phase_action;
    }
}
