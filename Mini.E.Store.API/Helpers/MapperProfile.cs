using AutoMapper;
using Mini.E.Store.Core.Dtos;
using Mini.E.Store.Core.Models;

namespace Mini.E.Store.API.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(b => b.ProductBrand, b => b.MapFrom(s => s.ProductBrand.Name))
                .ForMember(t => t.ProductType, t => t.MapFrom(s => s.ProductType.Name))
                .ForMember(p => p.PictureUrl, s => s.MapFrom<ProductUrlResolver>());
        }
    }
}
