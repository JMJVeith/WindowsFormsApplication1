using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace RealmWarsModel
{
    public class Phase
    {
        private PhaseTime timeHandler { get; }



        /// <summary>
        /// Constructs an instance of a phase
        /// </summary>
        /// <param name="interval">Duration of the phase in ms</param>
        public Phase(int interval)
        {
            this.timeHandler = new PhaseTime(interval);
        }

        public Phase(int interval, EventHandler end_of_phase_action)
        {
            this.timeHandler = new PhaseTime(interval);
            timeHandler.timer.Tick += end_of_phase_action;
        }


        public void start_phase()
        {
            timeHandler.start();
        }

        /// <summary>
        /// Releases the held resources for Garbage Collection (I think)
        /// </summary>
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

        //private EventHandler end_of_turn_action;
    }
}
