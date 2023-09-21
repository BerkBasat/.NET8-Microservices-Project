using Ecommerce.Web.Models;

namespace Ecommerce.Web.Service.IService
{
    public interface IOrderService
    {
        Task<ResponseDTO?> CreateOrder(CartDTO cartDTO);
    }
}
