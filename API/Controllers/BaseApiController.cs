using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //it also check what kind of value it is in our route paramter api/product/fiver
    // if it encouter what it sees a validation error than it adds the error to something called model state
    
    public class BaseApiController : ControllerBase
    {
    }
}
