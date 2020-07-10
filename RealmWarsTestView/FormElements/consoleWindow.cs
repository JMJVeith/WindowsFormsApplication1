using System.Windows.Forms;
using View;

namespace RealmWarsTestView
{
    public class consoleWindow : IConsole
    {
        private ListBox console;

        public consoleWindow(ListBox listBox)
        {
            this.console = listBox;
            View.ConsoleEntity.initialize(this);
        }

        public void clear()
        {
            this.console.Items.Clear();
        }

        public void print(string msg)
        {
            console.Items.Insert(0, msg);
        }
    }
}
