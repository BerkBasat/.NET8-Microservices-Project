using AutoMapper;
using Ecommerce.Services.CouponAPI.DTO;
using Ecommerce.Services.CouponAPI.Models;

namespace Ecommerce.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, Coupon>();
                config.CreateMap<Coupon, CouponDTO>();
            });
            return mappingConfig;
        }
    }
}
