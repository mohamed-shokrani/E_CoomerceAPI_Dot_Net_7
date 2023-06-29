using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
       var gt=await _Context.Set<T>().FindAsync(id);
        return gt;
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _Context.Set<T>().ToListAsync();
    }
}
