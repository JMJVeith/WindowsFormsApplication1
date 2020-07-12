using RealmWarsModel;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using RealmWarsController;
using View;

namespace RealmWarsTestView
{
    public partial class TestView : Form, IBattleScreen
    {
        private battleController controller;

        public IConsole console { get; set; }
        public ITimeline timeline { get; set; }
        public ICombatantsDisplay combatants { get; set; }
        public IAttackButton attack_button { get; set; }

        private turnBackgroundWorker turn_progress;

        public TestView(battleController controller)
        {
            InitializeComponent();

            this.controller = controller;
            
            turn_progress = new turnBackgroundWorker(new BackgroundWorker(), new turnTimingBar(turn_timing_bar));
            this.console = new consoleWindow(console_window);
            this.timeline = new timelineWindow(timeline_window);
            this.combatants = new combatantsWindow(combatant_window);
            this.attack_button = new AttackButton(AttackButton);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ConsoleEntity.clear();
            ConsoleEntity.print("Start battle!");

            update_combatants();
            update_timeline();

            AttackButton.Enabled = true;
            add_combatant_btn.Enabled = true;
        }

        private void AttackButton_Click(object sender, EventArgs e)
        {
            controller.attack(controller.get_enemy());

            update_combatants();

            turn_progress.run();
        }

        private void add_combatant_btn_Click(object sender, EventArgs e)
        {
            ICombatant new_combatant = new NPCCombatant("Combatant", new Attributes(8, 12));

            controller.add_combatant(new_combatant);

            ConsoleEntity.print(new_combatant.name + " has joined the fight!");
            update_combatants();
            update_timeline();
        }

        public void update_timeline()
        {
            timelineEntity.update(get_turns());
        }

        public void update_combatants()
        {
            combatantsEntity.update(new List<string>(get_formatted_combatants()));
        }

        public List<string> get_turns()
        {
            return controller.manager.timeline.print_timeline();
        }

        private IEnumerable<string> get_formatted_combatants()
        {
            foreach (ICombatant combatant in controller.get_combatants())
            {
                yield return combatant.display();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            turn_progress.dispose();
        }
    }
}
