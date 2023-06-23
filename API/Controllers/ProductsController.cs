using Infrastructre.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _Context;

    public ProductsController(AppDbContext context)
    {
        _Context = context;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var all = await _Context.products.ToListAsync();
        return Ok(all);
    }
}
