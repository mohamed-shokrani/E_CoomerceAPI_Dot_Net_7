using Core.Entities;

namespace Infrastructre.Data.Specification;

public class ProductsWithBrandsAndTypes : Specification<Product>
{
    public ProductsWithBrandsAndTypes()
    {
        AddInclude(x => x.productType);
        AddInclude(x => x.productBrand);
    }
    public ProductsWithBrandsAndTypes(int id) 
        :base( x=>x.Id ==id)
    {
        AddInclude(x => x.productType);
        AddInclude(x => x.productBrand);
    }
}
