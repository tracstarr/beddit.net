namespace Beddit.Net.RequestModel
{
    public class BedditAuthorizationRequest : IBedditRequest
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string GrantType { get; private set; }

        public BedditAuthorizationRequest(string username, string password)
        {
            UserName = username;
            Password = password;
            GrantType = "password";
        }
    }
}