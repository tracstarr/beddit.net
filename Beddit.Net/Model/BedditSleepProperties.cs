namespace Beddit.Net.Model
{
    public class BedditSleepProperties
    {
        public double SleepTimeTarget { get; set; }
        public double RestingHeartRate { get; set; }
        public double AverageRespirationRate { get; set; }
        public double SleepLatency { get; set; }
        public double AwayEpisodeCount { get; set; }
        public double TotalSnoringEpisodeDuration { get; set; }
        public double StageDurationA { get; set; }
        public double StageDurationS { get; set; }
        public double StageDurationW { get; set; }
        public double StageDurationG { get; set; }
        public double ScoreBedExits { get; set; }
        public double ScoreAmountOfSleep { get; set; }
        public double ScoreSnoring { get; set; }
        public double ScoreSleepLatency { get; set; }
        public double ScoreSleepEfficiency { get; set; }
        public double ScoreAwakenings { get; set; }
    }
}