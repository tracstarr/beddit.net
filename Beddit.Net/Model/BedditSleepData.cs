using System.Collections.Generic;

namespace Beddit.Net.Model
{
    public class BedditSleepData : BedditBaseSleepData
    {
        public IList<BedditAlarm> Alarms { get; set; }
        public IList<BedditSleepCycle> SleepCycles { get; set; }
        public IList<BedditSnoring> Snoring { get; set; }
        public IList<BedditHeartRate> HeartRate { get; set; }
        public IList<BedditSleepStage> SleepStages { get; set; }
        public IList<BedditPresence> Presence { get; set; }
    }
}