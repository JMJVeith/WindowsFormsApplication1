using System;
using System.Collections.Generic;

namespace RealmWarsModel
{
    public class Timeline
    {
        public List<Turn> timeline { get; set; }

        List<ICombatant> combatants;

        public activeCharacterTurn active_player_turn { get; set; }

        public double next_turn_time { get; set; }

        public Timeline(List<ICombatant> combatants)
        {
            this.combatants = combatants;
            timeline = new List<Turn>();
            fill();
        }

        public void sort()
        {
            timeline.Sort((x, y) => x.time_until_turn.CompareTo(y.time_until_turn));

            update_times();
        }

        //fills the list of turns, based off of the list of combatants
        //needs to fill the list of combatants
        public void fill()
        {
            timeline.Clear();

            foreach (ICombatant combatant in combatants)
            {
                timeline.Add(combatant.make_turn());
            }

            sort();
        }

        public void update_times()
        {
            set_next_turn();

            for (int i = 0; i < timeline.Count; i++)
            {
                timeline[i].time_until_turn -= next_turn_time;
            }
        }

        public void set_next_turn()
        {
            this.active_player_turn = new activeCharacterTurn(timeline[0]);
            this.active_player_turn.button();

            next_turn_time = active_player_turn.time_until_turn;
        }

        public ICombatant get_enemy()
        {
            return timeline[1].owner;
        }

        public List<String> print_timeline()
        {
            List<String> s = new List<String>();
            for (int i = 0; i < timeline.Count; i++)
            {
                s.Add(timeline[i].to_string());
            }
            return s;
        }

        public void add(ICombatant combatant)
        {
            combatants.Add(combatant);
            timeline.Add(combatant.make_turn());
            fill();
        }
    }
}
