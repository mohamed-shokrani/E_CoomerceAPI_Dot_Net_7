using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
         return await  _Context.products.ToListAsync();
          
        }
    }
}
