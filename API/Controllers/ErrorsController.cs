using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("errors/{code}")]
[ApiExplorerSettings (IgnoreApi = true)] // in order for Swagger to ignore  it 
public class ErrorsController : BaseApiController
{
    
    public IActionResult Error(int code) 
    { 
     return new ObjectResult(new ApiResponse(code));
       
    }
}
