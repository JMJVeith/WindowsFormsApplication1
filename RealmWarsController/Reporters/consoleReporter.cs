using RealmWarsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RealmWarsTestView;

namespace RealmWarsController
{
    class consoleReporter : Reporter<string>
    {
        //################################################
        //send turn controlers to report attack and generate targets and update the buttons
        //reporter - sends info to view controls
        //controllers - Player controller, AI Controller
        //################################################

        View<string> console;

        public consoleReporter(View<string> console)
        {
            this.console = console;
        }

        public void print(string msg)
        {
            console.print(msg);
        }
    }
}
