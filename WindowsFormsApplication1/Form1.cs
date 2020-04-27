using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealmWars
{
    partial class Form1 : Form
    {
        #region private variables

        private BattleArena Battle;
        private List<PlayerCharacter> combatants;
        private BackgroundWorker turn_progress_worker;

        #endregion


        public Form1()
        {
            combatants = new List<PlayerCharacter>();

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

        /// <summary>
        /// Start a new Combat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, EventArgs e)
        {
            combatants = new List<PlayerCharacter>();
            ConsoleWindow.Items.Clear();
            
            combatants.Add(new PlayerCharacter("You", Battle));
            //combatants.Add(new PlayerObjectModel("Ally", ref Battle));

            combatants.Add(new PlayerCharacter("They", Battle));
            //combatants.Add(new PlayerObjectModel("They2", ref Battle));

            Battle = new BattleArena(this);// ref combatants, this);
        }

        public void printStuff(string msg)
        {
            ConsoleWindow.Items.Insert(0,msg);
            return;
        }

        public void updateTimeline(Timeline t)
        {
            Timeline.Items.Clear();

            foreach(PlayerTurn playerturn in t.timeline)
            {
                Timeline.Items.Add("Player: " + playerturn.owner.name + ", Time Until Turn: " + (int)(playerturn.timeUntilTurn*1000));
            }
            
            return;
        }

        public void displayHP(ICombatant ally, ICombatant enemy)
        {
            label1.Text = ally.name + " HP: " + ally.attributes.Health[0];
            label2.Text = enemy.name + " HP: " + enemy.attributes.Health[0];
        }

        private void AttackButton_Click(object sender, EventArgs e)
        {
            turn_progress_bar.Value = 0;

            Battle.attack(Battle.timeline.getEnemy());

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
            while (Battle.currentTurn.get_turn_percentage() < 100)
            {
                turn_progress_worker.ReportProgress((int)Battle.currentTurn.get_turn_percentage());
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
            turn_progress_bar.Value = 100;
            //turn_progress_bar.Update();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            turn_progress_worker.Dispose();
        }
    }
}
