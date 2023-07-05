using AutoMapper;
using Core.DTO_s;
using Core.Entities;

namespace API.Helper
{
    public class ProductUrlResolve : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration Config;

        public ProductUrlResolve(IConfiguration config)
        {
            Config = config;
        }


        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return Config["ApiUrl"] + source.PictureUrl;

            }
            return null;
        }
    }
}
