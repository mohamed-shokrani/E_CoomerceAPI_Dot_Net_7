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
    private readonly IProductRepository _ProductRepository;
    private readonly IGenericRepository<Product> _Data ;
    private readonly IGenericRepository<ProductBrand> _Brand ;
    private readonly IGenericRepository<ProductType> _Types;//_productRepository;

    //_productRepository;_
    private readonly IMapper _Mapper;
    public ProductsController(IGenericRepository<ProductType> types ,IMapper mapper, IProductRepository productRepository, IGenericRepository<Product> data, IGenericRepository<ProductBrand> brand)
    {
        _Mapper = mapper;
        _ProductRepository = productRepository;
        _Data = data;
        _Brand = brand;
        _Types = types;
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery] ProductSpecParams productSpecParams)
    {

        var spec = new ProductsWithBrandsAndTypes(productSpecParams);

        var countSpec = new ProductWithFiltersForCountSpecefication(productSpecParams);

        var totalItems = await _Data.CountAsync(countSpec);

        var products = await _Data.ListAsync(spec);

        var data = _Mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

        return Ok(new Pagination<ProductDto>(productSpecParams.indexPage, productSpecParams.pageSize
                                    , totalItems, data));
    }
    [HttpGet("ProductBrand")]
    public async Task< ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
    {
        var brands = await _Brand.ListAllAsync();


        return Ok(brands); 
    }

    [HttpGet("ProductTypes")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
    {
        var brands = await _Types.ListAllAsync();


        return Ok(brands);
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
