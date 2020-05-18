using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmWarsModel;

namespace RealmWarsTestView
{
    class TimelineWrapper : IObserver<List<String>>
    {
        public Timeline timeline { get; }
        private Form1 host;

        public TimelineWrapper(Form1 host, BattleArenaWrapper b)
        {
            this.host = host;
            this.timeline = new Timeline(b.combatants);
            this.timeline.Subscribe(this);
            this.timeline.initialize();
        }

        public double get_turn_percentage()
        {
            return timeline.get_turn_percentage();
        }




        public void OnNext(List<String> timeline)
        {
            host.update_timeline_list(timeline);
            //this.timeline.Subscribe(this);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            
        }
    }
}
