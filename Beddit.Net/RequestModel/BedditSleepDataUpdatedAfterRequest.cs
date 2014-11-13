namespace Beddit.Net.RequestModel
{
    public class BedditSleepDataUpdatedAfterRequest : IBedditRequest
    {
        public double UpdatedAfter { get; private set; }

        public BedditSleepDataUpdatedAfterRequest(double timeOfLastUpdateUnixTimestamp)
        {
            UpdatedAfter = timeOfLastUpdateUnixTimestamp;
        }
    }
}