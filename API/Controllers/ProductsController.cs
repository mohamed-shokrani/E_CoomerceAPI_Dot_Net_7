using Core.Entities;
using Core.Interfaces;
using Infrastructre.Data.Specification;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase 
{
    private readonly IProductRepository _productRepository ;
    private readonly IGenericRepository<Product> _Data ;//_productRepository;


    public ProductsController(IProductRepository productRepository, IGenericRepository<Product> data)
    {
        _productRepository = productRepository;
        _Data = data;
    }
    [HttpGet]
    public async Task<ActionResult< IReadOnlyList<Product>>> GetProducts()
    {
        var spec = new ProductsWithBrandsAndTypes();

        return Ok(await _Data.ListAsync(spec));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult< Product>> GetSingle(int id)
    {
      
        return Ok(await  _Data.GetByIdAsync(id));
    }
}
