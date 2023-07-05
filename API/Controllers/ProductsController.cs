using API.Errors;
using AutoMapper;
using Core.DTO_s;
using Core.Entities;
using Core.Interfaces;
using Infrastructre.Data.Specification;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers;


public class ProductsController : BaseApiController 
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
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof (ApiResponse),404)]

    public async Task<ActionResult<Product>> GetSingle(int id)
    {
        var spec = new ProductsWithBrandsAndTypes(id);
        var product = await _Data.GetEntityWithSpec(spec);
        if (product is null)
        {
            return NotFound(new ApiResponse(404));
        }
       
        return Ok(_Mapper.Map<Product, ProductDto>(product));
    }
}
