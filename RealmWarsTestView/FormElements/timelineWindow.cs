using System.Collections.Generic;
using System.Windows.Forms;
using RealmWarsModel;
using View;

namespace RealmWarsTestView
{
    class timelineWindow : ITimeline
    {
        ListBox timeline_display;

        public timelineWindow(ListBox timeline_display)
        {
            this.timeline_display = timeline_display;
            timelineEntity.initialize(this);
        }

        public void update(List<string> turns)
        {
            clear();

            foreach (string turn in turns)
            {
                timeline_display.Items.Add(turn);
            }
        }

        private void clear()
        {
            timeline_display.Items.Clear();
        }
    }
}
