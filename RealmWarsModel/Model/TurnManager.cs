using System.Collections.Generic;
using View;

namespace RealmWarsModel
{
    public class TurnManager
    {
        public activeCharacterTurn active_player_turn { get; set; }

        public Timeline timeline { get; set; }


        public TurnManager(List<ICombatant> combatants)
        {
            this.timeline = new Timeline(combatants, this);
            this.active_player_turn = timeline.active_player_turn;
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
        }

        public Turn make_turn(ICombatant combatant)
        {
            return combatant.make_turn(this);
        }

        private void notify_timeline()
        {
            timelineEntity.update(timeline.print_timeline());
        }
    }
}
