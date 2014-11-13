using Beddit.Net.Model;

namespace Beddit.Net.ResponseModel
{
    public class BedditRawSleepDataResponse : BedditBaseSleepData, IBedditResponse
    {
        public BedditTimeValueTracks TimeValueTracks { get; set; }
    }
}