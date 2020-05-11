using RealmWarsModel;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace RealmWarsTestView
{
    partial class Form1 : Form
    {
        private BattleArenaWrapper battle_wrapper;
        private BackgroundWorker turn_progress_worker;
        private TimelineWrapper timeline_wrapper;


        public Form1()
        {
            initializeBackgroundWorker();

            InitializeComponent();
        }

        private void initializeBackgroundWorker()
        {
            turn_progress_worker = new BackgroundWorker();
            turn_progress_worker.DoWork += dowork_bar;
            turn_progress_worker.ProgressChanged += updateBar;
            turn_progress_worker.RunWorkerCompleted += updateBar;
            turn_progress_worker.WorkerReportsProgress = true;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ConsoleWindow.Items.Clear();

            this.battle_wrapper = new BattleArenaWrapper();
            this.timeline_wrapper = new TimelineWrapper(battle_wrapper);

            combatant_display.Items.Clear();

            foreach (ICombatant combatant in battle_wrapper.combatants)
            {
                combatant_display.Items.Add(format_combatant(combatant));
            }

            display_combatants();
            update_timeline_list();
        }

        public void printStuff(string msg)
        {
            ConsoleWindow.Items.Insert(0,msg);
            return;
        }

        public void update_timeline_list()
        {
            timeline_wrapper.update_timeline();

            //foreach (Object item in timeline_list_box.Items)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            timeline_list_box.Items.Clear();

            foreach(PlayerTurn turn in timeline_wrapper.timeline.turns)
            {
                timeline_list_box.Items.Add("Player: " + turn.owner.name + ", Time Until Turn: " + (int)(turn.time_until_turn * 1000));
            }

            //foreach (Object item in timeline_list_box.Items)
            //{
            //    Console.WriteLine(item.ToString());
            //}
        }

        private void AttackButton_Click(object sender, EventArgs e)
        {
            turn_progress_bar.Value = 0;

            string msg = battle_wrapper.attack();

            printStuff(msg);
            update_timeline_list();
            display_combatants();

            //end player turn
            //disable attack button
            //start enemy turn

            if (!turn_progress_worker.IsBusy)
            {
                turn_progress_worker.RunWorkerAsync();
            }
        }

        private void dowork_bar(object sender, DoWorkEventArgs e)
        {
            while (battle_wrapper.get_turn_percentage() < 100)
            {
                turn_progress_worker.ReportProgress((int)battle_wrapper.get_turn_percentage());
                Thread.Sleep(20);
            }
            return;
        }

        private void updateBar(object sender, ProgressChangedEventArgs e)
        {
            turn_progress_bar.Value = e.ProgressPercentage;
            if (e.ProgressPercentage >= 1)
            {
                turn_progress_bar.Value = e.ProgressPercentage - 1;
                //printStuff(e.ProgressPercentage.ToString());
            }
            turn_progress_bar.Value = e.ProgressPercentage;
            turn_progress_bar.Update();
        }

        private void updateBar(object sender, RunWorkerCompletedEventArgs e)
        {
            //turn_progress_bar.Value = 100;
            turn_progress_bar.Update();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            turn_progress_worker.Dispose();
        }

        private void add_combatant_btn_Click(object sender, EventArgs e)
        {
            ICombatant new_combatant = battle_wrapper.add_combatant();
            printStuff(new_combatant.name + " has joined the fight");

            combatant_display.Items.Add(format_combatant(new_combatant));

            display_combatants();
        }

        private string format_combatant(ICombatant combatant)
        {
            return combatant.name + " HP: " + combatant.get_health();
        }

        private void display_combatants()
        {
            int count = 0;
            foreach (ICombatant combatant in battle_wrapper.combatants)
            {
                combatant_display.Items[count] = format_combatant(combatant);
                count++;
            }
        }
    }
}
