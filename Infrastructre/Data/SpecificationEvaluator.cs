﻿using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructre.Data;

public class SpecificationEvaluator<TEntity>  where TEntity : BaseEntity
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,ISpecification<TEntity> spec)
    {
        var query = inputQuery;
        if (spec.Criteria != null)
        {
            query= query.Where(spec.Criteria);
        }
        query = spec.Includes.Aggregate(query,(current,include) =>current.Include(include));
        return query;

    }

}