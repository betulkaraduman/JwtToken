using AutoMapper;
using JwtApp_141022.Core.Application.Dtos;
using JwtApp_141022.Core.Domain;

namespace JwtApp_141022.Core.Application.Mappings
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductListDto, Product>().ReverseMap();
        }
    }
}
