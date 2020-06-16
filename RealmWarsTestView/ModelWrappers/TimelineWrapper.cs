using System;
using System.Collections.Generic;
using RealmWarsModel;

namespace RealmWarsTestView
{
    public class TimelineWrapper : IObserver<List<String>>
    {
        private BattleArena battle;
        private Form1 host;

        public TimelineWrapper(Form1 host, BattleArena battle)
        {
            this.host = host;
            this.battle = battle;
            get_timeline().Subscribe(this);
        }

        public bool button()
        {
            return battle.timeline.active_player_turn.button();
        }

        public Timeline get_timeline()
        {
            return battle.timeline;
        }







        public void OnNext(List<String> timeline)
        {
            host.update_timeline_list();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            return;
        }
    }
}
