using Core.Entities;

namespace Infrastructre.Data.Specification;

public class ProductsWithBrandsAndTypes : Specification<Product>
{
    public ProductsWithBrandsAndTypes()
    {
        AddInclude(x => x.productType);
        AddInclude(x => x.productBrand);
    }
}
