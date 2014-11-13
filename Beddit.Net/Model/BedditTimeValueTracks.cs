namespace Beddit.Net.Model
{
    public class BedditTimeValueTracks
    {
        public BedditTimeTrackItem Presence { get; set; }
        public BedditTimeTrackItem HeartRateCurve { get; set; }
        public BedditTimeTrackItem SleepStages { get; set; }
        public BedditTimeTrackItem SnoringEpisodes { get; set; }
        public BedditTimeTrackItem SleepCycles { get; set; }
        public BedditTimeTrackItem AlarmEvent { get; set; }
    }
}