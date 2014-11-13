using System;
using System.Collections.Generic;

namespace Beddit.Net.Model
{
    public abstract class BedditBaseSleepData
    {
        public DateTime Date { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Tips { get; set; }
        public string TimeZone { get; set; }
        public double StartTimestamp { get; set; }
        public double EndTimestamp { get; set; }
        public double SessionRangeStart { get; set; }
        public double SessionRangeEnd { get; set; }
        public List<BedditSleepProperties> Properties { get; set; }
        public double Updated { get; set; }
    }
}