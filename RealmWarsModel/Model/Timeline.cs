///Creates a Timeline for the Battle Arena Model
///Creates a List ordered based off of time until next turn
///Functions:
///     

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmWarsModel
{
    public class Timeline: IObservable<List<String>>
    {
        private List<ICombatant> combatants;

        public IObserver<List<String>> observers;
        private IDisposable unsubscriber;

        public List<Turn> turns { get; set; }

        public double next_turn_time { get; set; }


        public Timeline(List<ICombatant> combatants)
        {
            this.combatants = combatants;
            turns = new List<Turn>();

            fill();
            sort();
        }

        public void initialize()
        {
            set_next_turn();

            update_turn_times();
        }

        private void sort()
        {
            turns.Sort((x, y) => x.time_until_turn.CompareTo(y.time_until_turn));
        }

        private void fill()
        {
            turns.Clear();

            foreach (ICombatant combatant in combatants)
            {
                turns.Add(new PlayerTurn(combatant));
            }
        }


        internal void set_next_turn()
        {
            next_turn_time = turns[0].time_until_turn;
        }

        private void update_turn_times()
        {
            for (int i = 0; i < turns.Count; i++)
            {
                turns[i].time_until_turn -= next_turn_time;
                //Console.WriteLine(turns[i].time_until_turn.ToString());//good
            }
            notify_all();
            //Console.WriteLine(turns[1].time_until_turn);
        }


        public ICombatant getActivePlayer()
        {
            return turns[0].owner;
        }

        public ICombatant getEnemy()
        {
            return turns[1].owner;
        }


        public void end_turn()
        {
            turns[0].stop_turn_timers();//ends phase timers n' shit

            retime_active_player();
            sort();

            set_next_turn();
            update_turn_times();
        }

        public void next_turn()
        {
            end_turn();
            turns[0].startTurn();
        }

        private void retime_active_player()
        {
            turns[0].time_until_turn = turns[0].owner.calc_turn_timing(500);
        }

        private List<String> print_timeline()
        {
            List<String> s = new List<String>();
            for (int i = 0; i < turns.Count; i++)
            {
                //Console.WriteLine((int)(turns[i].time_until_turn * 1000));//solved, get this to the view
                s.Add(((int)(turns[i].time_until_turn * 1000)).ToString());
            }
            return s;
        }

        public double get_turn_percentage()
        {
            return turns[0].get_turn_percentage();
        }





        public IDisposable Subscribe(IObserver<List<String>> observer)
        {
            observers = observer;

            return unsubscriber;
        }

        private void notify_all()
        {
            //Console.WriteLine(turns[1].time_until_turn);
            observers.OnNext(print_timeline());
            observers.OnCompleted();
        }
    }
}
