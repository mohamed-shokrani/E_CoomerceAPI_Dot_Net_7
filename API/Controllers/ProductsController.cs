using AutoMapper;
using Core.DTO_s;
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
    private readonly IMapper _Mapper;


    public ProductsController(IMapper mapper, IProductRepository productRepository, IGenericRepository<Product> data)
    {
        _Mapper = mapper;
        _productRepository = productRepository;
        _Data = data;
    }

  

    [HttpGet]
    public async Task<ActionResult< IReadOnlyList<ProductDto>>> GetProducts()
    {
        var spec = new ProductsWithBrandsAndTypes();
        var products = await _Data.ListAsync(spec);
       
     return Ok( _Mapper.Map<IReadOnlyList <Product>,IReadOnlyList<ProductDto>>(products));



    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetSingle(int id)
    {
        var spec = new ProductsWithBrandsAndTypes(id);
        return Ok(await _Data.GetEntityWithSpec(spec));
    }
}
