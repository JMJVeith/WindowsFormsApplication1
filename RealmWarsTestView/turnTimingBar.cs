using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealmWarsTestView
{
    class turnTimingBar
    {
        private ProgressBar progress_bar;

        public turnTimingBar(ProgressBar progress_bar)
        {
            this.progress_bar = progress_bar;
        }

        public void instant_update(int percent)
        {
            if (percent == 0)
            {
                progress_bar.Value = 0;
                return;
            }

            progress_bar.Value = percent;
            progress_bar.Value = percent - 1;
            progress_bar.Value = percent;
        }

        public void update()
        {
            progress_bar.Update();
        }
    }
}
