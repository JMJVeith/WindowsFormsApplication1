///Creates a Timeline for the Battle Arena Model
///Creates a List ordered based off of time until next turn
 

using System;
using System.Collections.Generic;

namespace RealmWarsModel
{
    public class Timeline: IObservable<List<String>>
    {
        private List<ICombatant> combatants;

        public activePlayerTurn active_player_turn { get; set; }

        public IObserver<List<String>> observer;

        public List<Turn> turns { get; set; }

        public double next_turn_time { get; set; }


        public Timeline(List<ICombatant> combatants)
        {
            this.combatants = combatants;
            turns = new List<Turn>();

            fill();
            //data clump
            sort();
            active_player_turn = new activePlayerTurn(turns[0]);
            set_next_turn();
            update_times();
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
                turns.Add(combatant.make_turn());//factory?
            }
        }


        internal void set_next_turn()
        {
            next_turn_time = active_player_turn.time_until_turn;
        }

        private void update_times()
        {
            for (int i = 0; i < turns.Count; i++)
            {
                turns[i].time_until_turn -= next_turn_time;
            }
        }

        public ICombatant get_enemy()
        {
            return turns[1].owner;
        }


        public void end_turn()
        {
            active_player_turn.end_turn();

            ////data clump
            sort();
            //wat dis?get new active player
            active_player_turn = new activePlayerTurn(turns[0]);
            //update times
            set_next_turn();
            update_times();

            notify_timeline();
        }

        public void next_turn()
        {
            end_turn();
            active_player_turn.start_turn();
            //get next turn, if player character, enable attack button
            //button should enable/disable the button directly
            active_player_turn.button();
        }

        public List<String> print_timeline()
        {
            List<String> s = new List<String>();
            for (int i = 0; i < turns.Count; i++)
            {
                s.Add(turns[i].to_string());
            }
            return s;
        }





        public IDisposable Subscribe(IObserver<List<String>> observer)
        {
            this.observer = observer;

            return null;
        }

        private void notify_timeline()
        {
            observer.OnNext(print_timeline());
        }
    }
}
