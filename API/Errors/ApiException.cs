namespace API.Errors
{
    public class ApiException : ApiResponse
    {
        private readonly int _statusCode;
        private readonly string _message;
        public string Details { get; set; }

        public ApiException(int statusCode, string message = null, string details = null) : base(statusCode, message)
        {
            _statusCode = statusCode;
            _message = message;
            Details = details;
        }
    }
}