using System;
using System.Windows.Forms;
using RealmWarsModel;
using RealmWarsModelTest;
using RealmWarsTestView;

namespace RealmWarsController
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
            TestView view = new TestView(battle);

            Application.Run(view);
        }
    }
}