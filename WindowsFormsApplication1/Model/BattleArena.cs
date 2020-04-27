using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealmWars
{
    class BattleArena
    {
        public Form1 Host;

        public Turn currentTurn { get; set; }

        public PlayerCharacter active_character { get; }

        public delegate void EventHandler();



        public BattleArena(Form1 Host)
        {
            this.Host = Host;
            Combatants = new List<ICombatant>();

            Combatants.Add(new PCCombatant(new PlayerCharacter("James", this), this));
            //combatants.Add(new PlayerObjectModel("Ally", ref Battle));
            Combatants.Add(new EnemyAICombatant(new PlayerCharacter("Orc", this), this));
            //combatants.Add(new PlayerObjectModel("They2", ref Battle));

            timeline = new Timeline(this);

            currentTurn = timeline.getNextTurn();
            printHealth();
        }


        public Timeline timeline { get; set; }// = new List<PlayerTurn>();
        public List<ICombatant> Combatants { get;}



        public void attack(ICombatant enemy)
        {
            //ends the current turn before the timer runs out
            currentTurn.stopTurn();

            timeline.getActivePlayer().activate(enemy);

            #region Phases

            //get current phase index
            int p = currentTurn.current_phase;

            //if still in free phase
            if (p != 0)
            {
                if(p >= currentTurn.phases.Count)
                {
                    p = currentTurn.phases.Count - 1;
                }
                //get time
                int time = currentTurn.phases[p].getWatchTime();

                //get timer interval
                int interval = currentTurn.phases[p].getInterval();

                //if you're too slow
                if (time > interval)
                {
                    return;
                }
            }
            /*
            //if you're too slow, you lose your turn. Your enemy then takes their turn.

            if (!currentTurn.phases[p].fastEnough())
            {
                //Allies[0].Health[0] -= HandleDamage(Enemies[0], Allies[0]);
                Host.displayHP();
                return;
            }

            //if the match isn't over
            if (Allies[0].Health[0] <= 0 || Enemies[0].Health[0] <= 0)
            {
                return;
            }
            */
            #endregion

            //starts the next turn
            timeline.next_turn();
            //currentTurn = timeline.getNextTurn();
            //currentTurn.startTurn();

            Host.updateTimeline(timeline);
        }

        public void addPlayer(PlayerCharacter player)
        {
            //timeline.
        }

        public void printStuff(string msg)
        {
            Host.printStuff(msg);
        }

        public void printHealth()
        {
            try
            {
                Host.printStuff("Ally: " + Combatants.ElementAt(0).attributes.Health[0] + ", Enemy: " + Combatants.ElementAt(1).attributes.Health[0]);
            }
            catch (IndexOutOfRangeException e)
            {
                Host.printStuff(e.ToString());
            }
        }

        public void updateTimeline(Timeline t)
        {
            Host.updateTimeline(t);
        }

        public void printSpeed(List<PlayerTurn> turns)
        {
            try
            {
                foreach (PlayerTurn turn in turns)
                {
                    Host.printStuff(turn.owner.name + ": " + turn.owner.attributes.speed[0]);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Host.printStuff(e.ToString());
            }
        }
    }
}