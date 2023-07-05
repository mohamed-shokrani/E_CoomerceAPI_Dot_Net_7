using API.Errors;
using Infrastructre.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class BuggyController : BaseApiController
{
    private readonly AppDbContext _Context;

    public BuggyController(AppDbContext context)
    {
        _Context = context;

    }
    [HttpGet("NotFound")]
    public ActionResult GetNoFoundRequest()
    {
        var thing = _Context.products.Find(42);
        if (thing is null)
        {
            return NotFound(new ApiResponse(404));
        }
        return Ok();
    }
    [HttpGet("ServerError")]
    public ActionResult GetServerError()
    {
        var thing = _Context.products.Find(42);
        var thingToreturn = thing.ToString();//is going to generates an exception you can not excute tostring method
                                             //on something that does not exist
        
        return Ok();
    }

    [HttpGet("BadRequest")]
    public ActionResult GetBadRequest()
    {

        return BadRequest(new ApiResponse(400) );//400 
    }
    [HttpGet("BadRequest/{id}")]
    public ActionResult GetBadRequest(int id)
    {

        return BadRequest();//400 
    }
}