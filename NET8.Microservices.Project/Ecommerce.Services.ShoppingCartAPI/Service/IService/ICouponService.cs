using Ecommerce.Services.ShoppingCartAPI.DTO;

namespace Ecommerce.Services.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDTO> GetCoupon(string couponCode);
    }
}
