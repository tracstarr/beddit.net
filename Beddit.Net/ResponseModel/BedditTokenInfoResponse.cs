namespace Beddit.Net.ResponseModel
{
    public class BedditTokenInfoResponse : IBedditResponse
    {
        public int User { get; set; }
        public string TokenType { get; set; }
    }
}