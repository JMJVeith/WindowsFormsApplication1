using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RealmWarsModel;

namespace RealmWarsTestView
{
    class timelineWindow :View<List<Turn>>
    {
        ListBox timeline_display;

        public timelineWindow(ListBox timeline_display)
        {
            this.timeline_display = timeline_display;
        }

        public void print(List<Turn> turns)
        {
            clear();

            foreach (Turn turn in turns)
            {
                timeline_display.Items.Add(format_turn(turn));
            }
        }

        private void clear()
        {
            timeline_display.Items.Clear();
        }

        private string format_turn(Turn turn)
        {
            return $"{turn.owner.name,-7}: {(int)(turn.time_until_turn * 1000)}";
        }
    }
}
