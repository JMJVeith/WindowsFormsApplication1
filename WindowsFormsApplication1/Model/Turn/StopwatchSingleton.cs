using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RealmWars
{
    /// <summary>
    /// Diagnostic Stopwatches do not release resources, so I made a Singleton wrapper to ensure that we do not get runaway memory loss
    /// </summary>
    class StopwatchSingleton
    {
        private static StopwatchSingleton watch1;

        private Stopwatch watch;

        private StopwatchSingleton(){ }

        public static StopwatchSingleton initialize()
        {
            if(watch1 == null)
            {
                watch1 = new StopwatchSingleton();
                watch1.watch = new Stopwatch();
            }
            return watch1;
        }

        /// <summary>
        /// Implements the Stopwatch  Start method
        /// </summary>
        public void Start()
        {
            watch.Start();
        }

        /// <summary>
        /// Implements the Stopwatch  Reset method
        /// </summary>
        public void Reset()
        {
            watch.Reset();
        }

        /// <summary>
        /// Implements the Stopwatch  Stop method
        /// </summary>
        public void Stop()
        {
            watch.Stop();
        }

        public int getWatchTime()
        {
            return (int)watch.Elapsed.TotalMilliseconds;
        }
    }
}
