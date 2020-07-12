using System;
using System.Windows.Forms;
using RealmWarsModel;
using RealmWarsModelTest;
using RealmWarsController;

namespace RealmWarsTestView
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TestAll turnTester = new TestAll();
            turnTester.run_tests();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BattleArena battle = new BattleArena();
            battleController controller = new battleController(battle);//, view);
            TestView view = new TestView(controller);//, battle);

            Application.Run(view);
        }
    }
}