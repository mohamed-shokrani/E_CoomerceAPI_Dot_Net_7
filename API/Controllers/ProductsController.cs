using Core.Entities;
using Core.Interfaces;
using Infrastructre.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase 
{
    private readonly IProductRepository _productRepository ;
    private readonly AppDbContext _Context;//_productRepository;


    public ProductsController(IProductRepository productRepository, AppDbContext context)
    {
        _productRepository = productRepository;
        _Context = context;
    }
    [HttpGet]
    public async Task<ActionResult <IReadOnlyList<Product>>> GetAll()
    {
        var all = await _productRepository.GetProductsAsync();
        return Ok(all);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult< Product>> GetSingle(int id)
    {
      
        return Ok(await _productRepository.GetProductByIdAsync(id));
    }
}
