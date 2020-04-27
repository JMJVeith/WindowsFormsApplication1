using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace RealmWars
{
    class PhaseTime
    {
        /// <summary>
        /// Sets the end point for the phase
        /// </summary>
        public Timer timer { get; }

        /// <summary>
        /// Counts the amount of time that has passed in a phase
        /// </summary>
        public StopwatchSingleton watch { get; }

        /// <summary>
        /// Creates a timer and a stopwatch and attaches an End method to the timer
        /// </summary>
        /// <param name="interval">The duration of the phase in ms</param>
        public PhaseTime(int interval)
        {
            this.timer = new Timer();
            this.timer.Interval = interval;
            this.timer.Tick += new EventHandler(End);
            this.watch = StopwatchSingleton.initialize();
        }

        /// <summary>
        /// Starts the stopwatch and timer
        /// </summary>
        public void start()
        {
            watch.Start();
            timer.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myObject"></param>
        /// <param name="eventArgs"></param>
        private void End(Object myObject, EventArgs eventArgs)
        {
            timer.Stop();
            watch.Reset();
        }

        public void dispose()
        {
            timer.Stop();
            timer.Dispose();
            watch.Stop();
        }

        public int getWatchTime()
        {
            return (int)watch.getWatchTime();
        }
    }
}
