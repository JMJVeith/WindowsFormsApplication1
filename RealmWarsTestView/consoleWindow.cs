using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RealmWarsModel;

namespace RealmWarsTestView
{
    public class consoleWindow : View<string>
    {
        private ListBox console;

        public consoleWindow(ListBox listBox)
        {
            this.console = listBox;
        }

        public void print(string msg)
        {
            this.console.Items.Insert(0, msg);
        }

        public void clear()
        {
            this.console.Items.Clear();
        }
    }
}
