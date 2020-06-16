using RealmWarsModel;
using System;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace RealmWarsTestView
{
    public partial class Form1 : Form
    {
        private BattleArena battle_arena;
        private TimelineWrapper timeline_wrapper;

        public consoleWindow console { get; set; }
        private timelineWindow timeline;
        private combatantsWindow combatants;

        private Reporter<Turn> reporter;

        private turnBackgroundWorker turn_progress;

        //model needs to own the interfaces, controller/view need to impliment them

        public Form1(BattleArena battle)
        {
            InitializeComponent();

            this.battle_arena = battle;

            //initialize controller
            //put everything in controller
            
            turn_progress = new turnBackgroundWorker(new BackgroundWorker(), new turnTimingBar(turn_timing_bar));

            //pass in controller?
            this.console = new consoleWindow(console_window);
            this.timeline = new timelineWindow(timeline_window);
            this.combatants = new combatantsWindow(combatant_window);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            console.clear();

            //move everything to controller
            //add reporters
            //this.battle_arena = new BattleArena();
            this.timeline_wrapper = new TimelineWrapper(this, battle_arena);


            combatants.print(battle_arena.get_combatants());

            AttackButton.Enabled = true;
            add_combatant_btn.Enabled = true;
        }

        private void AttackButton_Click(object sender, EventArgs e)
        {
            AttackButton.Enabled = false;

            string msg = battle_arena.attack(battle_arena.timeline.get_enemy());

            //skip print, let attack send the message
            console.print(msg);
            combatants.print(battle_arena.get_combatants());

            AttackButton.Enabled = timeline_wrapper.button();

            turn_progress.run();
        }

        public void update_timeline_list()
        {
            timeline.print(battle_arena.timeline.turns);
        }

        private void add_combatant_btn_Click(object sender, EventArgs e)
        {
            ICombatant new_combatant = new PCCombatant("Combatant", new Attributes(8, 12));

            battle_arena.add_combatant(new_combatant);

            console.print(new_combatant.name + " has joined the fight");

            combatants.print(battle_arena.get_combatants());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            turn_progress.dispose();
        }
    }
}
