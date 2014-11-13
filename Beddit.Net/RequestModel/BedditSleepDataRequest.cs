using System;

namespace Beddit.Net.RequestModel
{
    public class BedditSleepDataStartAndEndDateRequest : IBedditRequest
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public BedditSleepDataStartAndEndDateRequest(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}