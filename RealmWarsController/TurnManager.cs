using System.Collections.Generic;
using View;
using RealmWarsModel;
using System;

namespace RealmWarsController
{
    public class TurnManager : IObserver<string>
    {
        public activeCharacterTurn active_player_turn { get; set; }

        public Timeline timeline { get; set; }


        public TurnManager(List<ICombatant> combatants)
        {
            timeline = new Timeline(combatants);
            subscribe_all();
            active_player_turn = timeline.active_player_turn;
        }


        public void end_turn()
        {
            active_player_turn.end_turn();

            timeline.sort();
            active_player_turn = timeline.active_player_turn;

            notify_timeline();
        }

        public void next_turn()
        {
            end_turn();

            active_player_turn.start_turn();

            set_button(active_player_turn.button());
        }

        public static Turn make_turn(ICombatant combatant)
        {
            return combatant.make_turn();
        }

        private void notify_timeline()
        {
            timelineEntity.update(timeline.print_timeline());
        }

        private void set_button(bool button)
        {
            attackButtonEntity.button(button);
        }


        //#######################################
        public void subscribe_all()
        {
            foreach(Turn turn in timeline.timeline)
            {
                turn.Subscribe(this);
            }
        }

        public void OnNext(string msg)
        {
            ConsoleEntity.print(msg);
            next_turn();
        }

        public void OnError(Exception error) { }
        public void OnCompleted() { }
    }
}
