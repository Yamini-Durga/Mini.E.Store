using AutoMapper;
using Mini.E.Store.Core.Dtos;
using Mini.E.Store.Core.Models;

namespace Mini.E.Store.API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return string.Concat(_config["ApiUrl"], source.PictureUrl);
            }
            return null;
        }
    }
}
