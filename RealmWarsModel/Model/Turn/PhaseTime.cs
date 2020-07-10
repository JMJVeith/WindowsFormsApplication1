using System;
using System.Windows.Forms;

namespace RealmWarsModel
{
    class PhaseTime
    {
        public Timer timer { get; }

        private StopwatchSingleton watch { get; }

        public PhaseTime(int interval)
        {
            this.timer = new Timer();
            this.timer.Interval = interval;
            this.timer.Tick += new EventHandler(on_end);
            this.watch = StopwatchSingleton.initialize();
        }

        public void start()
        {
            watch.start();
            timer.Start();
        }

        private void on_end(Object myObject, EventArgs eventArgs)
        {
            timer.Stop();
            watch.reset();
        }

        public void dispose()
        {
            timer.Stop();
            timer.Dispose();
            watch.stop();
        }

        public int get_watch_time()
        {
            return (int)watch.get_watch_time();
        }
    }
}
