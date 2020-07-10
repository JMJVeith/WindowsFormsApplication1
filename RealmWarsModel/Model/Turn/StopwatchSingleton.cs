using System.Diagnostics;

namespace RealmWarsModel
{
    /// <summary>
    /// Diagnostic Stopwatches do not release resources, so I made a Singleton wrapper to ensure that we do not get runaway memory loss
    /// </summary>
    class StopwatchSingleton
    {
        private static StopwatchSingleton watch_entity;

        private Stopwatch watch;

        private StopwatchSingleton(){ }

        public static StopwatchSingleton initialize()
        {
            if(watch_entity == null)
            {
                watch_entity = new StopwatchSingleton();
                watch_entity.watch = new Stopwatch();
            }
            return watch_entity;
        }

        public void start()
        {
            watch.Start();
        }

        public void reset()
        {
            watch.Reset();
        }

        public void stop()
        {
            watch.Stop();
        }

        public int get_watch_time()
        {
            return (int)watch.Elapsed.TotalMilliseconds;
        }
    }
}
