using Core.DTO_s;
using Core.Entities;
using Core.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Infrastructre.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _Context;
        public ProductRepository(AppDbContext context)
        {
             _Context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
         var getOne= await  _Context.products.FindAsync(id);
            if (getOne is null)
            {
                return new Product();
            }
            return getOne;
        }

        public async Task<IReadOnlyList<ProductDto>> GetProductsAsync()
        {
            return await(from p in _Context.products
                     join pt in _Context.productTypes on p.ProductBrandId equals pt.Id
                     join pb in _Context.productBrands on p.ProductTypeId equals pb.Id
                     select new ProductDto
                     {
                         ProductName = p.Name,
                         Price= p.Price,
                         Description = p.Description,
                         PictureUrl = p.PictureUrl,
                         ProductBrandName = pb.Name,
                         ProductTypeName= pt.Name,


                     }).ToListAsync();
           // return await  _Context.products.Include(x=>x.productType).Include(x=>x.productBrand).ToListAsync();
          
        }
    }
}
