using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWarsModel
{
    class TimelineObservable : IObservable<List<String>>
    {
        private Timeline timeline;
        private IObserver<List<String>> observers;

        public TimelineObservable(Timeline timeline)
        {
            this.timeline = timeline;
        }

        public IDisposable Subscribe(IObserver<List<String>> observer)
        {
            observers = observer;

            return null;
        }

        private void notify_all()
        {
            //Console.WriteLine(turns[1].time_until_turn);
            //observers.OnNext(print_timeline());
            observers.ToString();
        }
    }
}
