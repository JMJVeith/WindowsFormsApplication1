using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            battleController battle = new battleController();
        }

        public static void create_form(Form1 form)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form);
        }
    }
}