using API.Errors;
using API.Helper;
using AutoMapper;
using Core.DTO_s;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
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
    public async Task<ActionResult< Pagination<ProductDto>>> GetProducts([FromQuery]ProductSpecParams productSpecParams)
    {

        var spec = new ProductsWithBrandsAndTypes(productSpecParams);

        var countSpec = new ProductWithFiltersForCountSpecefication(productSpecParams);

        var totalItems = await _Data.CountAsync(countSpec);

        var products = await _Data.ListAsync(spec);

        var data = _Mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

     return Ok( new Pagination<ProductDto>(productSpecParams.indexPage,productSpecParams.pageSize
                                 , totalItems, data));
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
