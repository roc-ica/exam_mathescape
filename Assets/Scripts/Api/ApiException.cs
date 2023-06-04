using System;
using System.Net;

namespace Api
{
    public class ApiException: Exception
    {
        public ApiException(HttpStatusCode code, string message)
        {
            Code = code;
            HttpErrorMessage = message;
        }
        
        public HttpStatusCode Code { get; }
        
        public string HttpErrorMessage { get; }

        public override string Message => $"Failed to access Api. Code {Code}: {HttpErrorMessage}";
    }
}