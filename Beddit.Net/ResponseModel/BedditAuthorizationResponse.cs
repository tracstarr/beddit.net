namespace Beddit.Net.ResponseModel
{
    public class BedditAuthorizationResponse : IBedditResponse
    {
        public int User { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
    }
}