using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace RealmWars
{
    class Phase
    {
        public PhaseTime phaseTime { get; }



        /// <summary>
        /// Constructs an instance of a phase
        /// </summary>
        /// <param name="interval">Duration of the phase in ms</param>
        public Phase(int interval)
        {
            this.phaseTime = new PhaseTime(interval);
        }

        public Phase(int interval, EventHandler end_of_phase_action)
        {
            this.phaseTime = new PhaseTime(interval);
            phaseTime.timer.Tick += end_of_phase_action;
        }


        public void start_phase()
        {
            phaseTime.start();
        }

        /// <summary>
        /// Releases the held resources for Garbage Collection (I think)
        /// </summary>
        public void dispose()
        {
            phaseTime.dispose();
        }

        /// <summary>
        /// Gets the elapsed time
        /// </summary>
        /// <returns>The total elapsed time as recorded by the stopwatch</returns>
        public int getWatchTime()
        {
            return (int)phaseTime.watch.getWatchTime();
        }

        public int getInterval()
        {
            return phaseTime.timer.Interval;
        }
    }
}
