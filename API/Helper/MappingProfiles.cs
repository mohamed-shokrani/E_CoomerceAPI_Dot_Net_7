using AutoMapper;
using Core.DTO_s;
using Core.Entities;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.ProductBrandName, o => o.MapFrom(s => s.productBrand.Name))
                .ForMember(d => d.ProductTypeName, o => o.MapFrom(s => s.productType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolve>());

        }
    }
}
