using AutoMapper;
using Ecommerce.Services.ProductAPI.DTO;
using Ecommerce.Services.ProductAPI.Models;

namespace Ecommerce.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDTO, Product>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
