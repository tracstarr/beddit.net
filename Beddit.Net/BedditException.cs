using System;

namespace Beddit.Net
{
    public class BedditException : Exception
    {
        public string Error { get; set; }
        public string Description { get; set; }

        public BedditException(string message, Exception exception)
            : base(message, exception)
        {
            Error = exception.GetType().FullName;
            Description = message;
        }

        public BedditException(string error, string description)
            :base(description)
        {
            Error = error;
            Description = description;
        }

        public BedditException()
        {
            
        }
    }
}
