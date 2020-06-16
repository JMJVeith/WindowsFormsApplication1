using System.Collections.Generic;
using RealmWarsModel;
using RealmWarsTestView;


namespace RealmWarsController
{
    class timelineReporter : Reporter<List<string>>
    {
        View<List<string>> host;

        public timelineReporter(View<List<string>> host)
        {
            this.host = host;
        }

        public void print(List<string> timeline)
        {
            host.print(timeline);
        }
    }
}
