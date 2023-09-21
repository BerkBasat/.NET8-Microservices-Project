using Ecommerce.Services.OrderAPI.DTO;

namespace Ecommerce.Services.OrderAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
    }
}
