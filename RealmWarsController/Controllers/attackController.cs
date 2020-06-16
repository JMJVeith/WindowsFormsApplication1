using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmWarsTestView;
using RealmWarsModel;

namespace RealmWarsController
{
    class attackController : Controller
    {
        //this is just a view
        //what do I need for a controller?
        //loose-coupling
        //send messages between view and model without coupling them together
        //controls - attack, start, add_combatant
        //send attack, return message

        //create a megacontroller
        //handles controls as well as control messages
        View<string> console;

        public attackController(View<string> console)
        {
            this.console = console;
        }

        public void attack()
        {

        }

        public void log_attack(string msg)
        {
            //sends the attack to the console window
            console.print(msg);
        }

        //get enemy
    }
}
