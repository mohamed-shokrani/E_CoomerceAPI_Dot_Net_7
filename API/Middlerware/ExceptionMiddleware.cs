using API.Errors;
using System.Net;
using System.Text.Json;

namespace API.Middlerware;
public class ExceptionMiddleware 
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;
    // RequestDelegate next --> if there is no exception we want  the middlware to move to the next piece of middlware
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
		 IHostEnvironment env)// to check wether or not we are in development mode 
	{
        _next = next;
        _logger = logger;
        _env = env;
    }
    public async Task InvokeAsync(HttpContext context)
        //this gonna be our exception handling middleware 
        //as a requset comes in to our api 
    {
        try
        {
            await _next(context);// this means if there is no exception then the request moves in the next stage
        }
        catch (Exception ex)//we will use our exception handling response 
        {
            _logger.LogError(ex,ex.Message);// our loggin system is just the console 
            // and we will see inside that if we gets an error 

            context.Response.ContentType= "application/json";
            context.Response.StatusCode =(int)HttpStatusCode.InternalServerError;

            var response = _env.IsDevelopment()
                ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                : new ApiException((int)HttpStatusCode.InternalServerError);
            // we are gonna get more details if we are running in development mode 
            var options = new JsonSerializerOptions { PropertyNamingPolicy= JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response, options);
             await context.Response.WriteAsync(json);
        }
    }

}
