using System.Collections.Generic;

namespace View
{
    public class timelineEntity
    {
        private static timelineEntity timeline_entity;
        private static ITimeline timeline;

        private timelineEntity(ITimeline new_timeline)
        {
            timeline = new_timeline;
        }

        public static timelineEntity initialize(ITimeline new_timeline)
        {
            if (timeline_entity == null)
            {
                timeline_entity = new timelineEntity(new_timeline);
            }
            return timeline_entity;
        }

        public static void update(List<string> turns)
        {
            if (timeline == null) return;
            timeline.update(turns);
        }
    }
}
