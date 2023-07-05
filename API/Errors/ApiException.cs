namespace API.Errors;

public class ApiException : ApiResponse
{
    public string Details   { get; set; }
    public ApiException(int statusCode, string message = null,string details =null) : base(statusCode, message)
    {
        // we will create middleware so we can handle exception and use this particular class when we get an exception
        Details = details;// 
    }
}
