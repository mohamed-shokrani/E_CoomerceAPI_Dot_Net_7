using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructre.Data;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _Context;

    public GenericRepository(AppDbContext context)
    {
        _Context = context;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var gt = await _Context.Set<T>().FindAsync(id);
        return gt;
    }

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
      return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<List<T>> ListAsync(ISpecification<T> spec)
    {
       return await ApplySpecification(spec).ToListAsync(); 
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _Context.Set<T>().ToListAsync();
    }
    public async Task<int> CountAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).CountAsync();
    }
    private IQueryable<T> ApplySpecification(ISpecification<T> spec) 
    {
        // So T gets Replaced with let's say product and is goona be converted into a querable 
       
        return SpecificationEvaluator<T>.GetQuery(_Context.Set<T>().AsQueryable(),spec);
    }

  
}
