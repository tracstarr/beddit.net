namespace Beddit.Net.RequestModel
{
    public class BedditPasswordResetRequest : IBedditRequest
    {
        public string Email { get; private set; }

        public BedditPasswordResetRequest(string email)
        {
            Email = email;
        }
    }
}